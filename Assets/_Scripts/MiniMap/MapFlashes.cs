using System.Collections;
using UnityEngine;

public class MapFlashes : MonoBehaviour 
{
	private Renderer objectRenderer;

	private void Start()
	{
		objectRenderer = GetComponent<Renderer> ();
		StartCoroutine ("flash");
	}

	private IEnumerator flash()
	{
		while (true)
		{
			yield return new WaitForSeconds (0.5f);
			objectRenderer.enabled = false;
			yield return new WaitForSeconds (0.1f);
			objectRenderer.enabled = true;
		}
	}
}
