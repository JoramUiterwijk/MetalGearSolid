//From www.freetimedev.com
//Written by Dani van der Werf
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadUI : MonoBehaviour 
{
	private LoadFile loadScript;
	[SerializeField]private Button[] buttons;

	private void Start()
	{
		loadScript = GetComponent<LoadFile> ();
		for(int i = 0; i < buttons.Length; i++)
		{
			int temp = i;
			buttons [temp].onClick.AddListener (delegate(){loadScript.load(temp);});
		}
	}
}
