using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows;

namespace TreeGenerator.src
{
    public static class Helpers
    {

        public static BitmapSource LoadBitmap(System.Drawing.Bitmap img)
        {
            IntPtr ip = img.GetHbitmap();
            BitmapSource bsrc = null;

            try
            {
              bsrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip,
              IntPtr.Zero, Int32Rect.Empty,
              System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            } catch
            {

            }

            return bsrc;
        }
    }
}
