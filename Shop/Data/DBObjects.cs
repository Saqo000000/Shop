using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContext content)
        {
           
            if (!content.Categories.Any())
            {
                content.Categories.AddRange();
            }
            if (!content.Cars.Any())
            {
                content.Cars.AddRange(
                new Car
                {
                    name = "Tesla Model S", shortDesc = "Fast car", longtDesc = "Beutiful ,fast and very qouet car company of Tesla",
                    price = 45000, isFavorite = true, available = true,
                    img = "/img/tesla.webp",
                    Category = Categories["electric"] 
                },
                new Car
                {
                    name = "Ford Fiesta", shortDesc = "Quiet and ...", longtDesc = "comfotable car for daily live",
                    price = 11000, isFavorite = false, available = true,
                    img = "/img/ford.jpg",
                    Category = Categories["classic"]
                },
                    new Car
                    {
                        name = "BMW M3", shortDesc = "strang ", longtDesc = "comforatable and large car for daily live",
                        price = 65000, isFavorite = true, available = true,
                        img = "/img/m3.jpg",
                        Category = Categories["classic"]
                    },
                    new Car
                    {
                        name = "Mercedes S", shortDesc = "comforatable and large", longtDesc = "comforatable and large car for daily live",
                        price = 40000, isFavorite = false, available = false,
                        img = "/img/mercedes.jpeg",
                        Category = Categories["classic"]
                    },
                new Car
                {
                    name = "Nissan Leaf", shortDesc = "quiet and economic ", longtDesc = "comforatable and large car for daily live",
                    price = 14000, isFavorite = true, available = true,
                    img = "/img/nissan.jpg",
                    Category = Categories["electric"]
                }) ;
            }
            content.SaveChanges();
        }
        static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]{
                        new Category { categoryName = "electric", desc = "modern type of mashine" },
                        new Category { categoryName = "classic", desc = "cars with inside fireing engine" } };
                    category = new Dictionary<string, Category>();
                    foreach (var item in list)
                    {
                        category.Add(item.categoryName, item);
                    }
                }
                return category;
            }
        }
    }
}
