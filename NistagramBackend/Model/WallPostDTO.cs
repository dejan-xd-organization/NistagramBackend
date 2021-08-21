using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NistagramBackend.Model
{
    public class WallPostDTO
    {
        public long id { get; set; }

        public DateTime timePublis { get; set; }

        public string imagePost { get; set; }

        public string postDescription { get; set; }
    }
}
