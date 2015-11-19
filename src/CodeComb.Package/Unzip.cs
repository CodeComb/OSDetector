using System;
using System.IO;
using System.IO.Compression;

namespace CodeComb.Package
{
    public class Unzip
    {
        public static void ExtractAll(string filePath, string dest, bool deleteAfterExtracted = true)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            using (var archive = new ZipArchive(fileStream))
            {
                foreach (var x in archive.Entries)
                {
                    var path = dest + x.FullName;
                    if (OS.Current != OSType.Windows)
                        path = path.Replace("\\", "/");
                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                    if (x.Length == 0 && string.IsNullOrEmpty(Path.GetExtension(x.FullName)))
                        continue;
                    using (var entryStream = x.Open())
                    using (var destStream = File.OpenWrite(path))
                    {
                        entryStream.CopyTo(destStream);
                    }
                }
            }
            if (deleteAfterExtracted)
                File.Delete(filePath);
        }

        public static void Extract(string filePath, params Tuple<string, string>[] files)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            using (var archive = new ZipArchive(fileStream))
            {
                foreach (var file in files)
                {
                    var entry = archive.GetEntry(file.Item1);
                    if (entry == null)
                        throw new Exception("Could not find file '" + file.Item1 + "'.");

                    Directory.CreateDirectory(Path.GetDirectoryName(file.Item2));

                    using (var entryStream = entry.Open())
                    using (var dllStream = File.OpenWrite(file.Item2))
                    {
                        entryStream.CopyTo(dllStream);
                    }
                }
            }
        }
    }
}