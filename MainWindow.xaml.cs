using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using NAudio.Wave;



namespace raml
{
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private WasapiLoopbackCapture? _loopbackCapture;
		private WaveInEvent _microphoneCapture;
		private readonly int _sampleRate = 44100;
		private readonly int _bufferSize = 1024;
		//private readonly double Note2NoteFrequencyMultiplier = Math.Pow(2, 1.0 / 12);
		private readonly PitchDetector _pitchDetector;
		private readonly Dictionary<string, double> _noteFrequencies0;
		//private readonly Dictionary<string, double> _noteFrequencies4;
		private Dictionary<int, Dictionary<string, double>> _octaves;
		private readonly AverageCalculator _averageSilenceCalculator = new();
		private readonly AverageCalculator _averageAudioCalculator = new();
		private readonly AverageCalculator _averageChatterCalculator = new();

		private ObservableCollection<NoteStatistics> _noteStats;
		private string _lastDetectedNote;
		private int _currentNoteStreak = 0;


		private readonly MediaPlayer _player;
		//private readonly string[] _noteFiles = { "C", "G", "D", "A", "E", "B", "F#", "C#", "Ab", "Eb", "Bb", "F" };

		private int _minNoteStatOccurence;
		private int _maxNoteStatOccurence;
		private int _minNoteStatStreak;
		private int _maxNoteStatStreak;
		private readonly int MaxNoteStreak = 15;

		private ObservableCollection<string> _fleetingNotes;

		private bool _listeningToLoopback = false;
		private bool _listeningToMicrophone = false;


		// Phrases
		private readonly List<string> _currentPhrase = new List<string>(); // Holds notes of the current phrase
		private readonly List<string> _detectedPhrases = new List<string>();       // Holds completed phrases
		private const double SilenceThreshold = 0.001;            // Adjust as needed
		private const int SilenceDurationMs = 1000;                // Milliseconds of silence to detect a phrase end
		private DateTime _lastNoteDetectedTime = DateTime.Now;        // Time of the last detected note
		private const int EndOfPhraseNoteRepetitionThreshold = 8; // Example: 3 consecutive repetitions to signal the end of a phrase
		private int _consecutiveNoteCount = 0;
		private string _lastNoteDetected;
		private bool _consideringPhraseSemis = true;

		private readonly Sniffer _sniffer;
		private readonly Toubou3Builder _tab3Builder;


		public int MinNoteStatOccurence
		{
			get => _minNoteStatOccurence;
			set { _minNoteStatOccurence = value; OnPropertyChanged(); }
		}

		public int MaxNoteStatOccurence
		{
			get => _maxNoteStatOccurence;
			set { _maxNoteStatOccurence = value; OnPropertyChanged(); }
		}

		public int MinNoteStatStreak
		{
			get => _minNoteStatStreak;
			set { _minNoteStatStreak = value; OnPropertyChanged(); }
		}

		public int MaxNoteStatStreak
		{
			get => _maxNoteStatStreak;
			set { _maxNoteStatStreak = value; OnPropertyChanged(); }
		}

		public ObservableCollection<NoteSegment> Notes { get; set; }

		private ObservableCollection<string> _messages;

