using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBall.Common
{
    public class Filter
    {
       

        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? ClubName { get; set; }

        public Filter(Guid? Id, string? firstName, string? lastName, Guid? ClubName) {

            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ClubName = ClubName;

        }

        
    }
}
