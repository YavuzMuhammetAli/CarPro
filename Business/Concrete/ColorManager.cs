using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _color;
        public ColorManager(IColorDal colorDal)
        {
            _color = colorDal;
        }
        public IResult Add(Color color)
        {
            _color.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll());
        }

        public IResult Update(Color color)
        {
            _color.Delete(color);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
