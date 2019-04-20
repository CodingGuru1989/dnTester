//
// Author:
//   Tianjiao(Wang Genghuang) (https://github.com/Tianjiao)
//
// Copyright (c) 2019 Tianjiao(Wang Genghuang)
//
// Licensed under the MIT license.
//

using System.Reflection;

namespace dnTester.Lib.LoaderTester
{
    public class LoaderTester
    {
        public static bool LoaderTest(string filePath)
        {
            var assembly = Assembly.LoadFile(filePath);
            
            foreach (var type in assembly.GetTypes())
            {
                foreach (var method in type.GetMethods())
                {
                    if (method.HasMetadataToken())
                    {
                        var body = method.GetMethodBody();
                        var ilBytes = body.GetILAsByteArray();

                        foreach (var ilByte in ilBytes)
                        {
                            if (ilByte == 0x72) // ldstr 0x72
                            {
                                return false;
                            }
                        }
                    }
                }   
            }
            return true;

        }
    }
}


