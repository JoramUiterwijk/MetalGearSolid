using System.Collections;
using UnityEngine;

public class OpenStartScene : MonoBehaviour 
{
	private StarScreenUIHandler startScreen;
	private ButtonHoverLogic buttonLogic;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
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
