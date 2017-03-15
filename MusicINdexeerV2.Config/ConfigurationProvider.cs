using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicIndexeerV2.Config
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public Configuration Current
        {
            get { return _configurationFileProvider.Get(); }
            set { _configurationFileProvider.Write(value); }
        }

        private readonly IConfigurationFileProvider _configurationFileProvider;

        public ConfigurationProvider(IConfigurationFileProvider configurationFileProvider)
        {
            _configurationFileProvider = configurationFileProvider;
        }
    }
}
