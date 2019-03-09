namespace Core
{
    public interface IMapper<in TFrom, out TTo>
    {
        TTo Map(TFrom source);
    }
}