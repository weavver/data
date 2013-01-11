using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weavver.Utilities;
using PDFjet.NET;
using System.Text.RegularExpressions;
using System.IO;

namespace Weavver.Data
{
     partial class Accounting_Checks
     {    
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// This method generates a PDF copy of the check to be printed on standard 3 sheet check paper.
          /// </summary>
          /// <param name="db"></param>
          /// <param name="invoice"></param>
          /// <returns>Returns the path to the PDF file on the local file system.</returns>
          public string GeneratePDF()
          {
               string filepath = System.IO.Path.GetTempFileName() + ".pdf";

               FileStream fos = new FileStream(filepath, FileMode.Create);
               BufferedStream bos = new BufferedStream(fos);
               PDF pdf = new PDF(bos);
               Page p = new PDFjet.NET.Page(pdf, Letter.PORTRAIT);

               // these two variables are lazy loaded from the db so we cache them here
               Logistics_Addresses payeeAddress = PayeeAddress;
               string payeeName = PayeeName;
               for (int i = 0; i < 3; i++)
               {
                    int yoffset = i * 251;
                    // these lines draw a seperation line between the 3 parts on a full check sheet which is useful for debugging
                    //Line l = new Line(0, yoffset, 400, yoffset);
                    //l.DrawOn(p);
                    //yoffset += 25;
                    // draw the date
                    DrawText(pdf, p, PostAt.ToString("MM/dd/yy"), 515, yoffset + 70);

                    int xnameoffset = (i == 0) ? 85 : 30;
                    DrawText(pdf, p, payeeName, xnameoffset, yoffset + 105);
                    DrawText(pdf, p, "**" + String.Format("{0:f}", Amount), 500, yoffset + 107);
                    int amountnodecimals = Convert.ToInt32(Math.Truncate(Amount));
                    int decimals = Convert.ToInt32((Amount - amountnodecimals) * 100);
                    DrawText(pdf, p, NumberConvertor.NumberToText(amountnodecimals).ToLower() + " dollar(s) " + NumberConvertor.NumberToText(decimals).ToLower() + " cents *****************", 30, yoffset + 130);

                    // draw the mailing address for windowed envelopes
                    string mailingAddress = (payeeAddress == null) ? "" : payeeAddress.ToString();
                    if (!String.IsNullOrEmpty(mailingAddress))
                    {
                         string[] addressLines = Regex.Split(mailingAddress, "\r\n");
                         for (int a = 0; a < addressLines.Length; a++)
                         {
                              DrawText(pdf, p, addressLines[a], 50, yoffset + 155 + (a * 12));
                         }
                    }

                    // draw the memo
                    DrawText(pdf, p, Memo, 30, yoffset + 215);
               }
               pdf.Flush();
               bos.Close();

               return filepath;
          }
//-------------------------------------------------------------------------------------------
          private void DrawText(PDFjet.NET.PDF pdf, PDFjet.NET.Page page, string text, int x, int y)
          {
               Font f1 = new Font(pdf, "Helvetica");
               f1.SetSize(10);
               PDFjet.NET.TextLine tLine = new TextLine(f1);
               tLine.SetText(text);
               tLine.SetPosition(x, y);
               //tLine.SetURIAction("http://www.weavver.com/accounting/");
               tLine.DrawOn(page);
          }
//-------------------------------------------------------------------------------------------
     }
}
