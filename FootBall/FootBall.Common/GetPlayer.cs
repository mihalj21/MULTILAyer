using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBall.Common
{
    public class GetPlayer
    {
        public Filter filter { get; set; }
        public Sort sort { get; set; }

        public GetPlayer(Filter filter, Sort sort) { 
        
            this.filter = filter;
            this.sort = sort;
         }


    }
}
