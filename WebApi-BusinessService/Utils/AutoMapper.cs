using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApi_BusinessService.Utils
{
    public class CustomAutoMapper<S,D>
    {
        public D MapModel(S obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<S,D>());
            var mapper =  new Mapper(config);
            return mapper.Map<S,D>(obj);

        }
        public D MapModel(S obj , MapperConfiguration config = null)
        {
            var mapper = new Mapper(config);
            return mapper.Map<S, D>(obj);


        }
        public S MapModelBack(D obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<D, S>());
            var mapper = new Mapper(config);
            return mapper.Map<D,S>(obj);

        }
        public List<S> MapModelLstBack(List<D> obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<D, S>());
            List<S> result = new List<S>();
            obj.ForEach(obj =>
            {
                var mapper = new Mapper(config);
                result.Add(mapper.Map<D,S>(obj));

            });
            return result;


        }

        public List<D> MapModelLst(List<S> obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<S, D>());
            List<D> result = new List<D>();
            obj.ForEach(obj =>
            {
                var mapper = new Mapper(config);
                result.Add(mapper.Map<S, D>(obj));

            });
            return result;
            

        }

    }
}
