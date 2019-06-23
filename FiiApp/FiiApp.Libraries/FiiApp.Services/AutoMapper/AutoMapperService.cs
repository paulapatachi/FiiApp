using AutoMapper;

namespace FiiApp.Services.AutoMapper
{
    public static class AutoMapperService
    {
        public static IMapper GetMapperForTests()
        {
            return new MapperConfiguration(x =>
            {
                x.AddProfile<EntityToDtoProfile>();
            }).CreateMapper();
        }
    }
}
