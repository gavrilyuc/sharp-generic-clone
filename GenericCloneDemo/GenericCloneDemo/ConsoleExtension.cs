using System;
using System.Collections.Generic;

namespace GenericCloneDemo
{
    public static class ConsoleExtension
    {
        private const char ColorSeparator = '^';
        private static readonly Dictionary<char, ConsoleColor> Colors =
            new Dictionary<char, ConsoleColor> {
                { 'r', ConsoleColor.Red },
                { 'w', ConsoleColor.White },
                { 'g', ConsoleColor.Green },
                { 'y', ConsoleColor.Yellow }
            };

        public static void WriteLine(string format, params object[] pd)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            format = string.Format(format, pd);
            format = $"{format}\n";

            int s = -2;
            bool hasWrited = false;
            while ((s = format.IndexOf(ColorSeparator, s + 2)) > -1)
            {
                System.Console.ForegroundColor = Colors[format[s + 1]];

                int end;
                if ((end = format.IndexOf(ColorSeparator, s + 2)) == -1)
                    end = format.Length - (s + 2);
                else end += 1;

                System.Console.Write(format.Substring(s + 2, end));
                hasWrited = true;
            }
            if (!hasWrited)
            {
                System.Console.Write(format);
            }
        }
    }

}