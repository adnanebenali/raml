using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Raml.Core
{

	public class NoteStatistics : INotifyPropertyChanged
	{
		//private int _once;
		//private int _twice;
		//private int _threeTimes;
		//private int _fourTimes;
		//private int _fiveTimes;
		//private int _sixTimes;
		private int _many;
		private ObservableCollection<int> _occurences = new ObservableCollection<int>();

		public NoteStatistics()
		{
			for (int i = 0; i <= 30; i++)
			{
				_occurences.Add(0);
			}
		}

		public required string Note { get; set; }


		public ObservableCollection<int> Occurences
		{
			get => _occurences;
			set
			{
				if (_occurences != value)
				{
					_occurences = value;
					OnPropertyChanged(nameof(Occurences));
				}
			}
		}

		public int Many
		{
			get => _many;
			set
			{
				if (_many != value)
				{
					_many = value;
					OnPropertyChanged(nameof(Many));
				}
			}
		}

		//public int Once
		//{
		//	get => _once;
		//	set
		//	{
		//		if (_once != value)
		//		{
		//			_once = value;
		//			OnPropertyChanged(nameof(Once));
		//		}
		//	}
		//}

		//public int Twice
		//{
		//	get => _twice;
		//	set
		//	{
		//		if (_twice != value)
		//		{
		//			_twice = value;
		//			OnPropertyChanged(nameof(Twice));
		//		}
		//	}
		//}

		//public int ThreeTimes
		//{
		//	get => _threeTimes;
		//	set
		//	{
		//		if (_threeTimes != value)
		//		{
		//			_threeTimes = value;
		//			OnPropertyChanged(nameof(ThreeTimes));
		//		}
		//	}
		//}

		//public int FourTimes
		//{
		//	get => _fourTimes;
		//	set
		//	{
		//		if (_fourTimes != value)
		//		{
		//			_fourTimes = value;
		//			OnPropertyChanged(nameof(FourTimes));
		//		}
		//	}
		//}

		//public int FiveTimes
		//{
		//	get => _fiveTimes;
		//	set
		//	{
		//		if (_fiveTimes != value)
		//		{
		//			_fiveTimes = value;
		//			OnPropertyChanged(nameof(FiveTimes));
		//		}
		//	}
		//}

		//public int SixTimes
		//{
		//	get => _sixTimes;
		//	set
		//	{
		//		if (_sixTimes != value)
		//		{
		//			_sixTimes = value;
		//			OnPropertyChanged(nameof(SixTimes));
		//		}
		//	}
		//}


		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged(string propertyName) =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	}

}


