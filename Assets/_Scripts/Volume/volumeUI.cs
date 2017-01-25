using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class volumeUI : MonoBehaviour 
{
	[SerializeField]private Slider volumeSlider;
	[SerializeField]private Text volumeText;
	private float volume;
	public float GetVolume{get{return volume;}}

	private void Start()
	{
		volume = volumeSlider.value = 0.5f;
		setEventListeners ();
		updateText ();
	}

	private void setEventListeners()
	{
		volumeSlider.onValueChanged.AddListener (delegate(float temp)
		{
			volume = volumeSlider.value;
			updateText();
		});	
	}

	private void updateText()
	{
		volumeText.text = "Volume: " + (int)(volume * 100);
	}
}
