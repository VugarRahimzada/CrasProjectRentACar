using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class BookingDal : BaseRepository<Booking, AppDbContext>, IBookingDal
    {
        private readonly AppDbContext _appDbContext;

        public BookingDal(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Booking> GetAllWithCar()
        {
            return _appDbContext.Bookings.Where(x => x.Delete == 0).Include(x => x.Car).ToList();
        }

        public void ConfirmationbyId(int Id)
        {
            var value = _appDbContext.Bookings.FirstOrDefault(x => x.Id == Id);

            if (value.IsTaked == false)
            {
                value.IsTaked = true;
                _appDbContext.SaveChanges();
            }
        }

        public void ConfirmationAll()
        {

            var value = _appDbContext.Bookings.Where(x => x.IsTaked == false);

            foreach (var item in value)
            {
                item.IsTaked = true;
            }
            _appDbContext.SaveChanges(true);
        }

        public IEnumerable<Booking> GetAllWaitingWithCar()
        {
            var value = _appDbContext.Bookings.Where(x=>x.IsTaked == false).Include(x=>x.Car).ToList();
            return value;
        }
    }
}
