using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianCansusAnalyser
{
    public  class IndianStateCodeAnalyser
    {
        string SrNo;
        string StateName;
        string TIN;
        string StateCode;
        public IndianStateCodeAnalyser(string SrNo, string StateName, string TIN, string StateCode)
        {
            this.SrNo = SrNo;
            this.StateName = StateName;
            this.TIN = TIN;
            this.StateCode = StateCode;
        }

    }
}
