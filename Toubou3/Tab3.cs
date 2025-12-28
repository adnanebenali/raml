using System.Text;

namespace raml
{
	/// <summary>
	/// Tab3 (arabic) means musical Mode, in the Andaloussi music tradition.
	/// Defined by Amin Chaachoo, it is characterized by its Khalaya (cells/phrases), 
	/// as well as its Qarar (settling note), Sard (sustained note) and Qotb () notes.
	/// Toubou3 is plural for Tab3.
	/// Example of Toubou3: Raml El-Maya, Maya, Sbihan, La7ssin, etc.
	/// </summary>
	internal class Tab3
	{
		public Toubou3 Type { get; set; } = Toubou3.Unknown;
		public string Name { get; set; } = string.Empty;
		public string Short { get; set; } = string.Empty;
		public List<Khaliyya> Khalaya { get; set; } = new List<Khaliyya>();
		public Notatt Qarar { get; set; } = Notatt.None;
		public Notatt Sard { get; set; } = Notatt.None;
		public Notatt Qotb { get; set; } = Notatt.None;

		public override string ToString()
		{
			StringBuilder blurb = new StringBuilder();

			blurb.AppendLine();
			blurb.Append($"-------------------- {Name} --------------------");
			blurb.AppendLine();
			blurb.AppendFormat($"{MyColors.BOLD}Qarar: {Qarar}{MyColors.NOBOLD}		Sard ~~~~~ {Sard}		Qotb >>>>> {Qotb}");
			blurb.AppendLine();

			foreach (Khaliyya khaliyya in Khalaya)
			{
				blurb.AppendLine();
				blurb.Append(khaliyya.ToColorizedString());
			}

			return blurb.ToString();
		}
	}
}
