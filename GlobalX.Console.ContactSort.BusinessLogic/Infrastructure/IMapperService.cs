namespace GlobalX.Console.ContactSort.BusinessLogic.Infrastructure
{
    public interface IMapperService
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
