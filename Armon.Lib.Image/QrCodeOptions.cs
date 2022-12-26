namespace Armon.Lib.Image
{
    public class QrCodeIcon
    {
        public string? Path { get; set; }
        public int Size { get; set; }
        public int Border { get; set; }
    }

    public class QrCodeOptions
    {
        public int Version { get; set; }
        public int Scale { get; set; }
        public QrCodeIcon? Icon { get; set; }
        public bool Edge { get; set; }

        public QrCodeLevel Level { get; set; }
    }

    public enum QrCodeLevel
    {
        L,
        M,
        Q,
        H
    }
}
