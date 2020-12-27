using EpamTask2.Parsers;
using EpamTask2.TextElements;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EpamTask2.Services
{
    public class IO
    {
        public IO()
        {
            // строитель конфигурации
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    {"inputfile", "text.txt"},
                    {"outputfile", "textOutput.txt"}
                });
            // создаем конфигурацию
            AppConfiguration = builder.Build();

        }
        //private static string inputFileName;
        //private static string outputFileName;
        public static IConfiguration AppConfiguration { get; set; }
        public static string InputFileName { get => AppConfiguration["inputfile"]; } //private set => inputFileName = AppConfiguration["inputfile"]; }
        public static string OutputFileName { get => AppConfiguration["outputfile"]; }//private set => outputFileName = AppConfiguration["outputfile"]; }
        internal static void Output(string filename, Text text)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
        }
        internal static Text Input(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            TextParser textParser = new TextParser();
            return textParser.Parse(sr);
        }
    }
}
