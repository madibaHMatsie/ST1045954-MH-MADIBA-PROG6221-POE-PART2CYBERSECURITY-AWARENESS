using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERSECURITY_AWARENESS.Services
{
	public class SentimentResult
	{
		public string Mood { get; set; }
		public bool IsPositive { get; set; }
		public bool IsNegative { get; set; }
		public bool IsNeutral { get; set; }
	}

	public class SentimentAnalyser
	{
		private HashSet<string> _positiveWords = new HashSet<string>
		{
			"good", "great", "awesome", "excellent", "happy", "secure", "safe", "confident", "thanks", "thank"
		};

		private HashSet<string> _negativeWords = new HashSet<string>
		{
			"worried", "scared", "anxious", "frustrated", "confused", "unsafe", "hack", "stolen", "scam", "fraud"
		};

		public SentimentResult DetectSentiment(string input)
		{
			string lowerInput = input.ToLower();

			int positiveCount = 0;
			int negativeCount = 0;

			foreach (var word in _positiveWords)
			{
				if (lowerInput.Contains(word))
					positiveCount++;
			}

			foreach (var word in _negativeWords)
			{
				if (lowerInput.Contains(word))
					negativeCount++;
			}

			var result = new SentimentResult();

			if (negativeCount > positiveCount)
			{
				result.Mood = "Worried";
				result.IsNegative = true;
			}
			else if (positiveCount > negativeCount)
			{
				result.Mood = "Positive";
				result.IsPositive = true;
			}
			else
			{
				result.Mood = "Curious";
				result.IsNeutral = true;
			}

			return result;
		}
	}
}