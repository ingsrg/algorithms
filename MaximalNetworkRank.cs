//https://cybergeeksquad.co/2021/07/maximal-network-rank-solution-2.html
using System;
					
public class Program
{
	public static void Main()
	{
		int[,] roads = {{0,1}, {0,3}, {1,2}, {1,3}};
		int[,] roads2 =  {{0,1}, {0,3}, {1,2}, {1,3}, {2,3}, {2,4}};
		int[,] roads3 = {{0,1}, {1,2}, {2,3}, {2,4}, {5,6}, {5,7}};
		
		Console.WriteLine(MaximalNetworkRank(4, roads));
		Console.WriteLine(MaximalNetworkRank(5, roads2));
		Console.WriteLine(MaximalNetworkRank(8, roads3));
		//Console.WriteLine(roads3.GetLength(0));
	}
	
	static int MaximalNetworkRank(int n, int [,] r)
	{
		int[] count = new int[n];
		int[,] direct = new int[n,n];
		
		for(int i=0; i < r.GetLength(0); i++)
		{
			count[r[i,0]]++;	
			count[r[i,1]]++;	
			direct[r[i,0], r[i,1]] = 1;
			direct[r[i,1], r[i,0]] = 1;
		}
		
		int rank = 0;
		for(int i=0; i < n; i++)
		{
			for(int j=i+1; j < n; j++)
			{
				rank = Math.Max(rank, count[i] + count[j] - direct[i,j]);
			}
		}
		return rank;
	}
}
