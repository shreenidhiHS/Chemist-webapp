using BulkuBook.DataAccess.Repository.IRepository;
using Chemist.DataAccess;
using Chemist.DataAccess.Repository;
using Chemist.DataAccess.Repository.IRepository;

namespace BulkuBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            ChemType = new ChemTypeRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ShopingCart = new ShopingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            
        }
        public ICategoryRepository Category { get; private set; }
        public IChemTypeRepository ChemType { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IShopingCartRepository ShopingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; } 
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
      

        public void save()
        {
            _db.SaveChanges();

        }
    }
}
