using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnoAcrylicBrushSkiaError.Helpers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UnoAcrylicBrushSkiaError.Controls
{
    public sealed partial class SkiaSharpImageControl : UserControl
    {
        SKBitmap skiaBmp;

        public SkiaSharpImageControl()
        {
            this.InitializeComponent();

            skiaCanvas.PaintSurface += SkiaCanvas_PaintSurface;
        }

        private void SkiaCanvas_PaintSurface(object sender, SkiaSharp.Views.UWP.SKPaintSurfaceEventArgs e)
        {
            if (skiaBmp != null)
            {
                e.Surface.Canvas.Clear();
                e.Surface.Canvas.DrawBitmap(skiaBmp, e.Info.Rect, BitmapStretch.UniformToFill);
            }
        }

        public void ShowImage(byte[] bytes)
        {
            skiaBmp = SKBitmap.Decode(bytes);

            skiaCanvas.Invalidate();
        }
    }
}
