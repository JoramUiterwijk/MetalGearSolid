//From www.freetimedev.com
//Written by Dani van der Werf
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//get the input from the buttons.
public class HandleButtons : MonoBehaviour 
{
	//reference to the buttons.
	[SerializeField]private Button[] buttons;

	//reference to the scripts we are going to use.
	private ChangeQuality changeScript{get;set;}   
	private QualityUI uiScript{get;set;}

	private void Start()
	{
		//set reference to the scripts.
		changeScript = GetComponent<ChangeQuality>();
		uiScript = GetComponent<QualityUI>();

		//for each integer index in the button array
		for(int i=0; i<buttons.Length;i++)
		{
			int temp = i;
			//tell the buttons what they need to do when they are clicked.
			buttons[i].onClick.AddListener (delegate()
			{
				changeScript.Change (temp);
				uiScript.CurrentLevel ();
			});
		}
	}

	public void selectFirstButton()
	{
		buttons [0].Select ();
	}
}