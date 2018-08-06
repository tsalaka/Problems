using System;
using System.Collections.Generic;

namespace LeetCode.Graphs
{
	//Given an array of unique characters arr and a string str, 
    //Implement a function getShortestUniqueSubstring that finds the smallest substring of str containing all 
    //the characters in arr. Return "" (empty string) if such a substring doesn’t exist.
	public class MeshMessager
    {
        private IList<string> RevertPath(Dictionary<string, string> howWeReachNodes, string recipient){
            var res = new List<string>();
            var sender = recipient;
            while(sender != null)
            {
                res.Add(sender);
                sender = howWeReachNodes[sender];
            }

            int i = 0;
            int j = res.Count - 1;
            while(i < j){
                var temp = res[i];
                res[i++] = res[j];
                res[j--] = temp;
            }
            return res;
        }

        public IList<string> GetShortestPathBfs(string sender, string recipient, Dictionary<string, string[]> network)
        {
            var queue = new Queue<string>();
            var howWeReachNodes = new Dictionary<string,string>();

            if (!network.ContainsKey(sender)) return null;
           
            queue.Enqueue(sender);
            howWeReachNodes.Add(sender, null);
            while (queue.Count != 0)
            {
                var person = queue.Dequeue();
                if (network.ContainsKey(person))
                {
                    foreach (var friend in network[person])
                    {
                        if (howWeReachNodes.ContainsKey(friend)) continue;
                        howWeReachNodes.Add(friend, person);
                        if (friend == recipient)
                        {
                            return RevertPath(howWeReachNodes, recipient);
                        }

                        queue.Enqueue(friend);
                    }
                }
            }
            return null;
        }
    }
}
