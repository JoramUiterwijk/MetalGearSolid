using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControlsLogic : MonoBehaviour 
{
	private StarScreenUIHandler startScreen;
	[SerializeField]private Button backButton;

	private void Start()
	{
		startScreen = GetComponent<StarScreenUIHandler> ();
		backButton.onClick.AddListener (delegate(){startScreen.disableScreen (4);});
		backButton.Select ();
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			startScreen.disableScreen (4);
		}
	}
}
