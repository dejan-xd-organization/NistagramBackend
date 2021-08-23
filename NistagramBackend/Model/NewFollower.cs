using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NistagramBackend.Model
{
    public class NewFollower
    {
        public long myId { get; set; }
        public long followerId { get; set; }
    }
}
