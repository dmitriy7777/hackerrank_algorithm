namespace algorithm
{
	using System.Text;
	using System.Security.Cryptography;
	internal class Program
	{
		internal static readonly char[] chars =
		"abcde".ToCharArray();

		internal static readonly char[] charsAll =
		"jabcdefghiklmnopqrstuvwxyz".ToCharArray();

		static void Main(string[] args)
		{
			var REPETITIONS = 20;
			var KEY_SIZE = 10;
			var incomeList = new List<string>();
			var incomeListManual = new List<string>() { "aabbcc", "ab", "dlk", "ldk", "jkh", "aaabbbb", "hkj", "poi"};
			var pairsList = new List<string>();

			//for (int i = 0; i < REPETITIONS; i++)
			//{
			//	var key = GetUniqueKey(KEY_SIZE);
			//	incomeList.Add(key);
			//	Console.WriteLine(key);
			//}

			foreach (var income in incomeListManual) 
			{
				var iterPair = string.Empty;
				foreach (var symb in charsAll) 
				{
					foreach (var incomeSymb in income)
					{						
						if (symb.Equals(incomeSymb))
						{
							var sympContains = false;
							foreach (var pair in pairsList)
							{
								if (pair.Contains(incomeSymb)) 
								{
									sympContains = true;
								}								
							}
							if (!sympContains) 
							{
								iterPair += incomeSymb;
							}							
						}												
					}
				}
				if (!string.IsNullOrEmpty(iterPair) && pairsList.Count()<=1) 
				{
					pairsList.Add(iterPair);
				}				
			}

			foreach (var pair in pairsList)
			{
				Console.WriteLine(pair);
			}


			Console.WriteLine("List has been created");
			Console.ReadLine();
		}

		public static string GetUniqueKey(int size)
		{
			byte[] data = new byte[4 * size];
			using (var crypto = RandomNumberGenerator.Create())
			{
				crypto.GetBytes(data);
			}
			StringBuilder result = new StringBuilder(size);
			for (int i = 0; i < size; i++)
			{
				var rnd = BitConverter.ToUInt32(data, i * 4);
				var idx = rnd % chars.Length;

				result.Append(chars[idx]);
			}

			return result.ToString();
		}	}
}