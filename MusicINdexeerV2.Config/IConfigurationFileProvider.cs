namespace MusicIndexeerV2.Config
{
    public interface IConfigurationFileProvider
    {
        Configuration Get();
        void Write(Configuration cfg);
    }
}