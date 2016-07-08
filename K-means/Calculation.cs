using Accord.MachineLearning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means
{
    class Calculation
    {
        public int[] CalculateKMeans (int clusterNum, double [][] observations)
        {
            // Create a new K-Means algorithm with 3 clusters 
            KMeans kmeans = new KMeans(clusterNum);

            // Compute the algorithm, retrieving an integer array
            //  containing the labels for each of the observations
            int[] labels = kmeans.Compute(observations);
            return labels;
        }
    }
}
