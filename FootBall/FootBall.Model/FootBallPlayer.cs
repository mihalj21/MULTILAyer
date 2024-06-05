using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBall.Model
{
    public class FootBallPlayer
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }
        public Guid? ClubId { get; set; }

        public bool IsActive { get; set; } 
    }
}
