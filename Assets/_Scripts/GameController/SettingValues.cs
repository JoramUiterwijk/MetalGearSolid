using System.Collections;
using UnityEngine;

public class SettingValues
{
	private float maxVolume = 1;
	private float volume = 0.5f;
	public float VolumeValue
	{
		get{return volume;}
		set
		{
			if (value >= maxVolume)
			{
				volume = maxVolume;
			}
			else if (value <= 0)
			{
				volume = 0;
			} 
			else
			{
				volume = value;
			}
		}
	}

	private int qualityLevel = 0;
}
