//From www.freetimedev.com
//Written by Dani van der Werf
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StarScreenUIHandler : MonoBehaviour 
{
	[SerializeField]private Button[] buttons;
	[SerializeField]private GameObject[] allPanels;

	private LoadSceneVisible loadScript{get;set;}
	private CloseGame closeScript{get;set;}

	private void Start()
	{
		for (var i = 0; i < allPanels.Length; i++)
		{
			disableScreen (i);
		}
		enableScreen (3);

		setReferences ();
		setButtonListeners ();
	}

	private void setReferences()
	{
		loadScript = GetComponent<LoadSceneVisible> ();
		closeScript = GetComponent<CloseGame> ();
	}

	private void setButtonListeners()
	{
		buttons [0].onClick.AddListener (delegate(){loadScript.LoadScene(1); allPanels[1].SetActive(true);});
		buttons [1].onClick.AddListener (delegate(){allPanels[2].SetActive(true);});
		buttons [2].onClick.AddListener (delegate(){closeScript.quit();});
	}

	public void enableScreen(int index)
	{
		allPanels [index].SetActive (true);
	}

	public void disableScreen(int index)
	{
		allPanels [index].SetActive (false);
	}
}
