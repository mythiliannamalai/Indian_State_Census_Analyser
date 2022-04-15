using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
namespace IndianCansusAnalyser
{
    public class IndianStateCansusAnalyser
    {
        string state;
        string population;
        string area;
        string density;
        public IndianStateCansusAnalyser(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = population;
            this.area = area;
            this.density = density;
        }
    }
}
