using System.IO;
using Newtonsoft.Json;

namespace MusicIndexeerV2.Config
{
    public class ConfigurationFileProvider : IConfigurationFileProvider
    {
        private const string Path = "config.json";

        public void Write(Configuration cfg)
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(cfg));
        }

        public Configuration Get()
        {
            return !File.Exists(Path) ? new Configuration() : JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(Path));
        }
    }
}
