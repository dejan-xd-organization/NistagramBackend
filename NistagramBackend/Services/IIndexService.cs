using NistagramUtils.DTO;
using System.Collections.Generic;

namespace NistagramBackend.Services.Intefrace
{
    public interface IIndexService
    {
        List<UserDto> GetAllUsers();
    }
}
