﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Models {
    public class ShopCart {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services) {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var contex = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(contex) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car) {
            this.appDBContent.ShopCartItem.Add(new ShopCartItem {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price,
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems() {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }

    }
}
