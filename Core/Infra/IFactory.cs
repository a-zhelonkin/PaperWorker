namespace Core
{
    public interface IFactory<out TProduct> where TProduct : class
    {
        TProduct Create();
    }
}