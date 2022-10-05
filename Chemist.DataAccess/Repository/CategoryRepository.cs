using Chemist.DataAccess.Repository.IRepository;
using Chemist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemist.DataAccess.Repository
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save()
        {
            _db.SaveChanges();

        }
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
