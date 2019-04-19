using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace dnTester.Lib.UnpackerTester
{
    public class UnpackerTester
    {
        public static bool UnpackerTest(string filePath)
        {
            var fileStream = File.OpenRead(filePath);
            if (fileStream.Length == 0)
                throw new ArgumentOutOfRangeException("FileStream is null!");
            var reader = new PEReader(fileStream);
            if (reader.HasMetadata != true)
                throw new Exception(".NET Metadata not found!");

            var metadataReader = reader.GetMetadataReader();

            //https://stackoverflow.com/questions/50308931/can-i-access-method-bodies-e-g-il-byte-array-using-assembly-trygetrawmetadata
            bool flag = true;
            foreach (var methodDefinitionHandle in metadataReader.MethodDefinitions)
            {
                var methodDefinition = metadataReader.GetMethodDefinition(methodDefinitionHandle);
                var methodRVA = methodDefinition.RelativeVirtualAddress;
                if (methodRVA == 0) // RVA is 0
                {
                    return flag;
                }
                var body = reader.GetMethodBody(methodRVA);
                var ilBytes = body.GetILBytes();
                foreach (var ilByte in ilBytes)
                {
                    if (ilByte == 0x72) // ldstr 0x72
                    {
                        flag = false;
                        return flag;
                    }
                }
            }
            return flag;
        }
    }
}

