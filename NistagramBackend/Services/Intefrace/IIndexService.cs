using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NistagramUtils.DTO;

namespace NistagramBackend.Services.Intefrace
{
    public interface IIndexService
    {
        List<UserDTO> GetAllUsers();
    }
}
