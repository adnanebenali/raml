using System.Text.RegularExpressions;

namespace Raml.Modes.Andaloussi
{
	/// <summary>
	/// General helper to determine a Tab3 given a Khaliyya (no smarts, just simple lookup)
	/// and other musical note helpers.
	/// May need reorganization later and refactoring.
	/// </summary>
	public class Sniffer
	{
		private readonly Dictionary<Khaliyya, SortedSet<string>> _toubou3ByKhalayaDisplayed = new Dictionary<Khaliyya, SortedSet<string>>();
		private readonly Dictionary<Khaliyya, SortedSet<Toubou3>> _toubou3ByKhalaya = new Dictionary<Khaliyya, SortedSet<Toubou3>>();


		static private readonly Dictionary<string, Notatt> NoteMapping = new Dictionary<string, Notatt>(StringComparer.OrdinalIgnoreCase)
		{
			{ "A", Notatt.A }, { "B", Notatt.B }, { "C", Notatt.C }, { "D", Notatt.D }, { "E", Notatt.E }, { "F", Notatt.F }, { "G", Notatt.G },
			{ "Bb", Notatt.Bb }, { "B♭", Notatt.Bb }, { "Eb", Notatt.Eb }, { "E♭", Notatt.Eb }, { "F#", Notatt.Fsharp }, { "Fsharp", Notatt.Fsharp },
			{ "G#", Notatt.Gsharp }, { "Gsharp", Notatt.Gsharp }, { "C#", Notatt.Csharp }, { "Csharp", Notatt.Csharp }
		};

		public void DisplayByKhalaya(Tab3? focus, params Tab3[] toubou3)
		{
			if (_toubou3ByKhalaya.Count == 0)
			{

				for (int i = 0; i < toubou3.Length; i++)
				{
					Tab3 current_tab3 = toubou3[i];

					foreach (Khaliyya khaliyya in current_tab3.Khalaya)
					{
						foreach (Tab3 tab3 in toubou3)
						{
							if (tab3.Khalaya.Contains(khaliyya))
							{
								bool matched = focus != null && focus.Name.Equals(tab3.Name);
								string formatted_match = (matched ? $"{MyColors.BLUE}" : "") + Shrink(tab3.Short) + (matched ? $"{MyColors.NORMAL}" : "");

								if (_toubou3ByKhalayaDisplayed.TryGetValue(khaliyya, value: out var result))
								{
									result.Add(formatted_match);
								}
								else
								{
									_toubou3ByKhalayaDisplayed.Add(khaliyya, new SortedSet<string> { formatted_match });
								}
							}
						}
					}
				}
			}


			Console.WriteLine(Environment.NewLine + $"|||||||||||||||||||||||||     Sniffing {toubou3.Length} Toubou3...    |||||||||||||||||||||||||" + Environment.NewLine);
			foreach (KeyValuePair<Khaliyya, SortedSet<string>> khaliyya in _toubou3ByKhalayaDisplayed.OrderBy(key => key.Value.Count()))
			{
				if (khaliyya.Value.Count() > 1)
				{
					string names = string.Join(@" . ", khaliyya.Value);
					Console.WriteLine($"{khaliyya.Key.ToColorizedString()}		{names}");
				}
			}
		}


		public void OrganizeByKhalaya(params Tab3[] toubou3)
		{
			if (_toubou3ByKhalaya.Count > 0)
			{
				return;
			}

			for (int i = 0; i < toubou3.Length; i++)
			{
				Tab3 current_tab3 = toubou3[i];

				foreach (Khaliyya khaliyya in current_tab3.Khalaya)
				{
					foreach (Tab3 tab3 in toubou3)
					{
						if (tab3.Khalaya.Contains(khaliyya))
						{
							if (_toubou3ByKhalaya.TryGetValue(khaliyya, value: out var result))
							{
								result.Add(tab3.Type);
							}
							else
							{
								_toubou3ByKhalaya.Add(khaliyya, new SortedSet<Toubou3> { tab3.Type });
							}
						}
					}
				}
			}
		}

		public List<Toubou3> WhichToubou3(List<string> phrase, Notatt serd = Notatt.None)
		{
			List<Notatt> converted = ToNotatt(phrase);
			Khaliyya khaliyya = ToKhaliyya(converted);

			return _toubou3ByKhalaya.TryGetValue(khaliyya, out SortedSet<Toubou3> toubou3) ? toubou3.ToList() : new List<Toubou3>();
		}

		public string Shrink(string text)
		{
			return Regex.Replace(text, @"\s+", "");
		}

		public static List<Notatt> ToNotatt(List<string> phrase)
		{
			return phrase
				.Select(note => NoteMapping.TryGetValue(note, out Notatt parsedNote) ? parsedNote : Notatt.None)
				.ToList();
		}

		public static Notatt ToNota(string note)
		{
			return NoteMapping.TryGetValue(note, out Notatt parsedNote) ? parsedNote : Notatt.None;
		}

		public static Khaliyya ToKhaliyya(List<Notatt> converted)
		{
			Khaliyya khaliyya = new Khaliyya();

			foreach (Notatt note in converted)
			{
				khaliyya.Notatt.Add(new Nota(note, NotaDirection.None));
			}

			return khaliyya;
		}
	}
}
