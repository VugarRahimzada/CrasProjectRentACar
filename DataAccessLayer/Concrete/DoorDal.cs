﻿using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete.TableModels;

namespace DataAccessLayer.Concrete
{
    public class DoorDal : BaseRepository<Door, AppDbContext>, IDoorDal
    {
    }

}