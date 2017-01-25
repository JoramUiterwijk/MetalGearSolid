using System.Collections;
using UnityEngine;

public class OpenStartScene : MonoBehaviour 
{
	private StarScreenUIHandler startScreen;
	private ButtonHoverLogic buttonLogic;

	private void Start()
	{
		startScreen = GetComponent<StarScreenUIHandler> ();
		buttonLogic = GetComponent<ButtonHoverLogic> ();
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			startScreen.enableScreen (0);
			startScreen.disableScreen (3);
			buttonLogic.enabled = true;
		}
	}
}
