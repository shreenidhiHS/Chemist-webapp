using Chemist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemist.DataAccess.Repository.IRepository
{
    public interface IChemTypeRepository: IRepository<ChemType>
    
    {
        void Update(ChemType obj);
    }
}