		public ObservableCollection<string> Messages
		{
			get => _messages;
			set
			{
				_messages = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<string> _phraseLog;

		public ObservableCollection<string> PhraseLog
		{
			get => _phraseLog;
			set
			{
				_phraseLog = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<string> FleetingNotes
		{
			get => _fleetingNotes;
			set
			{
				_fleetingNotes = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<NoteStatistics> NoteStats
		{
			get => _noteStats;
			set
			{
				_noteStats = value;
				OnPropertyChanged();
			}
		}

		public AverageCalculator AverageSilenceCalculator
		{
			get => _averageSilenceCalculator;
		}

		public AverageCalculator AverageChatterCalculator
		{
			get => _averageChatterCalculator;
		}

		public AverageCalculator AverageAudioCalculator
		{
			get => _averageAudioCalculator;
		}

		public MainWindow()
		{
			InitializeComponent();

			Messages = new ObservableCollection<string>();
			FleetingNotes = new ObservableCollection<string>();
			PhraseLog = new ObservableCollection<string>();

			DataContext = this;

			//InitializeDonut();
			//InitializeGlazedDonut();
			InitializeDonuts();

			_player = new MediaPlayer();

			// Initialize pitch detector (YIN or Autocorrelation can be used here)
			_pitchDetector = new PitchDetector(_sampleRate, _bufferSize);

			// Initialize note frequencies (in Hz)
			_noteFrequencies0 = new Dictionary<string, double>
			{
				{ "C", 16.3516 },
				{ "C#", 17.3239 },
				{ "D", 18.354 },
				{ "Eb", 19.4454 },
				{ "E", 20.6017 },
				{ "F", 21.8268 },
				{ "F#", 23.1247 },
				{ "G", 24.4997 },
				{ "Ab", 25.9565 },
				{ "A", 27.5 },
				{ "Bb", 29.1352 },
				{ "B", 30.8677 },
			};

			//_noteFrequencies4 = new Dictionary<string, double>
			//{
			//	{ "C", 261.63 },
			//	{ "C#", 277.18 },
			//	{ "D", 293.66 },
			//	{ "Eb", 311.13 },
			//	{ "E", 329.63 },
			//	{ "F", 349.23 },
			//	{ "F#", 370.00 },
			//	{ "G", 392.00 },
			//	{ "Ab", 415.30 },
			//	{ "A", 440.00 },
			//	{ "Bb", 466.16 },
			//	{ "B", 493.88 },
			//};

			InitializeOctaves();
			InitializeNoteStats();

			// Set up microphone input
			InitializeMicrophone();

			// Set up system audio capture (loopback recording)
			InitializeLoopbackCapture();


			var converter = (DynamicHeatmapColorConverter)Resources["DynamicHeatmapColorConverter"];
			converter.NoteColorChanged += (sender, e) =>
			{
				// Update the donut UI
				UpdateNoteBackgroundInDonut(e.NoteName, e.NewColor);
			};


			_tab3Builder = new Toubou3Builder();
			_sniffer = new Sniffer();
			_sniffer.OrganizeByKhalaya(_tab3Builder.GetToubou3().ToArray());

		}

		private void UpdateNoteBackgroundInDonut(string noteName, Color newColor)
		{
			if (noteName != null)
			{
				if (Application.Current == null)
					return;

				Application.Current.Dispatcher.Invoke(() =>
				{
					var brush = new SolidColorBrush(newColor);

					// Find the corresponding UI element for the note and update its background color
					for (int octave = 2; octave <= 4; octave++)
					{
						if (FindName($"Note{noteName.Replace("#", "Sharp")}{octave}") is Path path)
						{
							path.Tag = brush;
							path.Fill = brush;
						}
					}

				});
			}
		}


		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}



		public void UpdateMinMaxNoteStats()
		{
			if (NoteStats.Any())
			{
				MinNoteStatOccurence = NoteStats.Select(ns => ns.Occurences[1]).Min();
				MaxNoteStatOccurence = NoteStats.Select(ns => ns.Occurences[1]).Max();
				MinNoteStatStreak = NoteStats.SelectMany(ns => ns.Occurences.Where((value, index) => index > 1)).Min();
				MaxNoteStatStreak = NoteStats.SelectMany(ns => ns.Occurences.Where((value, index) => index > 1)).Max();
			}
		}

		public void Log(string message)
		{
			// Ensure the update happens on the UI thread
			if (Dispatcher.CheckAccess())
			{
				Messages.Insert(0, message);
			}
			else
			{
				Dispatcher.Invoke(() => Messages.Insert(0, message));
			}
		}

		public void Fleeting(string note)
		{
			// Ensure the update happens on the UI thread
			if (Dispatcher.CheckAccess())
			{
				FleetingNotes.Insert(0, note);
			}
			else
			{
				Dispatcher.Invoke(() => FleetingNotes.Insert(0, note));
			}
		}

		public void LogPhrase(string phrase)
		{
			// Ensure the update happens on the UI thread
			if (Dispatcher.CheckAccess())
			{
				PhraseLog.Insert(0, phrase);
			}
			else
			{
				Dispatcher.Invoke(() => PhraseLog.Insert(0, phrase));
			}
		}

		////private void InitializeDonut()
		////{
		////	Notes = new ObservableCollection<NoteSegment>();

		////	double outerRadius = 100; //150
		////	double innerRadius = 40; //80

		////	for (int i = 0; i < 12; i++)
		////	{
		////		// Calculate angles for the segment
		////		double angle1 = (i * 30) * Math.PI / 180;  // Start angle in radians
		////		double angle2 = ((i + 1) * 30) * Math.PI / 180;  // End angle in radians

		////		// Calculate the outer start and end points
		////		var outerStartPoint = new Point(150 + outerRadius * Math.Cos(angle1), 150 + outerRadius * Math.Sin(angle1));
		////		var outerEndPoint = new Point(150 + outerRadius * Math.Cos(angle2), 150 + outerRadius * Math.Sin(angle2));

		////		// Calculate the inner start and end points
		////		var innerStartPoint = new Point(150 + innerRadius * Math.Cos(angle1), 150 + innerRadius * Math.Sin(angle1));
		////		var innerEndPoint = new Point(150 + innerRadius * Math.Cos(angle2), 150 + innerRadius * Math.Sin(angle2));

		////		Notes.Add(new NoteSegment
		////		{
		////			OuterStartPoint = outerStartPoint,
		////			OuterEndPoint = outerEndPoint,
		////			InnerStartPoint = innerStartPoint,
		////			InnerEndPoint = innerEndPoint,
		////			FillColor = Brushes.LightGray
		////		});
		////	}

		////	DataContext = this;

		////}


		private void InitializeDonuts()
		{
			double centerX = 300; // Center X of the donut
			double centerY = 300; // Center Y of the donut
			double outerRadiusDonut5 = 270; // Outer donut's inner radius
			double innerRadiusDonut5 = 251; // Outer donut's inner radius

			double outerRadiusDonut4 = 250; // 250 Outer donut's outer radius
			double innerRadiusDonut4 = 150; // Outer donut's inner radius
			double outerRadiusDonut3 = innerRadiusDonut4; // Outer donut's outer radius
			double innerRadiusDonut3 = 80; // Outer donut's inner radius
			double outerRadiusInnerDonut = innerRadiusDonut3; // Inner donut's outer radius
			double innerRadiusInnerDonut = 40; // Inner donut's inner radius
			int sliceCount = 12;

			CreateDonut(centerX, centerY, outerRadiusDonut5, innerRadiusDonut5, sliceCount, octave: 5, shouldAnnotate: false);
			CreateDonut(centerX, centerY, outerRadiusDonut4, innerRadiusDonut4, sliceCount, octave: 4);
			CreateDonut(centerX, centerY, outerRadiusDonut3, innerRadiusDonut3, sliceCount, octave: 3);
			CreateDonut(centerX, centerY, outerRadiusInnerDonut, innerRadiusInnerDonut, sliceCount, octave: 2);
		}

		// Method to create a donut shape with a given center, outer and inner radii, slice count, and starting letter
		private void CreateDonut(double centerX, double centerY, double outerRadius, double innerRadius, int sliceCount, int octave, bool shouldAnnotate = true)
		{
			int currentLetter = 0;

			string[] notes = { "C", "F", "Bb", "Eb", "Ab", "C#", "F#", "B", "E", "A", "D", "G" };
			Color[] colors = {  Colors.DarkViolet,
								Colors.Green,
								Colors.RosyBrown,
								Colors.Crimson,
								Colors.DarkGray,
								Colors.Goldenrod,
								Colors.Silver,
								Colors.IndianRed,
								Colors.Teal,
								Colors.DeepSkyBlue,
								Colors.Purple,
								Colors.Black
			};

			//A - Gold
			//Symbolizing divine light, glory, and ascension.
			//Bb(A#) - Soft Lavender
			//Representing grace, introspection, and gentle spirituality.
			//B - Deep Blue
			//Evoking mystery, depth, and celestial majesty.
			//C - White
			//Reflecting purity, simplicity, and divine constancy.
			//C# (Db) - Pale Yellow
			//Suggesting hope, awakening, and heavenly promise.
			//D - Royal Purple
			//Symbolizing divine authority, majesty, and holiness.
			//Eb(D#) - Crimson
			//Representing penitence, divine love, and soulful reflection.
			//E - Bright Orange
			//Evoking radiance, joy, and victorious celebration.
			//F - Earthy Green
			//Reflecting stability, nurturing care, and pastoral peace.
			//F# (Gb) - Silver
			//Suggesting subtlety, sacred mystery, and divine transcendence.
			//G - Vibrant Yellow
			//Symbolizing jubilation, adoration, and spiritual freedom.
			//Ab(G#) - Dark Grey
			//Evoking solemnity, introspection, and the weight of divine justice.

			for (int i = 2; i < sliceCount + 2; i++)
			{
				// Calculate the start and end angle for each slice
				double startAngle = i * 360.0 / sliceCount;
				double endAngle = startAngle + 360.0 / sliceCount;

				// Convert angles to radians
				double startAngleRad = startAngle * Math.PI / 180;
				double endAngleRad = endAngle * Math.PI / 180;

				// Calculate points on outer radius
				Point outerStart = new Point(centerX + outerRadius * Math.Cos(startAngleRad),
											 centerY - outerRadius * Math.Sin(startAngleRad));
				Point outerEnd = new Point(centerX + outerRadius * Math.Cos(endAngleRad),
										   centerY - outerRadius * Math.Sin(endAngleRad));

				// Calculate points on inner radius
				Point innerStart = new Point(centerX + innerRadius * Math.Cos(endAngleRad),
											 centerY - innerRadius * Math.Sin(endAngleRad));
				Point innerEnd = new Point(centerX + innerRadius * Math.Cos(startAngleRad),
										   centerY - innerRadius * Math.Sin(startAngleRad));

				// Create PathFigure for the slice
				PathFigure figure = new PathFigure { StartPoint = outerStart };
				figure.Segments.Add(new ArcSegment(outerEnd, new Size(outerRadius, outerRadius), 0, false, SweepDirection.Counterclockwise, true));
				figure.Segments.Add(new LineSegment(innerStart, true));
				figure.Segments.Add(new ArcSegment(innerEnd, new Size(innerRadius, innerRadius), 0, false, SweepDirection.Clockwise, true));
				figure.Segments.Add(new LineSegment(outerStart, true));

				// Create PathGeometry and Path for the slice
				PathGeometry geometry = new PathGeometry();
				geometry.Figures.Add(figure);

				byte alpha = (byte)(octave < 5 ? 255 : 100);

				Path path = new Path
				{
					Data = geometry,
					Fill = new SolidColorBrush(Color.FromArgb(alpha, (byte)(i * 20), (byte)(i * 10), 150)), // Unique color per slice
																											//Fill = new SolidColorBrush(colors[currentLetter]), // Unique color per slice
					Stroke = Brushes.Transparent,
					StrokeThickness = 1
				};

				path.Tag = path.Fill;

				// Add MouseEnter and MouseLeave event handlers
				path.MouseEnter += Slice_MouseEnter;
				path.MouseLeave += Slice_MouseLeave;

				FifthsCanvas.Children.Add(path);


				// Calculate center for the text
				double midAngleRad = (startAngleRad + endAngleRad) / 2;
				double textRadius = (outerRadius + innerRadius) / 2;

				Point textPosition = new Point(
					centerX + textRadius * Math.Cos(midAngleRad),
					centerY - textRadius * Math.Sin(midAngleRad)
				);

				// Create TextBlock for each letter
				TextBlock textBlock = new TextBlock
				{
					Text = notes[currentLetter],
					FontSize = 6 * octave,
					Foreground = Brushes.White,
					FontWeight = FontWeights.Bold,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				};

				if (shouldAnnotate)
				{

					// Set Canvas position for the TextBlock
					Canvas.SetLeft(textBlock, -10 + textPosition.X - textBlock.ActualWidth / 2);
					Canvas.SetTop(textBlock, -10 + textPosition.Y - textBlock.ActualHeight / 2);

					// Add the TextBlock to the canvas
					FifthsCanvas.Children.Add(textBlock);
				}

				RegisterName($"Note" + textBlock.Text.Replace("#", "Sharp") + octave, path);
				RegisterName($"TextNote" + textBlock.Text.Replace("#", "Sharp") + octave, textBlock);

				// Move to the next letter
				currentLetter++;

			}
		}


		////private void InitializeGlazedDonut()
		////{
		////	double centerX = 300; // Center X of the donut
		////	double centerY = 300; // Center Y of the donut
		////	double outerRadius = 150;
		////	double innerRadius = 80;
		////	int sliceCount = 12;
		////	int currentLetter = 0;

		////	string[] notes = { "C", "F", "Bb", "Eb", "Ab", "C#", "F#", "B", "E", "A", "D", "G" };

		////	for (int i = 2; i < sliceCount + 2; i++)
		////	{
		////		// Calculate the start and end angle for each slice
		////		double startAngle = i * 360.0 / sliceCount;
		////		double endAngle = startAngle + 360.0 / sliceCount;

		////		// Convert angles to radians
		////		double startAngleRad = startAngle * Math.PI / 180;
		////		double endAngleRad = endAngle * Math.PI / 180;

		////		// Calculate points on outer radius
		////		Point outerStart = new Point(centerX + outerRadius * Math.Cos(startAngleRad),
		////									 centerY - outerRadius * Math.Sin(startAngleRad));
		////		Point outerEnd = new Point(centerX + outerRadius * Math.Cos(endAngleRad),
		////								   centerY - outerRadius * Math.Sin(endAngleRad));

		////		// Calculate points on inner radius
		////		Point innerStart = new Point(centerX + innerRadius * Math.Cos(endAngleRad),
		////									 centerY - innerRadius * Math.Sin(endAngleRad));
		////		Point innerEnd = new Point(centerX + innerRadius * Math.Cos(startAngleRad),
		////								   centerY - innerRadius * Math.Sin(startAngleRad));

		////		// Create PathFigure for the slice
		////		PathFigure figure = new PathFigure { StartPoint = outerStart };
		////		figure.Segments.Add(new ArcSegment(outerEnd, new Size(outerRadius, outerRadius), 0, false, SweepDirection.Counterclockwise, true));
		////		figure.Segments.Add(new LineSegment(innerStart, true));
		////		figure.Segments.Add(new ArcSegment(innerEnd, new Size(innerRadius, innerRadius), 0, false, SweepDirection.Clockwise, true));
		////		figure.Segments.Add(new LineSegment(outerStart, true));

		////		// Create PathGeometry and Path for the slice
		////		PathGeometry geometry = new PathGeometry();
		////		geometry.Figures.Add(figure);

		////		Path path = new Path
		////		{
		////			Data = geometry,
		////			Fill = new SolidColorBrush(Color.FromArgb(255, (byte)(i * 20), (byte)(i * 10), 150)), // Unique color per slice
		////			Stroke = Brushes.Transparent,
		////			StrokeThickness = 1
		////		};

		////		// Add MouseEnter and MouseLeave event handlers
		////		path.MouseEnter += Slice_MouseEnter;
		////		path.MouseLeave += Slice_MouseLeave;

		////		FifthsCanvas.Children.Add(path);


		////		// Calculate center for the text
		////		double midAngleRad = (startAngleRad + endAngleRad) / 2;
		////		double textRadius = (outerRadius + innerRadius) / 2;

		////		Point textPosition = new Point(
		////			centerX + textRadius * Math.Cos(midAngleRad),
		////			centerY - textRadius * Math.Sin(midAngleRad)
		////		);

		////		// Create TextBlock for each letter
		////		TextBlock textBlock = new TextBlock
		////		{
		////			Text = notes[currentLetter],
		////			FontSize = 20,
		////			Foreground = Brushes.White,
		////			FontWeight = FontWeights.Bold,
		////			HorizontalAlignment = HorizontalAlignment.Center,
		////			VerticalAlignment = VerticalAlignment.Center
		////		};

		////		// Set Canvas position for the TextBlock
		////		Canvas.SetLeft(textBlock, -10 + textPosition.X - textBlock.ActualWidth / 2);
		////		Canvas.SetTop(textBlock, -10 + textPosition.Y - textBlock.ActualHeight / 2);

		////		// Add the TextBlock to the canvas
		////		FifthsCanvas.Children.Add(textBlock);

		////		RegisterName("Note" + textBlock.Text.Replace("#", "Sharp"), path);

		////		// Move to the next letter
		////		currentLetter++;

		////	}
		////}


		private void InitializeOctaves()
		{
			_octaves = new Dictionary<int, Dictionary<string, double>>();
			_octaves[0] = _noteFrequencies0;

			for (int i = 1; i < 7; i++)
			{
				var frequencies = new Dictionary<string, double>();

				if (_octaves.TryGetValue(i - 1, out var previousFrequencies))
				{
					foreach (KeyValuePair<string, double> item in previousFrequencies)
					{
						frequencies[item.Key] = item.Value * 2;
					}
				}

				_octaves[i] = frequencies;
			}
		}

		private void InitializeNoteStats()
		{
			_noteStats = new ObservableCollection<NoteStatistics>();

			foreach (KeyValuePair<string, double> item in _noteFrequencies0)
			{
				_noteStats.Add(new NoteStatistics { Note = item.Key });
			}

			// Bind to the DataGrid
			NoteDataGrid.ItemsSource = NoteStats;
		}

		private void InitializeLoopbackCapture()
		{
			// Initialize loopback capture to capture system audio
			_loopbackCapture = new WasapiLoopbackCapture();
			_loopbackCapture.DataAvailable += OnDataAvailable;
			_loopbackCapture.WaveFormat = new WaveFormat(_sampleRate, 1); // Mono channel
			_loopbackCapture.StartRecording();
			_listeningToLoopback = true;
		}

		private void InitializeMicrophone()
		{
			_microphoneCapture = new WaveInEvent
			{
				WaveFormat = new WaveFormat(_sampleRate, 1) // Mono channel
			};

			_microphoneCapture.DataAvailable += OnDataAvailable;

			SetMicrophoneCapture(on: false);
		}

		private void OnDataAvailable__DEBUG(object sender, WaveInEventArgs e)
		{
			//short[] samples = new short[e.BytesRecorded / 2];
			//Buffer.BlockCopy(e.Buffer, 0, samples, 0, e.BytesRecorded);

			//// Calculate RMS
			//double rms = 0;
			//foreach (var sample in samples)
			//{
			//	double normalizedSample = sample / 32768.0; // Normalize to [-1, 1]
			//	rms += normalizedSample * normalizedSample;
			//}
			//rms = Math.Sqrt(rms / samples.Length);

			//// Define a silence threshold
			//const double silenceThreshold = 0.01; // Adjust as needed
			//if (rms > silenceThreshold)
			//{
			//	Log($"Silence detected: RMS {rms} --- " + string.Join(", ", samples.Take(10)));
			//	return;
			//}

			//Log($"AUDIO detected: RMS {rms} --- " + string.Join(", ", samples.Take(10)));


			// Extract and normalize 16-bit PCM samples from the buffer
			float[] samples = new float[e.BytesRecorded / 2];
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i] = BitConverter.ToInt16(e.Buffer, i * 2) / 32768f; // Normalize to [-1, 1]
			}

			if (samples.Length == 0)
				return;

			// Calculate peak amplitude
			float peakAmplitude = samples.Max(sample => Math.Abs(sample));
			const double silenceThreshold = 0.001; // Adjust as needed
			if (peakAmplitude < silenceThreshold)
			{
				Dispatcher.Invoke(() => _averageSilenceCalculator.AddValue(peakAmplitude));

				//Log($"Silence detected: PA {peakAmplitude} --- " + string.Join(", ", samples.Take(10)));
				return;
			}

			Dispatcher.Invoke(() => _averageAudioCalculator.AddValue(peakAmplitude));
			//Log($"AUDIO detected: PA {peakAmplitude} --- " + string.Join(", ", samples.Take(10)));
		}

		// This method gets called whenever sound data is available
		private void OnDataAvailable(object sender, WaveInEventArgs e)
		{

			////// Convert the audio bytes into a signal that can be processed
			////float[] buffer = new float[e.BytesRecorded / 2];
			////for (int i = 0; i < buffer.Length; i++)
			////{
			////	buffer[i] = BitConverter.ToInt16(e.Buffer, i * 2) / 32768f; // Normalize the 16-bit PCM data
			////}

			////// Calculate RMS (Root Mean Square) of the audio signal
			////double rms = 0;
			////foreach (var sample in buffer)
			////{
			////	rms += sample * sample;
			////}
			////rms = Math.Sqrt(rms / buffer.Length);

			////// Define a threshold for silence (e.g., very low RMS value)
			////const double silenceThreshold = 100.00000 / 10000; // Adjust as needed
			////Console.WriteLine("RMS: " + rms);

			//////if (rms < silenceThreshold)
			//////{
			//////	// Detected silence, ignore this data
			//////	return;
			//////}

			////// Process the non-silent audio data
			////Console.WriteLine("Audio detected with RMS: " + rms);



			// Extract and normalize 16-bit PCM samples from the buffer
			float[] samples = new float[e.BytesRecorded / 2];
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i] = BitConverter.ToInt16(e.Buffer, i * 2) / 32768f; // Normalize to [-1, 1]
			}

			if (samples.Length == 0)
				return;

			// Calculate peak amplitude
			float peakAmplitude = samples.Max(sample => Math.Abs(sample));
			if (peakAmplitude < SilenceThreshold)
			{
				Dispatcher.Invoke(() => _averageSilenceCalculator.AddValue(peakAmplitude));
				HighlightSilenceOnUI();

				// Check if enough time has passed to consider it a silence
				if ((DateTime.Now - _lastNoteDetectedTime).TotalMilliseconds >= SilenceDurationMs)
				{
					CompletePhrase();
				}

				return;
			}

			HighlightSilenceOnUI(shouldReset: true);

			HighlightChatterOnUI(shouldReset: true);

			Dispatcher.Invoke(() => _averageAudioCalculator.AddValue(peakAmplitude));



			// Perform pitch detection
			var pitch = _pitchDetector.DetectPitch(samples);

			if (pitch > 0 && pitch < 1000)
			{
				var (octave, note) = MatchPitchToNote(pitch);
				//Trace.WriteLine($"---> Detected pitch " + Math.Round(pitch, 2) + " matches note " + note + " " + octave);
				Log($"---> Detected pitch " + Math.Round(pitch, 2) + " matches note " + note + " " + octave);

				HighlightNoteOnUI(note, octave);


				// Check for repeated notes
				if (note == _lastNoteDetected)
				{
					_consecutiveNoteCount++;

					if (_consecutiveNoteCount >= EndOfPhraseNoteRepetitionThreshold)
					{
						CompletePhrase();
						_consecutiveNoteCount = 0; // Reset for the next phrase
					}
				}
				else
				{
					// New note, reset the counter
					_consecutiveNoteCount = 1;
				}

				// Add note to current phrase if it's not a duplicate of the last note
				if (_currentPhrase.Count == 0 || _currentPhrase[^1] != note)
				{
					_currentPhrase.Add(note);
					_lastNoteDetected = note;
				}

				_lastNoteDetectedTime = DateTime.Now;



				var noteStats = _noteStats.FirstOrDefault(n => n.Note == note);

				if (noteStats != null)
				{

					//noteStats.Once++;
					noteStats.Occurences[1]++;

					// Check for consecutive occurrences
					if (note == _lastDetectedNote)
					{
						_currentNoteStreak++;

						if (_currentNoteStreak <= MaxNoteStreak)
						{
							noteStats.Occurences[_currentNoteStreak]++;
						}
						else
						{
							noteStats.Many++;
						}

						UpdateMinMaxNoteStats();

						Fleeting("~");

					}
					else
					{
						// Reset streak if the note changes
						_lastDetectedNote = note;
						_currentNoteStreak = 1;
						Fleeting(note + " " + octave);
					}

					// Notify the DataGrid to refresh
					Application.Current.Dispatcher.Invoke(() =>
					{
						var index = NoteStats.IndexOf(noteStats);
						NoteStats[index] = noteStats; // Replace with updated object
					});
				}

			}
		}


		private void CompletePhrase()
		{
			if (_currentPhrase.Count > 1)
			{
				// Phrase complete, add it to the phrases list

				List<string> adjustedPhrase = new List<string>();

				if (!_consideringPhraseSemis)
				{
					foreach (string n in _currentPhrase)
					{
						if (n.Contains("#") || n.Contains("b"))
						{
							continue;
						}
						adjustedPhrase.Add(n);
					}
				}
				else
				{
					adjustedPhrase = _currentPhrase;
				}

				string phrase = string.Join(" ", adjustedPhrase);
				_detectedPhrases.Add(phrase);

				string observed = _noteStats.Aggregate((max, next) => next.Occurences[2] > max.Occurences[2] ? next : max).Note;
				var observedNotattSerd = Sniffer.ToNota(observed);

				List<Toubou3> toubou3 = _sniffer.WhichToubou3(adjustedPhrase);
				List<Toubou3> filteredToubou3 = _tab3Builder.FilterToubou3(toubou3, observedNotattSerd);

				phrase = phrase + " ----> (" + observedNotattSerd + ") > " + string.Join(" ", toubou3) + " >>> " + string.Join(" ", filteredToubou3);

				//Trace.WriteLine($"---> Detected Phrase " + phrase);

				LogPhrase(phrase);
				_currentPhrase.Clear(); // Clear for the next phrase
			}
		}

		// Match the detected pitch to the closest note in the Circle of Fifths
		private (int, string) MatchPitchToNote(double pitch)
		{
			string? closestNote = null;
			int closestOctave = 0;
			double minDifference = double.MaxValue;

			foreach (KeyValuePair<int, Dictionary<string, double>> octave in _octaves)
			{
				foreach (var note in octave.Value)
				{
					var difference = Math.Abs(note.Value - pitch);
					if (difference < minDifference)
					{
						minDifference = difference;
						closestNote = note.Key;
						closestOctave = octave.Key;
					}
				}
			}

			return (closestOctave, closestNote);
		}

		// Highlight the corresponding note button on the UI
		private void HighlightNoteOnUI(string note, int octave)
		{
			if (note != null)
			{
				if (Application.Current == null)
					return;

				Application.Current.Dispatcher.Invoke(() =>
				{
					//Button noteButton = FindName($"Note{note.Replace("#", "Sharp")}") as Button;
					//if (noteButton != null)
					//{
					//	ResetButtonBackgrounds();
					//	noteButton.Background = Brushes.LightGreen;
					//}

					if (FindName($"Note{note.Replace("#", "Sharp")}{octave}") is Path path)
					{
						ResetPathBackgrounds();
						path.Fill = Brushes.Yellow;
					}

					if (FindName($"TextNote{note.Replace("#", "Sharp")}{octave}") is TextBlock text)
					{
						ResetTextColors();
						text.Foreground = Brushes.Black;
					}
				});
			}
		}

		private void HighlightSilenceOnUI(bool shouldReset = false)
		{
			if (Application.Current == null)
				return;

			Application.Current.Dispatcher.Invoke(() =>
			{
				if (FindName($"Silence") is Button silenceButton)
				{
					silenceButton.Background = shouldReset ? Brushes.Transparent : Brushes.Turquoise;
				}
			});
		}

		private void HighlightChatterOnUI(bool shouldReset = false)
		{
			if (Application.Current == null)
				return;

			Application.Current.Dispatcher.Invoke(() =>
			{
				if (FindName($"Chatter") is Button silenceButton)
				{
					silenceButton.Background = shouldReset ? Brushes.Transparent : Brushes.Tomato;
				}
			});
		}

		// Reset all button backgrounds
		private void ResetButtonBackgrounds()
		{
			foreach (var child in FifthsCanvas.Children)
			{
				if (child is Button noteButton)
				{
					noteButton.Background = Brushes.White;
				}
			}
		}


		private void ResetPathBackgrounds()
		{
			foreach (var child in FifthsCanvas.Children)
			{
				if (child is Path path)
				{
					path.Fill = (Brush)path.Tag;
				}
			}
		}

		private void ResetTextColors()
		{
			foreach (var child in FifthsCanvas.Children)
			{
				if (child is TextBlock text)
				{
					text.Foreground = Brushes.White;
				}
			}
		}

		// Play sound when hovering over a note
		private void Note_MouseEnter(object sender, MouseEventArgs e)
		{
			Button noteButton = (Button)sender;
			HighlightNote(noteButton);
		}

		private void Note_MouseLeave(object sender, MouseEventArgs e)
		{
			Button noteButton = (Button)sender;
			ResetNote(noteButton);
		}

		// Handle clicking to "select" a note
		private void Note_Click(object sender, RoutedEventArgs e)
		{
			Button noteButton = (Button)sender;

			if (noteButton != null)
			{
				string note = noteButton.Content.ToString();
				PlayNoteSound(note);
			}
		}

		private void OnLoopbackCaptureClick(object sender, RoutedEventArgs e)
		{
			Button loopbackButton = (Button)sender;

			if (loopbackButton != null)
			{
				if (_listeningToLoopback)
				{
					_loopbackCapture?.StopRecording();
					loopbackButton.Content = "Listen to Loopback";
				}
				else
				{
					_loopbackCapture?.StartRecording();
					loopbackButton.Content = "Ignore Loopback";
				}

				_listeningToLoopback = !_listeningToLoopback;
			}
		}

		private void OnMicrophoneCaptureClick(object sender, RoutedEventArgs e)
		{
			Button microphoneButton = (Button)sender;

			if (microphoneButton != null)
			{
				// Toggle microphone setting:
				SetMicrophoneCapture(!_listeningToMicrophone);
			}
		}

		private void SetMicrophoneCapture(bool on)
		{
			if (!on)
			{
				_microphoneCapture?.StopRecording();
				ControlMicrophoneCapture.Content = "Listen to Microphone";
				_listeningToMicrophone = false;
			}
			else
			{
				_microphoneCapture?.StartRecording();
				ControlMicrophoneCapture.Content = "Ignore Microphone";
				_listeningToMicrophone = true;
			}
		}

		private void OnResetNoteStatsClick(object sender, RoutedEventArgs e)
		{
			InitializeNoteStats();
		}


		private void OnIgnoreSemisClick(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;

			if (button != null)
			{
				// Toggle
				SetPhraseSemis(!_consideringPhraseSemis);
			}
		}

		private void SetPhraseSemis(bool on)
		{
			if (!on)
			{
				IgnoreSemis.Content = "+ b#";
				_consideringPhraseSemis = false;
			}
			else
			{
				IgnoreSemis.Content = "- b#";
				_consideringPhraseSemis = true;
			}
		}

		private void Path_MouseEnter(object sender, MouseEventArgs e)
		{
			if (sender is Path path)
			{
				path.Fill = Brushes.Yellow;  // Example highlight color
			}
		}

		private void Path_MouseLeave(object sender, MouseEventArgs e)
		{
			if (sender is Path path)
			{
				path.Fill = Brushes.LightGray;
			}
		}

		// Event handler for MouseEnter to change color to yellow
		private void Slice_MouseEnter(object sender, MouseEventArgs e)
		{
			if (sender is Path path)
			{
				// Store the original color in the Tag property if not already stored
				if (path.Tag == null)
				{
					path.Tag = path.Fill;
				}
				path.Fill = Brushes.Yellow;
			}
		}

		// Event handler for MouseLeave to revert to the original color
		private void Slice_MouseLeave(object sender, MouseEventArgs e)
		{
			if (sender is Path path && path.Tag is Brush originalBrush)
			{
				path.Fill = originalBrush;
			}
		}

		private void PlaySong_Click(object sender, RoutedEventArgs e)
		{
			PlaySong();
		}

		// Play the corresponding sound for each note
		private void PlayNoteSound(string note)
		{
			if (string.IsNullOrWhiteSpace(note))
				return;

			string soundPath = $@"Resources\{note}.wav"; // assuming wav files are placed in Resources folder
			_player.Open(new Uri(soundPath, UriKind.Relative));
			_player.Play();
		}

		// Highlight the selected note
		private void HighlightNote(Button noteButton)
		{
			noteButton.Background = Brushes.LightBlue; // Change background to show selection
		}

		private void ResetNote(Button noteButton)
		{
			noteButton.Background = Brushes.Gray;
		}

		// Function to play a sequence of notes (song)
		private async void PlaySong()
		{
			string[] songNotes = { "A", "B", "C", "D", "E", "F", "G" };
			foreach (var note in songNotes)
			{
				if (note != "..")
				{

					Button noteButton = (Button)FindName($"Note{note}");
					HighlightNote(noteButton);
					PlayNoteSound(note);
				}

				await Task.Delay(1000); // Wait for 1 second between notes
			}
		}



	}



}

