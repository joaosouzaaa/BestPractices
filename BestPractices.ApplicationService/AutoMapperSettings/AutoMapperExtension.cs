namespace BestPractices.ApplicationService.AutoMapperSettings
{
    public static class AutoMapperExtension
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperHandler.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperHandler.Mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
