﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemist.Models.ViewModels
{
    public class ShopingCartVM
    {
        public IEnumerable<ShopingCart> ListCart { get; set; }
        
        public OrderHeader OrderHeader { get; set; }

    }
}
