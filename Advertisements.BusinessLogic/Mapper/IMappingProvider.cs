using Advertisements.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.BusinessLogic.Mapper
{
    public interface IMappingProvider
    {
        IEntity Map(IDTO input);
        IDTO Map(IEntity input);
        IEnumerable<IEntity> MapCollection(IEnumerable<IDTO> input);
        IEnumerable<IDTO> MapCollection(IEnumerable<IEntity> input);
    }
}
