using Microsoft.WindowsAPICodePack.Shell;

namespace MusicIndexeerV2.File
{
    public interface IShellFileProvider
    {
        ShellFile FromPath(string path);
    }
}