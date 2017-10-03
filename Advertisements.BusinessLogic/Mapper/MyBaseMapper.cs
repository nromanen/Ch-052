using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
namespace Advertisements.BusinessLogic.Mapper
{
    public abstract class MyBaseMapper : IMappingProvider
    {
        public IEntity Map(IDTO input)
        {
            object result = GetEntity(input);
            return (IEntity)result;
        }

        public IDTO Map(IEntity input) 
        {
            object result = this.GetDTO(input);
            return (IDTO)result;
        }

        public IEnumerable<IEntity> MapCollection(IEnumerable<IDTO> input)
        {
            List<IEntity> result = new List<IEntity>();

            foreach (IDTO dto in input)
            {
                result.Add(this.GetEntity(dto));
            }
            return result;
        }

        public IEnumerable<IDTO> MapCollection(IEnumerable<IEntity> input)
        {
            List<IDTO> result = new List<IDTO>();

            foreach (IEntity entity in input)
            {
                result.Add(this.Map(entity));
            }
            return result;
        }

        protected abstract IDTO GetDTO(IEntity input);       
        protected abstract IEntity GetEntity(IDTO dto);
        
    }
}
