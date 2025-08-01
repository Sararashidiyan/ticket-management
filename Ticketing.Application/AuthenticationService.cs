using Ticketing.Application.Contract.Authentication.DTOs;
using Ticketing.Application.Contract.Authentication.Services;
using Ticketing.Application.Mappers;
using Ticketing.Core.Exceptions;
using Ticketing.Domain.Entities.Users;

namespace Ticketing.Application
{
    public class AuthenticationService(IUserRepository _repository) : IAuthenticationService
    {
        public async Task AdminRegister(RegisterDTO item)
        {
            CheckPassword(item.Password, item.ConfirmPassword);
            await CheckUserAlreadyExist(item);
            var newUser = User.CreateAdmin(item.FullName, item.Email, item.Password);
            await _repository.CreateAsync(newUser);
        }
        public async Task EmployeeRegister(RegisterDTO item)
        {
            CheckPassword(item.Password, item.ConfirmPassword);
            await CheckUserAlreadyExist(item);
            var newUser = User.CreateEmployee(item.FullName, item.Email, item.Password);
            await _repository.CreateAsync(newUser);
        }
        public async Task<UserDTO> Authenticate(string email, string password)
        {
            var user = await _repository.GetByEmailAndPassword(email, password);
            if (user == null)
                throw new UnauthorizedException();
            return UserMappers.Map(user);
        }
        private async Task CheckUserAlreadyExist(RegisterDTO item)
        {
            var user = await _repository.GetByEmail(item.Email);
            if (user == null) throw new UserAlreadyExistException();
        }

        private void CheckPassword(string password, string confirmPassword)
        {
            if (!password.Equals(confirmPassword))
                throw new PasswordsDoNotMatchException();
        }

    }
}
