using Kardex.API.Contracts.Requests.Create;
using Kardex.API.Contracts.Requests.Edit;
using Kardex.API.Contracts.Requests.Update;
using Kardex.API.DataTransferObjects;
using Kardex.API.Models;

namespace Kardex.API.ExtensionMethods.UserExtensionMethods
{
    public static class UserExtensionMethods
    {
        public static UserDTO ConvertCreateContractToUser(this UserCreateRequest contract)
        {
            var user = new UserDTO
            {
                Name = contract.Name,
                Email = contract.Email,
                Password = contract.Password,
                Icon = contract.Icon
            };

            return user;
        }

        public static UserDTO ConvertUpdateContractToUser(this UserUpdateRequest contract)
        {
            return new UserDTO();
        }
    }
}
