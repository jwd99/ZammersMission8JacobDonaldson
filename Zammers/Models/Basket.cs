using System.Collections.Generic;
using System.Linq;

namespace Zammers.Models
{
    public class Basket
    {//create new list of line items
        public List<BasketLineItem> Items { get; set; }
        
        public void AddItem (Book bk, int qty)
        {//adds items to line item list with book ids
            BasketLineItem Line = Items
                .Where(b =>b.Book.BookId == bk.BookId)
                .FirstOrDefault();
            if (Line == null)
            {
                Items.Add(new BasketLineItem
                    {//gets the total qty of books
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                Line.Quantity += qty;
            }
          
        }
        public double CalcTotal()
        {//cals total num of books
            double sum = Items.Sum(b => b.Quantity * 25);
            return sum;
        }
    }
    public class BasketLineItem
    {//line item id and quantity
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
