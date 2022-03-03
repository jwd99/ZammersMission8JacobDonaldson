using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zammers.Models
{
    public interface ICheckoutRepo
    {

        IQueryable<checkoutInfo> CheckoutInfos { get; }

        void SaveOrder(checkoutInfo checkout);
    }
}
