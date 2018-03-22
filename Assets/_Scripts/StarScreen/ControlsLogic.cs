using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControlsLogic : MonoBehaviour 
{
	private StarScreenUIHandler startScreen;

	private void Start()
	{
		startScreen = GetComponent<StarScreenUIHandler> ();
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			startScreen.disableScreen (4);
		}
	}
}
