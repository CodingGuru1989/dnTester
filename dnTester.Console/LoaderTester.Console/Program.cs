//
// Author:
//   Tianjiao(Wang Genghuang) (https://github.com/Tianjiao)
//
// Copyright (c) 2019 Tianjiao(Wang Genghuang)
//
// Licensed under the MIT license.
//

using Mono.Options;
using System.Collections.Generic;
using dnTester.Lib.LoaderTester;

namespace LoaderTester.Console
{
    class Program
    {

        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to Loader Tester!");

            // show some app description message
            System.Console.WriteLine("Usage: LoaderTester.Console.exe [OPTIONS]+ message");
            System.Console.WriteLine("Test the obfuscated assembly.");
            System.Console.WriteLine("If no message is specified, a help message is shown.");
            System.Console.WriteLine("Source Code: https://github.com/Tianjiao/dnTester");

            // output the options
            System.Console.WriteLine("Options:");


            // these variables will be set when the command line is parsed
            var shouldShowHelp = true;
            var filePath = new List<string>();

            // these are the available options, not that they set the variables
            var options = new OptionSet {
                { "f|filepath=", "the filepath of obfuscated assembly.", f => filePath.Add (f) },
                { "h|help", "show this message and exit", h => shouldShowHelp = h != null },
            };

            List<string> extra;
            try
            {
                // parse the command line
                extra = options.Parse(args);
            }
            catch (OptionException e)
            {
                // output some error message
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try `LoaderTester.Console.exe --help' for more information.");
                return;
            }

            options.WriteOptionDescriptions(System.Console.Out);
            if (filePath != null)
            {
                foreach (var file in filePath)
                {
                    var ifSuccessfulPacked = dnTester.Lib.LoaderTester.LoaderTester.LoaderTest(file);
                    if (ifSuccessfulPacked)
                    {
                        System.Console.WriteLine("Yes, just use it! No problems found.");
                    }
                    else
                    {
                        System.Console.WriteLine("No, think twice before using it!");
                    }
                }
            }


        }
    }
}
