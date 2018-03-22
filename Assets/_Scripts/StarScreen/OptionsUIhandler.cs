using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUIhandler : MonoBehaviour 
{
	[SerializeField]private GameObject[] optionPanels;

	private void Start()
	{
		hidePanel (0,true);
	}

	public void enablePanel(int index)
	{
		optionPanels [index].SetActive (true);
	}

	public void hidePanel(int index, bool all)
	{
		if (all)
		{
			for (int i = 0; i < optionPanels.Length; i++)
			{
				optionPanels [i].SetActive (false);
			}
		}
		else
		{
			optionPanels [index].SetActive (false);
		}
	}
}
