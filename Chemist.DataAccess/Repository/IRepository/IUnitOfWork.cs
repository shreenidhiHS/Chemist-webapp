using Chemist.DataAccess.Repository.IRepository;

namespace BulkuBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IChemTypeRepository ChemType { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }

        IShopingCartRepository ShopingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderHeaderRepository OrderHeader { get; }

        void save();
    }
}
