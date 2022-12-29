using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Width { get; set; }
        public int Height { get; set; }
        public ThumbnailMode Mode { get; set; }
    }
}
