using Kardex.API.Contracts.Requests.Create;
using Kardex.API.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.ExtensionMethods.User
{
    public static class UserExtensionMethods
    {
        public static UserDTO ConvertContractToUserDTO(this UserCreateRequest user)
        {
            var userDTO = new UserDTO
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
            return userDTO;
        }
    }
}
