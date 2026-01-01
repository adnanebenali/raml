using System.ComponentModel;

namespace Raml.Core
{

	public class AverageCalculator : INotifyPropertyChanged
	{
		private readonly Queue<double> _values = new();
		private readonly int _maxWindowSize = 1000; // For a rolling average
		private double _currentAverage;

		public double CurrentAverage
		{
			get => _currentAverage;
			private set
			{
				if (_currentAverage != value)
				{
					_currentAverage = value;
					OnPropertyChanged(nameof(CurrentAverage));
				}
			}
		}

		public void AddValue(double newValue)
		{
			if (_values.Count >= _maxWindowSize)
				_values.Dequeue(); // Remove oldest value

			_values.Enqueue(newValue);
			CurrentAverage = _values.Average(); // Calculate new average
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged(string propertyName) =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

}


