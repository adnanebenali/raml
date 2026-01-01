using NWaves.Signals;

namespace raml
{
	public class PitchDetector
	{
		private readonly int _sampleRate;
		private readonly int _bufferSize;
		private readonly int _minLag;
		private readonly int _maxLag;

		public PitchDetector(int sampleRate, int bufferSize)
		{
			_sampleRate = sampleRate;
			_bufferSize = bufferSize;

			// Set minimum and maximum lags to ignore harmonics and focus on realistic pitch range
			_minLag = _sampleRate / 1000;  // roughly 1000 Hz lower limit
			_maxLag = _sampleRate / 50;    // roughly 50 Hz upper limit
		}

		public double DetectPitch(float[] buffer)
		{
			// Convert buffer to DiscreteSignal for processing
			var signal = new DiscreteSignal(_sampleRate, buffer);

			// Perform autocorrelation
			var autocorrelation = new float[_bufferSize];
			for (int lag = 0; lag < _bufferSize; lag++)
			{
				for (int i = 0; i < _bufferSize - lag; i++)
				{
					if (i >= signal.Length || i + lag >= signal.Length)
						break;

					autocorrelation[lag] += signal[i] * signal[i + lag];
				}
			}

			// Ignore low lags by setting their autocorrelation values to zero
			for (int lag = 0; lag < _minLag; lag++)
			{
				autocorrelation[lag] = 0;
			}

			// Find the lag with the highest correlation within the desired range
			int maxLag = _minLag;
			float maxCorr = autocorrelation[_minLag];

			for (int lag = _minLag; lag < _maxLag; lag++)
			{
				if (autocorrelation[lag] > maxCorr)
				{
					maxLag = lag;
					maxCorr = autocorrelation[lag];
				}
			}

			// Calculate the pitch based on the detected lag
			double pitch = _sampleRate / (double)maxLag;
			return pitch;
		}
	}
}


