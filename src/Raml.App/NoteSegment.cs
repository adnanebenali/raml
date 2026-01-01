using System.Windows;
using System.Windows.Media;

namespace raml
{
	/// <summary>
	/// Represents the note segment geometry in the donut shape (circle of fifths)
	/// </summary>
	public class NoteSegment
	{
		public Point OuterStartPoint { get; set; }
		public Point OuterEndPoint { get; set; }
		public Point InnerStartPoint { get; set; }
		public Point InnerEndPoint { get; set; }
		public required Brush FillColor { get; set; }
	}

}


