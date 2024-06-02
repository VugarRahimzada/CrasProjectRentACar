using CoreLayer.DataAccess.Abstract;
using EntityLayer.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBookingDal :IBaseRepository<Booking>
    {

        IEnumerable<Booking> GetAllWithCar();
        IEnumerable<Booking> GetAllWaitingWithCar();
        public void ConfirmationbyId(int Id);
        public void ConfirmationAll();


    }
}
