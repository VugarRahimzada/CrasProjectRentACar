﻿using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete.TableModels;

namespace DataAccessLayer.Concrete
{
    public class FuelDal : BaseRepository<Fuel, AppDbContext>, IFuelDal
    {
    }

}
