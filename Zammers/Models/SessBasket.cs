﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Zammers.Infastructure;

namespace Zammers.Models
{
    public class SessBasket : Basket
    {
        public static Basket GetBasket(IServiceProvider services) {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessBasket basket = session?.GetJson<SessBasket>("Basket") ?? new SessBasket();
            basket.Session = session;

            return basket;
                }
        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book bk, int qty)
        {
            base.AddItem(bk, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);
        }
        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
