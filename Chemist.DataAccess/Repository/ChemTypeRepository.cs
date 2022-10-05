using Chemist.DataAccess.Repository.IRepository;
using Chemist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemist.DataAccess.Repository
{
    public class ChemTypeRepository: Repository<ChemType>, IChemTypeRepository
    {
        private ApplicationDbContext _db;
        public ChemTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save()
        {
            _db.SaveChanges();

        }
        public void Update(ChemType obj)
        {
            _db.ChemTypes.Update(obj);
        }
    }
}
