using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBall.Model
{
    public class Club
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<FootBallPlayer> Players { get; set; }
    }
}
