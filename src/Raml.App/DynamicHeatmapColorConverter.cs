using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Raml.App
{

	public class DynamicHeatmapColorConverter : IMultiValueConverter
	{
		private readonly Dictionary<Color, SolidColorBrush> _brushCache = new();

		public event EventHandler<NoteColorChangedEventArgs>? NoteColorChanged;

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values[0] is int value && values[1] is int min && values[2] is int max)
			{
				if (max - min > 0)
				{

					Color color = CalculateColor(value, min, max);

					// Check if we already have a brush for this color, otherwise create a new one
					if (!_brushCache.ContainsKey(color))
					{
						_brushCache[color] = new SolidColorBrush(color);
					}

					if (values.Length > 3)
					{
						string? noteName = values[3]?.ToString();
						if (noteName != null)
						{
							string? existingColor = values[4]?.ToString();
							if (existingColor != null && !existingColor.Equals(color))
							{
								NoteColorChanged?.Invoke(this, new NoteColorChangedEventArgs(noteName, color));
							}
						}
					}

					return _brushCache[color];
				}
			}

			return Brushes.Transparent;
		}

		private Color CalculateColor(double value, double min, double max)
		{
			// Clamp the value
			value = Math.Max(min, Math.Min(max, value));
			byte intensity = (byte)(255 * (value - min) / (max - min));
			return Color.FromRgb(intensity, 3, 143);
		}


		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}


	public class NoteColorChangedEventArgs : EventArgs
	{
		public string NoteName { get; }
		public Color NewColor { get; }

		public NoteColorChangedEventArgs(string noteName, Color newColor)
		{
			NoteName = noteName;
			NewColor = newColor;
		}
	}
}


