using CoreLayer.DataAccess.Abstract;
using EntityLayer.Concrete.TableModels;

namespace DataAccessLayer.Abstract
{
    public interface ICarDal :IBaseRepository<Car>
    {
    }
}
