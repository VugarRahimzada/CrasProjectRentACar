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
    }
}
