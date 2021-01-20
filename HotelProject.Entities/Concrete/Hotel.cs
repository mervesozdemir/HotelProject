using HotelProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelProject.Entities.Concrete
{
    public class Hotel:IEntity
    {
        public int HotelId { get; set; }
        public int Stars { get; set; }
        public string HotelName { get; set; }
        public decimal FeePerNight { get; set; }
        public Hotel()
        {

        }

        public Hotel(int hotelId, int stars, string hotelName, decimal feePerNight)
        {
            HotelId = hotelId;
            Stars = stars;
            HotelName = hotelName;
            FeePerNight = feePerNight;
        }

        public override string ToString()
        {
            return $"{HotelId,-5}{Stars,-5}{HotelName,-20}{FeePerNight,-5}";
        }
    }
}
