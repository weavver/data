using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Utilities
{
     public class DateTimeHelper
     {
          
//-------------------------------------------------------------------------------------------
          public static long SecondsFromEpoch(DateTime date)
          {
               DateTime dt = date.ToUniversalTime();
               TimeSpan ts = dt.Subtract(Common.JAN_01_1970);
               return (long)ts.TotalSeconds;
          }
//-------------------------------------------------------------------------------------------
          // Given Unix Timestamp, get DateTime
          public static DateTime EpochToDate(long secFromEpoch)
          {
               return Common.JAN_01_1970.AddSeconds(secFromEpoch);
          }
//-------------------------------------------------------------------------------------------
          public static string GetFriendlyDateString(DateTime? datePassed)
          {
               if (!datePassed.HasValue)
                    return "unknown";
               DateTime date = datePassed.Value;
               TimeSpan difference = DateTime.Now.Subtract(date);
               string datestring = "undefined";
               if (difference.Hours < 0 || difference.Minutes < 0 || difference.Seconds < 0)
                    difference = difference.Negate();
               int days = difference.Days;
               int hours = difference.Hours;
               int minutes = difference.Minutes;
               int seconds = difference.Seconds;
               if (days == 0 && minutes == 0 && hours == 0)
               {
                    datestring = seconds.ToString();
                    if (difference.Seconds > 1 || difference.Seconds == 0)
                         datestring += " seconds";
                    else
                         datestring += " second";
               }
               else if (days == 0 && minutes > 0 && hours == 0)
               {
                    datestring = minutes.ToString();
                    if (minutes > 1)
                         datestring += " minutes";
                    else
                         datestring += " minute";
               }
               else if (difference.Hours >= 1 && difference.Hours <= 24 && difference.Days == 0)
               {
                    return datePassed.Value.ToString("h:mm tt");
               }
               else
               {
                    //return datePassed.Value.ToString("MM/dd/yy h:mm tt");
                    return datePassed.Value.ToString("MM/dd/yy");
               }
               //else if (days == 1)
               //{
               //     datestring = days + " day";
               //}
               //else if (days > 30)
               //{
               //     int months = days / 30;
               //     if (months > 1)
               //          datestring = months + " months";
               //     else
               //          datestring = months + " month";
               //}
               //else if (days > 0)
               //{
               //     datestring = days + " days";
               //}
               //else if (hours == 1)
               //{
               //     datestring = hours + " hour";
               //}
               //else if (hours > 1)
               //{
               //     datestring = hours + " hours";
               //}
               if (difference.Hours < 0 || difference.Minutes < 0 || difference.Seconds < 0)
                    datestring = "In " + datestring;
               else
                    datestring = datestring + " ago";
               return datestring;
          }
//-------------------------------------------------------------------------------------------
          //public string GetFriendlyDateString(DateTime date)
          //{
          //     TimeSpan difference = DateTime.UtcNow.Subtract(date);
          //     string datestring = "undefined";
          //     if (difference.Days > 0)
          //     {
          //          datestring = difference.Days + " days ago";
          //     }
          //     else if (difference.Hours > 0)
          //     {
          //          datestring = difference.Hours + " hours ago";
          //     }
          //     return datestring;
          //}
//-------------------------------------------------------------------------------------------
          public static string GetHumanFriendlyTimeString(double seconds)
          {
               return GetHumanFriendlyTimeString(TimeSpan.FromSeconds(seconds), false);
          }
//-------------------------------------------------------------------------------------------
          public static string GetHumanFriendlyTimeString(TimeSpan tSpan, bool shortstring)
          {
                //string.Format("{0:D2}m:{1:D2}s", Convert.ToInt32(t.TotalMinutes - 1), t.Seconds

               string timestring = "";
               if (tSpan.Hours == 0 && tSpan.Minutes == 0)
               {
                    if (shortstring)
                         return tSpan.Seconds.ToString() + "s";
                    else
                         return tSpan.Seconds.ToString() + " second(s)";
               }
               else if (tSpan.Hours < 1 && tSpan.Minutes > 0)
               {
                    timestring = tSpan.Minutes.ToString();
                    if (shortstring)
                         timestring = tSpan.Minutes.ToString() + "m:" + tSpan.Seconds.ToString() + "s";
                    else
                         timestring = tSpan.Minutes.ToString() + " minute(s)";
               }
               else if (tSpan.Hours > 0)
               {
                    timestring = tSpan.Hours + " hour(s) ";
                    if (tSpan.Minutes > 0)
                    {
                         timestring += tSpan.Minutes + " minute(s)";
                    }
               }
               return timestring;
          }
          
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// Converts an Olson time zone ID to a Windows time zone ID.
          /// </summary>
          /// <param name="olsonTimeZoneId">An Olson time zone ID. See http://unicode.org/repos/cldr-tmp/trunk/diff/supplemental/zone_tzid.html. </param>
          /// <returns>
          /// The TimeZoneInfo corresponding to the Olson time zone ID, 
          /// or null if you passed in an invalid Olson time zone ID.
          /// </returns>
          /// <remarks>
          /// See http://unicode.org/repos/cldr-tmp/trunk/diff/supplemental/zone_tzid.html
          /// </remarks>
          public static TimeZoneInfo OlsonTimeZoneToTimeZoneInfo(string olsonTimeZoneId)
          {
               var olsonWindowsTimes = new Dictionary<string, string>()
              {
                  { "Africa/Cairo", "Egypt Standard Time" },
                  { "Africa/Casablanca", "Morocco Standard Time" },
                  { "Africa/Johannesburg", "South Africa Standard Time" },
                  { "Africa/Lagos", "W. Central Africa Standard Time" },
                  { "Africa/Nairobi", "E. Africa Standard Time" },
                  { "Africa/Windhoek", "Namibia Standard Time" },
                  { "America/Anchorage", "Alaskan Standard Time" },
                  { "America/Asuncion", "Paraguay Standard Time" },
                  { "America/Bogota", "SA Pacific Standard Time" },
                  { "America/Buenos_Aires", "Argentina Standard Time" },
                  { "America/Caracas", "Venezuela Standard Time" },
                  { "America/Cayenne", "SA Eastern Standard Time" },
                  { "America/Chicago", "Central Standard Time" },
                  { "America/Chihuahua", "Mountain Standard Time (Mexico)" },
                  { "America/Cuiaba", "Central Brazilian Standard Time" },
                  { "America/Denver", "Mountain Standard Time" },
                  { "America/Godthab", "Greenland Standard Time" },
                  { "America/Guatemala", "Central America Standard Time" },
                  { "America/Halifax", "Atlantic Standard Time" },
                  { "America/Indianapolis", "US Eastern Standard Time" },
                  { "America/La_Paz", "SA Western Standard Time" },
                  { "America/Los_Angeles", "Pacific Standard Time" },
                  { "America/Mexico_City", "Mexico Standard Time" },
                  { "America/Montevideo", "Montevideo Standard Time" },
                  { "America/New_York", "Eastern Standard Time" },
                  { "America/Phoenix", "US Mountain Standard Time" },
                  { "America/Regina", "Canada Central Standard Time" },
                  { "America/Santa_Isabel", "Pacific Standard Time (Mexico)" },
                  { "America/Santiago", "Pacific SA Standard Time" },
                  { "America/Sao_Paulo", "E. South America Standard Time" },
                  { "America/St_Johns", "Newfoundland Standard Time" },
                  { "Asia/Almaty", "Central Asia Standard Time" },
                  { "Asia/Amman", "Jordan Standard Time" },
                  { "Asia/Baghdad", "Arabic Standard Time" },
                  { "Asia/Baku", "Azerbaijan Standard Time" },
                  { "Asia/Bangkok", "SE Asia Standard Time" },
                  { "Asia/Beirut", "Middle East Standard Time" },
                  { "Asia/Calcutta", "India Standard Time" },
                  { "Asia/Colombo", "Sri Lanka Standard Time" },
                  { "Asia/Damascus", "Syria Standard Time" },
                  { "Asia/Dhaka", "Bangladesh Standard Time" },
                  { "Asia/Dubai", "Arabian Standard Time" },
                  { "Asia/Irkutsk", "North Asia East Standard Time" },
                  { "Asia/Jerusalem", "Israel Standard Time" },
                  { "Asia/Kabul", "Afghanistan Standard Time" },
                  { "Asia/Kamchatka", "Kamchatka Standard Time" },
                  { "Asia/Karachi", "Pakistan Standard Time" },
                  { "Asia/Katmandu", "Nepal Standard Time" },
                  { "Asia/Krasnoyarsk", "North Asia Standard Time" },
                  { "Asia/Magadan", "Magadan Standard Time" },
                  { "Asia/Novosibirsk", "N. Central Asia Standard Time" },
                  { "Asia/Rangoon", "Myanmar Standard Time" },
                  { "Asia/Riyadh", "Arab Standard Time" },
                  { "Asia/Seoul", "Korea Standard Time" },
                  { "Asia/Shanghai", "China Standard Time" },
                  { "Asia/Singapore", "Singapore Standard Time" },
                  { "Asia/Taipei", "Taipei Standard Time" },
                  { "Asia/Tashkent", "West Asia Standard Time" },
                  { "Asia/Tbilisi", "Georgian Standard Time" },
                  { "Asia/Tehran", "Iran Standard Time" },
                  { "Asia/Tokyo", "Tokyo Standard Time" },
                  { "Asia/Ulaanbaatar", "Ulaanbaatar Standard Time" },
                  { "Asia/Vladivostok", "Vladivostok Standard Time" },
                  { "Asia/Yakutsk", "Yakutsk Standard Time" },
                  { "Asia/Yekaterinburg", "Ekaterinburg Standard Time" },
                  { "Asia/Yerevan", "Armenian Standard Time" },
                  { "Atlantic/Azores", "Azores Standard Time" },
                  { "Atlantic/Cape_Verde", "Cape Verde Standard Time" },
                  { "Atlantic/Reykjavik", "Greenwich Standard Time" },
                  { "Australia/Adelaide", "Cen. Australia Standard Time" },
                  { "Australia/Brisbane", "E. Australia Standard Time" },
                  { "Australia/Darwin", "AUS Central Standard Time" },
                  { "Australia/Hobart", "Tasmania Standard Time" },
                  { "Australia/Perth", "W. Australia Standard Time" },
                  { "Australia/Sydney", "AUS Eastern Standard Time" },
                  { "Etc/GMT", "UTC" },
                  { "Etc/GMT+11", "UTC-11" },
                  { "Etc/GMT+12", "Dateline Standard Time" },
                  { "Etc/GMT+2", "UTC-02" },
                  { "Etc/GMT-12", "UTC+12" },
                  { "Europe/Berlin", "W. Europe Standard Time" },
                  { "Europe/Budapest", "Central Europe Standard Time" },
                  { "Europe/Istanbul", "GTB Standard Time" },
                  { "Europe/Kiev", "FLE Standard Time" },
                  { "Europe/London", "GMT Standard Time" },
                  { "Europe/Minsk", "E. Europe Standard Time" },
                  { "Europe/Moscow", "Russian Standard Time" },
                  { "Europe/Paris", "Romance Standard Time" },
                  { "Europe/Warsaw", "Central European Standard Time" },
                  { "Indian/Mauritius", "Mauritius Standard Time" },
                  { "Pacific/Apia", "Samoa Standard Time" },
                  { "Pacific/Auckland", "New Zealand Standard Time" },
                  { "Pacific/Fiji", "Fiji Standard Time" },
                  { "Pacific/Guadalcanal", "Central Pacific Standard Time" },
                  { "Pacific/Honolulu", "Hawaiian Standard Time" },
                  { "Pacific/Port_Moresby", "West Pacific Standard Time" },
                  { "Pacific/Tongatapu", "Tonga Standard Time" }
              };

               var windowsTimeZoneId = default(string);
               var windowsTimeZone = default(TimeZoneInfo);
               if (olsonWindowsTimes.TryGetValue(olsonTimeZoneId, out windowsTimeZoneId))
               {
                    try { windowsTimeZone = TimeZoneInfo.FindSystemTimeZoneById(windowsTimeZoneId); }
                    catch (TimeZoneNotFoundException) { }
                    catch (InvalidTimeZoneException) { }
               }
               return windowsTimeZone;
          }
//-------------------------------------------------------------------------------------------
     }
}

