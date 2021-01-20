using HotelProject.BusinessLogicLayer.Abstract;
using HotelProject.BusinessLogicLayer.Concrete;
using HotelProject.DataAccess.Abstract;
using HotelProject.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelProject.BusinessLogicLayer.CrossCuttingConcerns.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHotelService>().To<HotelManager>().InSingletonScope();
            Bind<IHotelDal>().To<EfHotelDal>().InSingletonScope();
        }
    }
}
