using System;

namespace Gleac.Anand.Levenshtein.Distance
{
    public static class StringDistance
    {
        /// <summary>
        /// Returns the distance/cost.
        /// </summary>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        public static int GetLevenshteinDistance(string firstString, string secondString)
        {
            int n = firstString.Length;
            int m = secondString.Length;
            int[,] arrCompute = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; arrCompute[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; arrCompute[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (secondString[j - 1] == firstString[i - 1]) ? 0 : 1;

                    // Step 6
                    arrCompute[i, j] = Math.Min(
                        Math.Min(arrCompute[i - 1, j] + 1, arrCompute[i, j - 1] + 1),
                        arrCompute[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return arrCompute[n, m];
        }

        /// <summary>
        /// Returns an entire array of distances.
        /// </summary>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        public static int[,] GetLevenshteinDistanceMatrix(string firstString, string secondString)
        {
            int n = firstString.Length;
            int m = secondString.Length;
            int[,] arrCompute = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return arrCompute;
            }

            if (m == 0)
            {
                return arrCompute;
            }

            // Step 2
            for (int i = 0; i <= n; arrCompute[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; arrCompute[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (secondString[j - 1] == firstString[i - 1]) ? 0 : 1;

                    // Step 6
                    arrCompute[i, j] = Math.Min(
                        Math.Min(arrCompute[i - 1, j] + 1, arrCompute[i, j - 1] + 1),
                        arrCompute[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return arrCompute;
        }

        /// <summary>
        /// Returns an the object of type LevenshteinDistanceMatrixAndCostResult containing cost, input strings, viz. firstString and secondString; and array of distance.
        /// </summary>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        public static LevenshteinDistanceMatrixAndCostResult GetLevenshteinDistanceMatrixAndCost(string firstString, string secondString)
        {
            int n = firstString.Length;
            int m = secondString.Length;
            int[,] arrCompute = new int[n + 1, m + 1];
            LevenshteinDistanceMatrixAndCostResult levenshteinDistanceMatrixAndCostResult = null;

            // Step 1
            if (n == 0)
            {
                return levenshteinDistanceMatrixAndCostResult;
            }

            if (m == 0)
            {
                return levenshteinDistanceMatrixAndCostResult;
            }

            // Step 2
            for (int i = 0; i <= n; arrCompute[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; arrCompute[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (secondString[j - 1] == firstString[i - 1]) ? 0 : 1;

                    // Step 6
                    arrCompute[i, j] = Math.Min(
                        Math.Min(arrCompute[i - 1, j] + 1, // a deletion
                        arrCompute[i, j - 1] + 1),         // an insertion
                        arrCompute[i - 1, j - 1] + cost);  // a substitution
                }
            }
            // Step 7
            levenshteinDistanceMatrixAndCostResult = new LevenshteinDistanceMatrixAndCostResult { Cost = arrCompute[n, m],
                StringsAsCriteria = new StringsModel {FirstString = firstString, SecondString = secondString },
                MatrixResult = arrCompute
            };            
            // Step 8
            return levenshteinDistanceMatrixAndCostResult;
        }
    }
}
