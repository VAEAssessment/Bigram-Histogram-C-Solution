using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		// example input string
		var sentence = "The quick brown fox and the quick blue hare. ";
		
		// remove punctuations + remove unnecessary whitespace + change all to lowercase
		sentence = sentence.Where(c => !char.IsPunctuation(c)).Aggregate("", (current, c) => current + c).Trim().ToLower();
		
		// change sentence to array of strings
		string[] words = sentence.Split(' ');
		
		string[] bigrams = new string[words.Length - 1];
		Dictionary<string, int> dict = new Dictionary<string, int>();
		
		// create bigrams and store them in array
		for (int i = 0; i < words.Length - 1; i++) {
			bigrams[i] = words[i] + " " + words[i+1];
		}
		
		// insert bigrams into dictionary
		foreach (string bigram in bigrams) {
			if (dict.ContainsKey(bigram)) {
				dict[bigram] = dict[bigram] + 1;
			}
			else {
				dict.Add(bigram, 1);
			}
		}
		
		foreach (var record in dict) {
			Console.WriteLine("\"" + record.Key + "\":" + record.Value);
		}
	}
}
