using System.Collections.Generic;
using NistagramUtils.DTO;

namespace NistagramBackend.Services.Intefrace
{
    public interface IIndexService
    {
        List<UserDto> GetAllUsers();
    }
}
