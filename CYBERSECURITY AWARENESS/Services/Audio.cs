using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace CYBERSECURITY_AWARENESS.Services
{
	public class Audio : IDisposable
	{
		private SpeechSynthesizer _synthesizer;

		public Audio()
		{
			try
			{
				_synthesizer = new SpeechSynthesizer();
				try
				{
					_synthesizer.SelectVoice("Microsoft Zira Desktop");
				}
				catch
				{
					// default voice
				}
				_synthesizer.Rate = 1;
				_synthesizer.Volume = 80;
			}
			catch (Exception)
			{
				_synthesizer = null;
			}
		}

		public async Task SpeakAsync(string text)
		{
			if (_synthesizer == null)
				return;

			await Task.Run(() =>
			{
				try
				{
					_synthesizer.Speak(text);
				}
				catch (Exception)
				{
					
				}
			});
		}

		public void Dispose()
		{
			_synthesizer?.Dispose();
		}
	}
}
