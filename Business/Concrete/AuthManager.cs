using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUsersService _usersService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUsersService usersService, ITokenHelper tokenHelper)
        {
            _usersService = usersService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _usersService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken,"access token oluşturuldu");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck =_usersService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Email ile kullanıcı bulunamadı");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Şifre hatalı");
            }
            return new SuccessDataResult<User>("başarılı");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordsalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordsalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordsalt,
                Status = true
            };
            _usersService.Add(user);
            return new SuccessDataResult<User>(user, "register oldu");
        }

        public IResult UserExists(string email)
        {
            if (_usersService.GetByMail(email).Data != null)
            {
                return new ErrorResult("zaten böyle biri var");
            }
            return new SuccessResult("çıkış yapıldı");
        }
    }
}
