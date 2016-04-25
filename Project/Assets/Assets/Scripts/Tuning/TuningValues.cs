using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class TuningValues 
{
	public static class Colors
	{
	}

	public static class Timing
	{
		public static float WrittenLetterDelay
		{
			get { return 0.02f; }
		}

		public static float WrittenLetterDelaySlow
		{
			get { return 0.05f; }
		}

		public static float WrittenLetterDelayFast
		{
			get { return 0.01f; }
		}
	}
}
