using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;

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
            return new SuccessDataResult<List<User>>(_users.GetAll(), "kullanıcılar listelendi");
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_users.Get(u=> u.Email == email), "maile göre kullanıcı geldi");
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_users.GetClaims(user),"claimsler geldi");
        }

        public IResult Update(User user)
        {
            _users.Update(user);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
