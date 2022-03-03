﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zammers.Models
{
    public class Basket
    {//create new list of line items
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        
        public virtual void AddItem (Book bk, int qty)
        {//adds items to line item list with book ids
            BasketLineItem Line = Items
                .Where(b =>b.Book.BookId == bk.BookId)
                .FirstOrDefault();
            if (Line == null)
            {
                Items.Add(new BasketLineItem
                    {//gets the total qty of books
                    Book = bk,
                    Quantity = qty,
                    SubTotal = bk.Price
                });
            }
            else
            {
                Line.Quantity += qty;
                Line.SubTotal += bk.Price;
            }
        
       
        }

        public virtual void RemoveItem (Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }
        public double CalcTotal()
            {//cals total num of books
                double sum = Items.Sum(b => b.Total += b.SubTotal);
                return sum;
            }
 
    }
    public class BasketLineItem
    {//line item id and quantity
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
    }
}
