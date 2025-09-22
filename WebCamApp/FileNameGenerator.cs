
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebCamApp
{
    public class FileNameGenerator
    {
        private static Dictionary<string, int> counters = new Dictionary<string, int>();

        public static string GenerateFileName(string pattern, string extension, string counterType = "default")
        {
            if (string.IsNullOrEmpty(pattern))
            {
                pattern = "file_{datetime}";
            }

            if (!extension.StartsWith(".") && !string.IsNullOrEmpty(extension))
            {
                extension = "." + extension;
            }

            string result = pattern;

            result = result.Replace("{datetime}", DateTime.Now.ToString("yyyy-MM-dd_HHmmss"));

            result = result.Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd"));

            result = result.Replace("{time}", DateTime.Now.ToString("HHmmss"));

            if (result.Contains("{counter}"))
            {
                if (!counters.ContainsKey(counterType))
                {
                    counters[counterType] = 1;
                }

                result = result.Replace("{counter}", counters[counterType].ToString("D4"));
                counters[counterType]++;
            }

            result = SanitizeFileName(result);

            result += extension;

            return result;
        }

        public static void SetCounter(string counterType, int value)
        {
            counters[counterType] = value;
        }

        private static string SanitizeFileName(string fileName)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(fileName, invalidRegStr, "_");
        }

        public static void FindNextCounterFromDirectory(string directory, string pattern, string extension, string counterType)
        {
            if (!Directory.Exists(directory) || !pattern.Contains("{counter}"))
                return;

            try
            {
                if (!extension.StartsWith("."))
                    extension = "." + extension;

                string filePattern = pattern.Replace("{counter}", "(\\d+)");
                filePattern = filePattern.Replace("{datetime}", "\\d{4}-\\d{2}-\\d{2}_\\d{6}");
                filePattern = filePattern.Replace("{date}", "\\d{4}-\\d{2}-\\d{2}");
                filePattern = filePattern.Replace("{time}", "\\d{6}");
                filePattern = SanitizeFileName(filePattern);
                filePattern = "^" + Regex.Escape(filePattern).Replace("\\(\\\\d\\+\\)", "(\\d+)") + Regex.Escape(extension) + "$";

                Regex regex = new Regex(filePattern);
                int highestCounter = 0;

                foreach (string file in Directory.GetFiles(directory))
                {
                    string fileName = Path.GetFileName(file);
                    Match match = regex.Match(fileName);

                    if (match.Success && match.Groups.Count > 1)
                    {
                        if (int.TryParse(match.Groups[1].Value, out int counter))
                        {
                            highestCounter = Math.Max(highestCounter, counter);
                        }
                    }
                }

                SetCounter(counterType, highestCounter + 1);
            }
            catch (Exception)
            {
                SetCounter(counterType, 1);
            }
        }
    }
}

