using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace UnoAcrylicBrushSkiaError.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new UnoAcrylicBrushSkiaError.App(), args);
            host.Run();
        }
    }
}
