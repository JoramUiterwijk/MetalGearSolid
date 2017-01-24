using System.Collections;
using UnityEngine;

public class OpenStartScene : MonoBehaviour 
{
	private StarScreenUIHandler startScreen;
	private void Start()
	{
		startScreen = GetComponent<StarScreenUIHandler> ();
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			startScreen.enableScreen (0);
			startScreen.disableScreen (3);
		}
	}
}
