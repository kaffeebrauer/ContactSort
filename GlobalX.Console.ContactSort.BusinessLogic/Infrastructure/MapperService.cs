using AutoMapper;

namespace GlobalX.Console.ContactSort.BusinessLogic.Infrastructure
{
    public class MapperService : IMapperService
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            Mapper.CreateMap<TSource, TDestination>();
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}
