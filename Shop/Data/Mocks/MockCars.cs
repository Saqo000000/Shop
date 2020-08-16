using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categor = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get => new List<Car>
            {
                new Car
                {
                    name="Tesla Model S",shortDesc="Fast car",longtDesc="Beutiful ,fast and very qouet car company of Tesla",
                    price=45000,isFavorite=true,available=true,
                    img="",
                    Category=_categor.AllCategories.FirstOrDefault(x=>x.categoryName=="electric")
                },
                new Car
                {
                    name="Ford Fiesta",shortDesc="Quiet and ...",longtDesc="comfotable car for daily live",
                    price=11000,isFavorite=false,available=true,
                    img="",
                    Category=_categor.AllCategories.Last()
                },
                 new Car
                {
                    name="BMW M3",shortDesc="strang ",longtDesc="comforatable and large car for daily live",
                    price=65000,isFavorite=true,available=true,
                    img="",
                    Category=_categor.AllCategories.Last()
                },
                 new Car
                {
                    name="Mercedes S",shortDesc="comforatable and large",longtDesc="comforatable and large car for daily live",
                    price=40000,isFavorite=false,available=false,
                    img="",
                    Category=_categor.AllCategories.Last()
                },
                 new Car
                {
                    name="Nissan Leaf",shortDesc="quiet and economic ",longtDesc="comforatable and large car for daily live",
                    price=14000,isFavorite=true,available=true,
                    img="",
                    Category=_categor.AllCategories.First()
                }
            };
        }
        public IEnumerable<Car> GetFavCars
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
