using System.Collections.Generic;

namespace MusicIndexeerV2.File
{
    public interface ISafeFileProvider
    {
        IEnumerable<string> FindAccessableFiles(string path, string filePattern, bool recurse);
    }
}