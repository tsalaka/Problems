using System;
namespace LeetCode.Graphs
{
    //323
    //find amount of connected components in undirected graph
    public class ConnectedComponents
    {
        private int[] _connectedComponents;
        private bool[] _markedVertices;
        int _count = 0;

        public int GetConnectedComponentsAmount(Graph graph)
        {
            _connectedComponents = new int[graph.VerticesCount];
            _markedVertices = new bool[graph.VerticesCount];

            for (int i = 0; i < graph.VerticesCount; i++)
            {
                if (!_markedVertices[i])
                {
                    DepthFirstSearch(graph, i);
                    _count++;
                }
            }
            return _count;
        }

        private void DepthFirstSearch(Graph graph, int v){
            _markedVertices[v] = true;
            _connectedComponents[v] = _count;
            foreach(var w in graph.Adjecents(v))
            {
                if(!_markedVertices[w])
                {
                    DepthFirstSearch(graph, w);
                }
            }
        }
    }
}
