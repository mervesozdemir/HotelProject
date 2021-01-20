using HotelProject.DataAccess.Abstract;
using HotelProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelProject.DataAccess.Concrete.EntityFramework
{
    public class EfHotelDal: EfRepositoryBase<Hotel, HotelProjectContext>, IHotelDal

    {
    }
}
