using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zammers.Models
{
    public class EFCheckoutRepo : ICheckoutRepo
    {
        private BookstoreContext context;

        public EFCheckoutRepo (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<checkoutInfo> CheckoutInfos => context.CheckoutInfos.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveOrder(checkoutInfo checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Book));

            if(checkout.CheckoutId ==0)
            {
                context.CheckoutInfos.Add(checkout);
            }
            context.SaveChanges();
        }
    }
}
