using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.File;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        IFileService _fileService;
        public CarImagesManager(ICarImagesDal carImagesDal, IFileService fileService)
        {
            _carImagesDal = carImagesDal;
            _fileService = fileService;
        }

        public IResult Add(CarImages carImages, string path)
        {
            BusinessRules.Run(ChecekIfCarImagesLimited(carImages.Id));
            carImages.ImagePath = _fileService.UploadWithGuid(path, Messages.Images).Message;
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccessResult();
        }

        public IResult Delete(CarImages carImages)
        {
            _fileService.Delete(carImages.ImagePath);
            _carImagesDal.Delete(carImages);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            if (_carImagesDal.GetAll().Count == 0)
            {
                return new ErrorDataResult<List<CarImages>>();
            }
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(c => c.CarId == carId));
        }

        public IResult Update(int carImageId, string path)
        {
            var carImage = _carImagesDal.Get(c => c.Id == carImageId);
            var fileName = carImage.ImagePath;
            _fileService.Delete(Messages.Images + fileName);
            _fileService.Upload(path, Messages.Images, fileName);
            return new SuccessResult();
        }

        private IResult ChecekIfCarImagesLimited(int carImagesId)
        {
            var result = _carImagesDal.GetAll(c => c.Id == carImagesId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
