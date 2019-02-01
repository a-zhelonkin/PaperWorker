namespace Services.Core
{
    public interface IConfigurationProvider<out TConfiguration> where TConfiguration : class
    {
        TConfiguration Provide();
    }
}