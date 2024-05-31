using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class CarDal : BaseRepository<Car, AppDbContext>, ICarDal
    {
        private readonly AppDbContext _appDbContext;

        public CarDal(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Car> GetAllWithPart(Expression<Func<Car, bool>>? filter = null)
        {
            var query = from car in _appDbContext.Cars
                   .Include(x => x.Body)
                   .Include(x => x.Brand)
                   .Include(x => x.Door)
                   .Include(x => x.Fuel)
                   .Include(x => x.Transmission)
                        select car;

            return query.ToList();
        }

        public bool PartIdChecker(Car car)
        {
            bool body = _appDbContext.Bodys.Any(x => x.Id == car.Id);
            bool brand = _appDbContext.Brands.Any(x => x.Id == car.Id);
            bool door = _appDbContext.Doors.Any(x => x.Id == car.Id);
            bool fuel = _appDbContext.Fuels.Any(x => x.Id == car.Id);
            bool transmisson = _appDbContext.Transmissions.Any(x => x.Id == car.Id);
            if (body && brand && door && fuel && transmisson)
            {
                return true;
            }
            return false;
        }
    }
}
