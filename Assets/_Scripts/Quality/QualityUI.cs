//From www.freetimedev.com
//Written by Dani van der Werf
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Show which quality level the game is currently on.
public class QualityUI : MonoBehaviour 
{
	//reference to the text that will show the quality name.
	[SerializeField]private Text quality;
	//an array where we will store the quality names in.
	private string[] qualityNames{get;set;}
	//a string to tell the user its about the quality.
	private string qualityText{get;set;}

	private void Start()
	{
		//store the possible names in the array.
		qualityNames = QualitySettings.names;
		//set the quality text to Quality:
		qualityText = "Quality: ";
		//Make sure the UI tells from the beginning what the name.
		CurrentLevel ();
	}

	public void CurrentLevel()
	{
		//change the visual text to Quality: *QUALITYNAME*.  
		quality.text = qualityText + qualityNames[QualitySettings.GetQualityLevel()];
	}
}