using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPoe
{
    internal class Recipe
    {
        public string[] NameOfIn { get; set; }
        public int[] QuantOfIn { get; set; }
        public string[] UnitOfIn { get; set; }
        public int NumIn;
        public int NumStep;
        public string[] Steps {get; set; }


    }
}
