using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Klark_Right.Models
{
    public class Demand
    {
        public int Id { get; set; }

        public int RequirementWeight { get; set; }

        public Demand(int id, int reqReight)
            => (Id, RequirementWeight) = (id, reqReight);
    }

}
