using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBall.Common
{
    public class Sort
    {
        public string SortBy { get; set; } 
        public string SortOrder { get; set; } 


        public Sort(string sortBy, string sortOrder) {
        
            this.SortBy = sortBy;
            this.SortOrder = sortOrder;
        
        }


    }
}
