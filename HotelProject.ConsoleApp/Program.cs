using HotelProject.BusinessLogicLayer.Abstract;
using HotelProject.BusinessLogicLayer.CrossCuttingConcerns.DependencyResolvers.Ninject;
using HotelProject.Entities.Concrete;
using System;

namespace HotelProject.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var hotelService = InstanceFactory.GetInstance<IHotelService>();
            hotelService.Add(new Hotel()
            {
                FeePerNight = 50,
                HotelName = "Lotus",
                Stars = 4
            });
            hotelService.GetAll().ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
        }
    }
}
