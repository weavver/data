using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace Weavver.Utilities
{
//-------------------------------------------------------------------------------------------
     public class AudioUtility
     {
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// Works with the Windows and Linux versions of sox.
          /// </summary>
          /// <param name="fileName"></param>
          /// <returns>audio length in seconds </returns>
          public static decimal GetAudioLength(string filePath)
          {
               string soxpath = "sox";
               if (Common.Windows)
                    soxpath = ConfigurationManager.AppSettings["sox_path"];
               string args = "\"" + filePath + "\" -n stat";
               Process command = new Process();
               command.StartInfo.FileName = soxpath;
               command.StartInfo.Arguments = args;
               command.StartInfo.RedirectStandardError = true;
               command.StartInfo.RedirectStandardInput = true;
               command.StartInfo.RedirectStandardOutput = true;
               command.StartInfo.UseShellExecute = false;
               command.StartInfo.ErrorDialog = false;
               bool started = command.Start();
               if (started)
               {
                    command.WaitForExit(1000);
                    string output = command.StandardOutput.ReadToEnd();
                    string outputerror = command.StandardError.ReadToEnd();
                    //Console.WriteLine("StandardOutput: " + output);
                    //Console.WriteLine("StandardError: " + outputerror);
                    output = outputerror;
                    output = output.Substring(output.IndexOf("Length (seconds):") + 17);
                    output = output.Substring(0, output.IndexOf("\n")).Trim();
                    Console.Write("Detected audio length: " + output.ToString());
                    decimal len = Decimal.Parse(output);
                    Console.WriteLine(" - " + len.ToString());
                    return len;
               }
               else
               {
                    return 0;
               }
          }
//-------------------------------------------------------------------------------------------
          public static bool ConvertWAVtoMP3(string pathA, string pathB)
          {
               Process checkGSM                          = new Process();
               checkGSM.StartInfo.FileName               = "sox";
               checkGSM.StartInfo.Arguments              = pathA + " -V 1";
               checkGSM.StartInfo.RedirectStandardError  = true;
               checkGSM.StartInfo.RedirectStandardOutput = true;
               checkGSM.StartInfo.UseShellExecute        = false;
               checkGSM.Start();

               while (!checkGSM.HasExited);

               Console.WriteLine("Exit code for checkGSM was: " + checkGSM.ExitCode);
               // we are expecting a bad error code because this command is a sort of hack..
               if (checkGSM.ExitCode != 2)
                    return false;

               string output = checkGSM.StandardOutput.ReadToEnd() + "\r\n---\r\n" + checkGSM.StandardError.ReadToEnd();
               Console.WriteLine("Output from checkGSM: " + output + "\r\n");
               if (!output.Contains("GSM"))
               {
                    File.Move(pathA, pathB);
                    return true;
               }
               if (File.Exists(pathB))
               {
                    Console.WriteLine("Converted version of file was already on hard drive? Deleting it now and reconverting..");
                    File.Delete(pathB);
               }

               Process convertFile = new Process();
               convertFile.StartInfo.FileName = "/usr/local/bin/sox";
               convertFile.StartInfo.Arguments = pathA + " " + pathB;
               convertFile.StartInfo.RedirectStandardError = true;
               convertFile.StartInfo.RedirectStandardOutput = true;
               convertFile.StartInfo.UseShellExecute = false;
               convertFile.Start();

               while (!convertFile.HasExited);

               return (convertFile.ExitCode == 0);
          }
     }
//-------------------------------------------------------------------------------------------
}
