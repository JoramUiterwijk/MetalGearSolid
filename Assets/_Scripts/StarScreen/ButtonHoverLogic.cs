using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverLogic : MonoBehaviour 
{
	[SerializeField]private Button[] buttons;
	[SerializeField]private GameObject[] sprites;
	private int i;

	private void Start()
	{
		i = 0;
		activeSprite (0,false,true);
		selectButton (i);
	}

	private void activeSprite(int index, bool value, bool all)
	{
		if (all)
		{
			for (int i = 0; i < sprites.Length; i++)
			{
				sprites [i].SetActive (value);
			}
		} 
		else
		{
			sprites [index].SetActive (value);
		}
	}

	public void selectButton(int index)
	{
		buttons [index].Select ();
		activeSprite (0,false,true);
		activeSprite (index,true,false);
		i = index;
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			i++;
			if (i > buttons.Length-1)
			{
				i = 0;
			}
			selectButton (i);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			i--;
			if (i < 0)
			{
				i = buttons.Length-1;
			}
			selectButton (i);
		}

	}
}
