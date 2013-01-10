using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

using com.google.zxing.qrcode;
using com.google.zxing;

namespace Weavver.Utilities
{
     public class QRUtility
     {
//-------------------------------------------------------------------------------------------
          public static Bitmap GenerateCode(string data)
          {
               return GenerateCode(data, 200);
          }
//-------------------------------------------------------------------------------------------
          public static Bitmap GenerateCode(string data, int size)
          {
               QRCodeWriter writer = new QRCodeWriter();
               com.google.zxing.common.ByteMatrix matrix;

               matrix = writer.encode(data, BarcodeFormat.QR_CODE, size, size, null);

               Bitmap img = new Bitmap(size, size);
               Color Color = Color.FromArgb(0, 0, 0);

               for (int y = 0; y < matrix.Height; ++y)
               {
                    for (int x = 0; x < matrix.Width; ++x)
                    {
                         Color pixelColor = img.GetPixel(x, y);

                         //Find the colour of the dot
                         if (matrix.get_Renamed(x, y) == -1)
                         {
                              img.SetPixel(x, y, Color.White);
                         }
                         else
                         {
                              img.SetPixel(x, y, Color.Black);
                         }
                    }
               }
               return img;
          }
//-------------------------------------------------------------------------------------------
     }
}
