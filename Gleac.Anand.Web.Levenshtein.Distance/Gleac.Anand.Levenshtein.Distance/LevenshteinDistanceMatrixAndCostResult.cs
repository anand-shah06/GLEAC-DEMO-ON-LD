using System;
using System.Collections.Generic;
using System.Text;

namespace Gleac.Anand.Levenshtein.Distance
{
    public class LevenshteinDistanceMatrixAndCostResult
    {
        public int Cost { get; set; }
        public StringsModel StringsAsCriteria { get; set; }
        public int[,] MatrixResult { get; set; }
    }
}
