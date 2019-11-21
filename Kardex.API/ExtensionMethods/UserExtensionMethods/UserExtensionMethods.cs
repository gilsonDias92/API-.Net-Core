using Kardex.API.Contracts.Requests.Create;
using Kardex.API.Contracts.Requests.Edit;
using Kardex.API.Contracts.Requests.Update;
using Kardex.API.Models;

namespace Kardex.API.ExtensionMethods.UserExtensionMethods
{
    public static class UserExtensionMethods
    {
        public static User ConvertCreateContractToUser(this UserCreateRequest contract)
        {
            var user = new User
            {
                Name = contract.Name,
                Email = contract.Email,
                Password = contract.Password
            };
            return user;
        }

        public static User ConvertUpdateContractToUser(this UserUpdateRequest contract)
        {
            return new User();
        }
    }
}
