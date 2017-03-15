using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell;
using MusicIndexeerV2.Config;

namespace MusicIndexeerV2.File
{
    public class BrowserFacade
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly ISafeFileProvider _safeFileProvider;
        private readonly IShellFileProvider _shellFileProvider;

        public BrowserFacade(IConfigurationProvider configurationProvider,
            ISafeFileProvider safeFileProvider,
            IShellFileProvider shellFileProvider)
        {
            _configurationProvider = configurationProvider;
            _safeFileProvider = safeFileProvider;
            _shellFileProvider = shellFileProvider;
        }

        public void Reload()
        {
            foreach (var path in _configurationProvider.Current.SearchPaths)
            {
                var foundItems = new List<Song>();
                if (!Directory.Exists(path))
                    continue;

                foreach (var file in _safeFileProvider.FindAccessableFiles(path, "*.mp3", true))
                {
                    var newSong = new Song
                    {
                        FilePath = file,
                        FileSizeInBytes = new FileInfo(file).Length
                    };

                    if (_configurationProvider.Current.LoadExtendedInformation)
                    {
                        var shellFile = _shellFileProvider.FromPath(file);
                        var d = shellFile.Properties.System.Media.Duration.Value * 0.0000001;
                        if (d != null)
                            newSong.Duration = TimeSpan.FromSeconds(d.Value);
                    }

                    foundItems.Add(newSong);
                }
            }
        }
    }
}
