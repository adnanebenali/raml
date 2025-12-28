namespace raml
{
	/// <summary>
	/// Simple type for musical note with direction (up or down) in the context of a Khaliyya whether
	/// it is ascending or descending.
	/// for example if the phrase is E F G, and F is the Nota, the direction would be up.
	/// </summary>
	internal class Nota
	{
		public Nota(Notatt name, NotaDirection direction)
		{
			Name = name;
			Direction = direction;
		}

		public Notatt Name { get; } = Notatt.None;
		public NotaDirection Direction { get; } = NotaDirection.None;

		public override string ToString()
		{
			return " " + (Direction == NotaDirection.Up ? ">" : $"<") + Name;
		}
		public string ToColorizedString()
		{
			return " " + (Direction == NotaDirection.Up ? ">" : $"{MyColors.RED}<") + Name + MyColors.NORMAL;
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

			if (!(obj is Nota other))
			{
				return false;
			}

			bool result = Name.Equals(other.Name);
			//result &= Direction.Equals(other.Direction);

			return result;
		}

		public override int GetHashCode()
		{
			unchecked // Overflow is fine, just wrap
			{
				int hash = (int)2166136261;
				//hash = (hash * 16777619) ^ (Direction.GetHashCode());
				hash = (hash * 16777619) ^ (Name.GetHashCode());

				return hash;
			}
		}
	}
}
