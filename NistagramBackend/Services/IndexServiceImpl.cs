using NistagramBackend.Services.Intefrace;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using NistagramUtils.DTO;
using System.Collections.Generic;

namespace NistagramBackend.Services
{
    public class IndexServiceImpl : IIndexService
    {
        private readonly IUserService _userService;

        public IndexServiceImpl(IUserService userService)
        {
            _userService = userService;
        }

        public List<UserDto> GetAllUsers()
        {
            List<User> users = _userService.FindUser(0, null, null);
            return users.ConvertAll(x => new UserDto(x));
        }

    }
}
