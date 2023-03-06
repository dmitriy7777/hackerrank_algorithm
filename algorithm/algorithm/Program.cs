namespace algorithm
{
	using System.Text;
	using System.Security.Cryptography;
	internal class Program
	{
		internal static readonly char[] chars =
		"abcde".ToCharArray();

		internal static readonly char[] charsAll =
		"abcdefghijklmnopqrstuvwxyz".ToCharArray();

		static void Main(string[] args)
		{
			var REPETITIONS = 20;
			var KEY_SIZE = 10;
			var incomeList = new List<string>();
			var incomeListManual = new List<string>() { "aabbcc", "abc", "dlk", "ldk", "jkh", "aaabbbbcc", "hkj", "poi", "llkkdd", "mnv" };
			var pairsList = new List<string>();
			var pairs = 0;

			for (var i = 0; i < incomeListManual.Count - 1; i++) 
			{				
				if (i <= incomeListManual.Count - 1)
				{
					for (var j = i + 1; j < incomeListManual.Count; j++)
					{
						var distString1 = DistinctCharsString(incomeListManual[i]);
						var distString2 = DistinctCharsString(incomeListManual[j]);
						if (CompareTwoStrings(distString1, distString2)) 
						{
							if (!pairsList.Contains(distString1)) 
							{
								Console.WriteLine("---");
								Console.WriteLine("{0} --- {1}", distString1, distString2);
								Console.WriteLine("---");

								pairsList.Add(distString1);
								pairs++;
							}							
						}
					}
				}
			}


			//Console.WriteLine(CompareTwoStrings("aaabccc","bcccabb"));
			//Console.WriteLine("CompareTwoStrings");

			Console.WriteLine("Pairs: {0}", pairs);
			Console.ReadLine();
		}

		public static string DistinctCharsString(string inputString)
		{
			StringBuilder sb = new StringBuilder();
			inputString.Distinct().ToList().ForEach(c => sb.Append(c));
			return sb.ToString();
		}

		public static bool CompareTwoStrings(string firstString, string secondString) 
		{
			char[] charsAll = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
			string resultString = "";

			foreach (var symb in charsAll)
			{
				foreach (var firstStringSymb in firstString)
				{
					if (!secondString.Contains(firstStringSymb))
					{
						return false;
					}

					if (symb.Equals(firstStringSymb))
					{
						foreach (var secondStringSymb in secondString)
						{
							if (!firstString.Contains(secondStringSymb))
							{
								return false;
							}

							if (secondStringSymb.Equals(firstStringSymb) && !resultString.Contains(firstStringSymb))
							{
								resultString += firstStringSymb;
							}						
						}
					}
				}
			}

			return resultString.Length > 0;
		}

		//public static void Comment() 
		//{
		//	var pairsList = new List<string>();

		//	//for (int i = 0; i < REPETITIONS; i++)
		//	//{
		//	//	var key = GetUniqueKey(KEY_SIZE);
		//	//	incomeList.Add(key);
		//	//	Console.WriteLine(key);
		//	//}

		//	string[] incomeListManualArr = new string[incomeListManual.Count];

		//	for (var i = 0; i <= incomeListManual.Count - 1; i++)
		//	{
		//		incomeListManualArr[i] = incomeListManual[i];

		//	}

		//	//string firstString = "aabbcc";
		//	//string secondString = "aabbcc";

		//	string firstString = "aabbccaa";
		//	//string secondString = "cccaaabbb";
		//	string secondString = "njvccc";

		//	string resultString = "";
		//	bool stringsAreEqual = true;
		//	foreach (var symb in charsAll)
		//	{
		//		foreach (var firstStringSymb in firstString)
		//		{
		//			if (symb.Equals(firstStringSymb))
		//			{
		//				foreach (var secondStringSymb in secondString)
		//				{
		//					if (secondStringSymb.Equals(firstStringSymb) && !resultString.Contains(firstStringSymb))
		//					{
		//						resultString += firstStringSymb;
		//					}
		//				}
		//			}
		//		}

		//		//foreach (var income in incomeListManual)
		//		//{
		//		//	var iterPair = string.Empty;
		//		//	foreach (var symb in charsAll)
		//		//	{
		//		//		foreach (var incomeSymb in income)
		//		//		{
		//		//			if (symb.Equals(incomeSymb))
		//		//			{
		//		//				var sympContains = false;
		//		//				foreach (var pair in pairsList)
		//		//				{
		//		//					if (pair.Contains(incomeSymb))
		//		//					{
		//		//						sympContains = true;
		//		//					}
		//		//				}
		//		//				if (!sympContains)
		//		//				{
		//		//					iterPair += incomeSymb;
		//		//				}
		//		//			}
		//		//		}
		//		//	}
		//		//	if (!string.IsNullOrEmpty(iterPair) && pairsList.Count() <= 1)
		//		//	{
		//		//		pairsList.Add(iterPair);
		//		//	}
		//		//}

		//		//foreach (var pair in pairsList)
		//		//{
		//		//	Console.WriteLine(pair);
		//		//}


		//	}

		//	resultString = "";
		//	firstString = "aabbccaa";
		//	foreach (var firstStringSymb in firstString)
		//	{
		//		foreach (var symb in charsAll)
		//		{
		//			if (symb.Equals(firstStringSymb))
		//			{
		//				if (!resultString.Contains(firstStringSymb))
		//				{
		//					resultString += firstStringSymb;
		//				}
		//			}
		//		}
		//	}

		//	Console.WriteLine(resultString);
		//	Console.WriteLine("List has been created");

		//	var str = "AABBCCDDDDDDEEEEEFFF";
		//	var unique = str.ToCharArray().Distinct();
		//	Console.WriteLine("Answer: {0}.", string.Join(string.Empty, unique));
		//}

		public static string RemoveDuplicateChars(string input)
		{
			var stringBuilder = new StringBuilder(input);

			foreach (char c in input)
			{
				stringBuilder.Replace(c.ToString(), string.Empty)
							 .Append(c.ToString());
			}

			return stringBuilder.ToString();
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