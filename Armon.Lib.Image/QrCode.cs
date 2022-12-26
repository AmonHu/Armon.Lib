using System.Drawing;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace Armon.Lib.Image
{
    public static class QrCode
    {
        public static Bitmap Encode(string message, QrCodeOptions? options = null)
        {
            var defaultScale = 4;
            if (options != null)
            {
                defaultScale = options.Scale;
            }

            var defaultLevel = QRCodeEncoder.ERROR_CORRECTION.M;
            if (options != null)
            {
                defaultLevel = (QRCodeEncoder.ERROR_CORRECTION)options.Level;
            }

            var defaultVersion = 0;
            if (options != null)
            {
                defaultVersion = options.Version;
            }

            var encoder = new QRCodeEncoder
            {
                QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
                QRCodeScale = defaultScale,
                QRCodeVersion = defaultVersion,
                QRCodeErrorCorrect = defaultLevel,
                QRCodeBackgroundColor = Color.White,
                QRCodeForegroundColor = Color.Black
            };
            return encoder.Encode(message, Encoding.UTF8);
        }

        public static string Decode(Bitmap img)
        {
            var decoder = new QRCodeDecoder();
            return decoder.decode(new QRCodeBitmapImage(img));
        }
    }
}