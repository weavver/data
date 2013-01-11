//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Weavver.Utilities
//{
//     /// <summary>
//     /// Must implement ICustomFormatter and IFormatProvider
//     /// </summary>
//     public class DateTimeFormatter : ICustomFormatter, IFormatProvider
//     {
//          public DateTimeFormatter() : this(new Dictionary<string, Func<string[], string>>
//                                            {
//                                                {"Format1", Format1},
//                                                {"Format2", Format2}
//                                            })
//          {
//          }


//VoiceScribe_File file = (VoiceScribe_File)e.Item.DataItem;

//TimeSpan span = DateTime.Now - file.ReceivedAt.Subtract(TimeSpan.FromHours(3));
//string tspan = "0";
//if (span.Days > 0 && span.Days == 1)
//{
//     tspan = "yesterday";
//}
//else if (span.Days > 0 && span.Days > 1 && span.Days <= 6)
//{
//     tspan = "last " + file.ReceivedAt.DayOfWeek;
//}
//else if (span.Days > 0 && span.Days > 6)
//{
//     tspan = span.Days + " days ago";
//}
//else if (span.Hours > 0 && span.Hours == 1)
//{
//     tspan = "about " + span.Hours + " hour ago";
//}
//else if (span.Hours > 0 && span.Hours > 1)
//{
//     tspan = "about " + span.Hours + " hours ago";
//}
//else if (span.Minutes > 0 && span.Minutes == 1)
//{
//     tspan = span.Minutes + " minute ago";
//}
//else if (span.Minutes > 0 && span.Minutes > 1)
//{
//     tspan = span.Minutes + " minutes ago";
//}

//string fname = (file.CallerName == null || file.CallerName == "") ? "someone" : file.CallerName;
//Literal line = (Literal) e.Item.FindControl("LiteralText");
//line.Text = String.Format("Message from {0} left {1},", fname, tspan);

//          /// <summary>
//          /// Use this constructor if you would like to pass in the dictionary of formats.
//          /// </summary>
//          /// <param name="formats"></param>
//          public DateTimeFormatter(IDictionary<string, Func<string[], string>> formats)
//          {
//               Formats = formats;
//          }

//          /// <summary>
//          /// This is the dictionary containing the various format types.
//          /// </summary>
//          private IDictionary<string, Func<string[], string>> Formats { get; set; }

//          public string Format(string format, object arg, IFormatProvider formatProvider)
//          {
//               if (!Formats.ContainsKey(format)) return arg.ToString();

//               decimal d;
//               if (!decimal.TryParse(arg.ToString(), out d)) return arg.ToString();

//               return Formats[format](d.ToString().Split('.'));
//          }

//          /// <summary>
//          /// Used automatically with string.Format. Will return this Formatter object for use with string.Format
//          /// </summary>
//          /// <param name="formatType"></param>
//          /// <returns></returns>
//          public object GetFormat(Type formatType)
//          {
//               return this;
//          }

//          private static string Format1(string[] parts)
//          {
//               return string.Format("<div class="dollar">{0}</div><div class="cents">{1}</div>", parts[0], parts[1]);
//          }

//          private static string Format2(string[] parts)
//          {
//               return string.Format("<div class="symbol">$</div><div class="dollar">{0}</div><div class="cents">{1}</div>",parts[0], parts[1]);
//          }
//     }
//}



//if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
//{
//     VoiceScribe_File file = (VoiceScribe_File)e.Item.DataItem;

//     TimeSpan span = DateTime.Now - file.ReceivedAt.Subtract(TimeSpan.FromHours(3));
//     string tspan = "0";
//     if (span.Days > 0 && span.Days == 1)
//     {
//          tspan = "yesterday";
//     }
//     else if (span.Days > 0 && span.Days > 1 && span.Days <= 6)
//     {
//          tspan = "last " + file.ReceivedAt.DayOfWeek;
//     }
//     else if (span.Days > 0 && span.Days > 6)
//     {
//          tspan = span.Days + " days ago";
//     }
//     else if (span.Hours > 0 && span.Hours == 1)
//     {
//          tspan = "about " + span.Hours + " hour ago";
//     }
//     else if (span.Hours > 0 && span.Hours > 1)
//     {
//          tspan = "about " + span.Hours + " hours ago";
//     }
//     else if (span.Minutes > 0 && span.Minutes == 1)
//     {
//          tspan = span.Minutes + " minute ago";
//     }
//     else if (span.Minutes > 0 && span.Minutes > 1)
//     {
//          tspan = span.Minutes + " minutes ago";
//     }

//     string fname = (file.CallerName == null || file.CallerName == "") ? "someone" : file.CallerName;
//     Literal line = (Literal)e.Item.FindControl("LiteralText");
//     line.Text = String.Format("Message from {0} left {1},", fname, tspan);