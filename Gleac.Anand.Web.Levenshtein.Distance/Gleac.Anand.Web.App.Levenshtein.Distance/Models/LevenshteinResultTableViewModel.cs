using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gleac.Anand.Web.App.Levenshtein.Distance.Models
{
    public class LevenshteinResultTableViewModel
    {
        public int Cost { get; set; }
        public int[,] ResultMatrix { get; set; }
    }
}
