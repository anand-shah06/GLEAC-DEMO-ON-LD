using Gleac.Anand.Levenshtein.Distance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gleac.Anand.Web.App.Levenshtein.Distance.Models
{
    public class LevenshteinDistanceViewModel
    {
        public StringsViewModel StringsAsCriteria { get; set; }
        public LevenshteinResultTableViewModel ResultTable { get; set; }
    }
}
