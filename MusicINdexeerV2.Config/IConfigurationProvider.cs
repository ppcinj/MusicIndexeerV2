namespace MusicIndexeerV2.Config
{
    public interface IConfigurationProvider
    {
        Configuration Current { get; set; }
    }
}