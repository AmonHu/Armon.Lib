using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Versioning;
using SystemImage = System.Drawing.Image;
namespace Armon.Lib.Image
{
    public enum ThumbnailMode
    {
        Cut,
        Hw,
        H,
        W,
    }

    public class ThumbnailOptions
    {
        /// <summary>
        /// 缩略图宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 缩略图高度
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 生成缩略图的方式
        /// </summary>
        public ThumbnailMode Mode { get; set; }
    }


    [SupportedOSPlatform("windows")]
    internal class Thumbnail
    {
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="options">参数</param>
        /// <return> image</return>
        public static SystemImage Generate(SystemImage original, ThumbnailOptions options)
        {
            var towidth = options.Width;
            var toheight = options.Height;

            var x = 0;
            var y = 0;
            var ow = original.Width;
            var oh = original.Height;

            switch (options.Mode)
            {
                case ThumbnailMode.Hw:  //指定高宽缩放（可能变形）                
                    break;
                case ThumbnailMode.W:   //指定宽，高按比例                    
                    toheight = original.Height * options.Width/ original.Width;
                    break;
                case ThumbnailMode.H:   //指定高，宽按比例
                    towidth = original.Width * options.Height/ original.Height;
                    break;
                default: //指定高宽裁减（不变形）                
                    if ((double)original.Width / original.Height > towidth / (double)toheight)
                    {
                        oh = original.Height;
                        ow = original.Height * towidth / toheight;
                        y = 0;
                        x = (original.Width - ow) / 2;
                    }
                    else
                    {
                        ow = original.Width;
                        oh = original.Width * options.Height / towidth;
                        x = 0;
                        y = (original.Height - oh) / 2;
                    }
                    break;
            }

            //新建一个bmp图片
            var bitmap = new Bitmap(towidth, toheight);
            //新建一个画板
            var g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(original, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);

            return bitmap;
        }
    }
}
