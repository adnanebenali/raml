using System.Text;

namespace Raml.Modes.Andaloussi
{
	/// <summary>
	/// Khaliyya (arabic) means a cell. 
	/// In this context it means a phrase of specific musical notes that occurs as a building block in a musical piece.
	/// Andaloussi modes are characterized by the occurrence of specific cells (phrases), or Khalaya (plural of Khaliyya) 
	/// that make up the character and personality of that mode. This is a theory set forth by Moroccan music researcher Amin Chaachoo
	/// which I am adopting here to define a mapping of Mode to its Khalaya, as defined by Chaachoo.
	/// </summary>
	public class Khaliyya
	{
		public List<Nota> Notatt { get; set; } = new List<Nota>();

		public Khaliyya(params Nota[] notatt)
		{
			foreach (Nota nota in notatt)
			{
				Notatt.Add(nota);
			}
		}

		public override string ToString()
		{
			StringBuilder blurb = new StringBuilder();

			foreach (Nota nota in Notatt)
			{
				blurb.Append(nota);
			}

			return blurb.ToString();
		}

		public string ToColorizedString()
		{
			StringBuilder blurb = new StringBuilder();

			foreach (Nota nota in Notatt)
			{
				blurb.Append(nota.ToColorizedString());
			}

			//blurb.Append($"		{GetHashCode()}");

			return blurb.ToString();
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			if (ReferenceEquals(obj, this))
			{
				return true;
			}

			if (!(obj is Khaliyya other))
			{
				return false;
			}

			bool result = Notatt.SequenceEqual(other.Notatt);
			return result;
		}

		public override int GetHashCode()
		{
			unchecked // Overflow is fine, just wrap
			{
				int hash = (int)2166136261;

				foreach (Nota nota in Notatt)
				{
					hash = hash * 16777619 ^ nota.GetHashCode();
				}

				return hash;
			}
		}

	}
}
