﻿using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;
        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Car> Cars => appDBContent.Cars.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars 
        {
            get => appDBContent.Cars.Where(p => p.isFavorite).Include(c => c.Category);
        }

        public Car GetObjectCar(int carId)
        {
            return appDBContent.Cars.FirstOrDefault(p => p.id == carId);
        }
    }
}
