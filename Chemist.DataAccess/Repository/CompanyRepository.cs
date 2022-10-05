using Chemist.DataAccess.Repository.IRepository;
using Chemist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemist.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save()
        {
            _db.SaveChanges();

        }
        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
