namespace Genius.Services
{
    using AutoMapper;

    public abstract class Service : IService
    {
        protected IMapper mapper;

        public Service(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
