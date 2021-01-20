using HotelProject.BusinessLogicLayer.Abstract;
using HotelProject.DataAccess.Abstract;
using HotelProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HotelProject.BusinessLogicLayer.Concrete
{
    public class HotelManager : IHotelService
    {
        IHotelDal _hotelDal;

        public HotelManager(IHotelDal hotelDal)
        {
            _hotelDal = hotelDal;
        }

        public void Add(Hotel entity)
        {
            _hotelDal.Add(entity);
        }

        public void Delete(Hotel entity)
        {
            _hotelDal.Delete(entity);
        }

        public Hotel Get(Expression<Func<Hotel, bool>> filter)
        {
            return _hotelDal.Get(filter);
        }

        public List<Hotel> GetAll(Expression<Func<Hotel, bool>> filter = null)
        {
            return _hotelDal.GetAll(filter);
        }

        public void Update(Hotel entity)
        {
            _hotelDal.Update(entity);
        }
    }
}
