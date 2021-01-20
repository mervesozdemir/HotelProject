using HotelProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HotelProject.BusinessLogicLayer.Abstract
{
    public interface IHotelService
    {
        List<Hotel> GetAll(Expression<Func<Hotel, bool>> filter = null);
        void Add(Hotel entity);
        void Update(Hotel entity);
        void Delete(Hotel entity);
        Hotel Get(Expression<Func<Hotel, bool>> filter);
    }
}
