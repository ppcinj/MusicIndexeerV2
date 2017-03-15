using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Shell;

namespace MusicIndexeerV2.File
{
    public class ShellFileProvider : IShellFileProvider
    {
        public ShellFile FromPath(string path)
        {
            return ShellFile.FromFilePath(path);
        }
    }
}
