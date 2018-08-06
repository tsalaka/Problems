using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.BackTracking
{
	/// <summary>
	/// You are playing the following Flip Game with your friend: Given a string that contains only these two characters: + and -, you and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move and therefore the other person will be the winner.
    /// Write a function to determine if the starting player can guarantee a win.
	/// For example, given s = "++++", return true. The starting player can guarantee a win by flipping the middle "++" to become "+--+".
    /// </summary>
    public class FlipGame
    {
		public bool CanWin(string s)
		{
			var memos = new Dictionary<string, bool>();
			return CanWin(s, memos);
		}

		private bool CanWin(string s, Dictionary<string, bool> memos)
		{
			if (memos.ContainsKey(s)) return memos[s];
            
            var i = 0;
            while (i + 1 < s.Length)
			{
				if (s[i] != '+') i++;
				else if (s[i + 1] != '+') i++;
				else
				{
                    var str = new StringBuilder();
                    str.Append(s.Substring(0, i));
                    str.Append("--");
                    str.Append(s.Substring(i + 2, s.Length - (i + 2)));

                    var canWin = !CanWin(str.ToString(), memos); //the another won
                    memos[s] = canWin;

                    if (canWin) return true;

					i++;

				}
			}
			return false;
		}
    }
}
