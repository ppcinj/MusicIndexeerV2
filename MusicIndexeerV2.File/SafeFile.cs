using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicIndexeerV2.File
{
    public class SafeFileProvider : ISafeFileProvider
    {
        public IEnumerable<string> FindAccessableFiles(string path, string filePattern, bool recurse)
        {
            IEnumerable<string> emptyList = new string[0];

            if (System.IO.File.Exists(path))
                return new[] {path};

            if (!Directory.Exists(path))
                return emptyList;

            var topDirectory = new DirectoryInfo(path);

            // Enumerate the files just in the top directory.
            var files = topDirectory.EnumerateFiles(filePattern);
            var filesLength = files.Count();
            var filesList = Enumerable
                .Range(0, filesLength)
                .Select(i =>
                {
                    string filename = null;
                    try
                    {
                        var file = files.ElementAt(i);
                        filename = file.FullName;
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                    catch (InvalidOperationException)
                    {
                        // ran out of entries
                    }
                    return filename;
                })
                .Where(i => null != i);

            if (!recurse)
                return filesList;

            var dirs = topDirectory.EnumerateDirectories("*");
            var dirsLength = dirs.Count();
            var dirsList = Enumerable
                .Range(0, dirsLength)
                .SelectMany(i =>
                {
                    try
                    {
                        var dir = dirs.ElementAt(i);
                        var dirname = dir.FullName;
                        return FindAccessableFiles(dirname, filePattern, recurse);
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                    catch (InvalidOperationException)
                    {
                        // ran out of entries
                    }

                    return emptyList;
                });

            return filesList.Concat(dirsList);
        }
    }
}
