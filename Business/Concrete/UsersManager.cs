using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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
    public class UsersManager : IUsersService
    {
        IUsersDal _users;
        public UsersManager(IUsersDal users)
        {
            _users = users;
        }
        public IResult Add(User user)
        {
            _users.Add(user);
            return new SuccessResult(Messages.UsersAdded);
        }

        public IResult Delete(User user)
        {
            _users.Delete(user);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_users.GetAll());
        }

        public IResult Update(User user)
        {
            _users.Update(user);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