////-------------------------------------------------------------------------------------------
//          /// <summary>
//          /// Given Unix Timestamp, get DateTime
//          /// </summary>
//          /// <param name="secFromEpoch"></param>
//          /// <returns>DateTime</returns>
//          //public static DateTime GetDate_FromEpoch(JObject obj, string property, DateTime defaultvalue)
//          //{
//          //     try
//          //     {
//          //          long secFromEpoch = 0;
//          //          #if VS2005
//          //               secFromEpoch = obj[property].Value<long>(obj["Id"]);
//          //          #else
//          //               secFromEpoch = obj[property].Value<long>();
//          //          #endif
//          //          return JAN_01_1970.AddSeconds(secFromEpoch).ToLocalTime();
//          //     }
//          //     catch
//          //     {
//          //          return defaultvalue;
//          //     }

//          //}
////-------------------------------------------------------------------------------------------
//          public string ConvertDateTimetoLexico(DateTime datetime)
//          {
//               return datetime.Year.ToString("D4") + "/" + datetime.Month.ToString("D2") + "/" + datetime.Day.ToString("D2") + " " + datetime.Hour.ToString("D2") + ":" + datetime.Minute.ToString("D2") + ":" + datetime.Second.ToString("D2") + " +0000";
//          }
////-------------------------------------------------------------------------------------------
//          public static long SecondsFromEpoch(DateTime date)
//          {
//               if (date.Year == 1)
//                    return 0;
//               DateTime dt = date.ToUniversalTime();
//               TimeSpan ts = dt.Subtract(JAN_01_1970);
//               return (long)ts.TotalSeconds;
//          }