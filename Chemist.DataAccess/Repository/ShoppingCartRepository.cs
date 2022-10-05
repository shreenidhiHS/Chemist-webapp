using Chemist.DataAccess.Repository.IRepository;
using Chemist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemist.DataAccess.Repository
{
    public class ShopingCartRepository : Repository<ShopingCart>, IShopingCartRepository
    {
        private ApplicationDbContext _db;
        public ShopingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(ShopingCart shopingCart, int count)
        {
            shopingCart.Count -= count;
            return shopingCart.Count;
        }

        public int IncrementCount(ShopingCart shopingCart, int count)
        {
            shopingCart.Count += count;
            return shopingCart.Count;
        }
    }
}
