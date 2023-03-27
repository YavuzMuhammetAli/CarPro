using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<CarImages>> GetCarImageByCarId(int carId);
        IResult Add(CarImages carImages, string path);
        IResult Delete(CarImages carImages);
        IResult Update(int carImageId, string path);
    }
}
