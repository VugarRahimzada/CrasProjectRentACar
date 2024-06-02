using CoreLayer.DataAccess.Abstract;
using EntityLayer.Concrete.TableModels;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface ICarDal :IBaseRepository<Car>
    {
        IEnumerable<Car> GetAllWithPart(Expression<Func<Car,bool>>? filter = null);
        bool PartIdChecker(Car car);
        public void CarRented(Car car);
    }
}
