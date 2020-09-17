using System;

namespace Dijkstras_Algorithm_Implementation
{
    class Dijkstras
    {
        static int VERTEX = 9;
        static int INFINITY = int.MaxValue;
        public static void Main(string[] args)
        {
            int[,] graph = new int[,]
            {
                                      { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
            };
            DijkstraCalculation(graph, 0);
        }

        static void Print(int[] distance)
        {
            int v = 0;
            foreach (int dist in distance)
            {
                Console.WriteLine("{0}\t {1}", v++, dist);
            }
        }

        static int MinimumVertex(int[] distance, bool[] processedVertex)
        {
            int min = INFINITY;
            int minIndex = -1;

            for(int i = 0; i < VERTEX; i++)
            {
                if(!processedVertex[i] && distance[i] <= min)
                {
                    min = distance[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }


        static void DijkstraCalculation(int[,] graph, int src)
        {
            int[] distance = new int[VERTEX];
            bool[] processedVertex = new bool[VERTEX];

            for(int i = 0; i < VERTEX;i++)
            {
                distance[i] = INFINITY;
                processedVertex[i] = false;
            }

            distance[src] = 0;

            for(int i = 0; i < VERTEX - 1; i++)
            {
                int u = MinimumVertex(distance, processedVertex);
                processedVertex[u] = true;
                for(int v = 0; v < VERTEX; v++)
                {
                    if (!processedVertex[v] && graph[u, v] != 0 && distance[u] != INFINITY && distance[v] > distance[u] + graph[u, v])
                        distance[v] = distance[u] + graph[u, v];
                }
            }

            Print(distance);
        }

    }
}
