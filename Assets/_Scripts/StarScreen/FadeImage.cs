using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour 
{
	[SerializeField]private GameObject events;
	[SerializeField]private Image splashImage, background;
	private float fadeDuration, waitTime, fullAlpha, emptyAlpha;
	private OpenStartScene script;

	private void Start()
	{	
		script = GetComponent<OpenStartScene> ();
		script.enabled = false;
		events.SetActive (false);
		fadeDuration = 1f;
		waitTime = 5f;
		fullAlpha = 1f;
		emptyAlpha = 0f;
		StartCoroutine (fade());
	}

	private IEnumerator fade()
	{
		splashImage.canvasRenderer.SetAlpha (0f);
		fadeIn ();
		yield return new WaitForSeconds (waitTime);
		fadeOut ();
		yield return new WaitForSeconds (2f);
		Destroy (splashImage.gameObject);
		Destroy (background.gameObject);
		events.SetActive(true);
		script.enabled = true;
		Destroy (this);
	}

	private void fadeIn()
	{
		splashImage.CrossFadeAlpha (fullAlpha, fadeDuration, false);
	}

	private void fadeOut()
	{
		splashImage.CrossFadeAlpha (emptyAlpha, fadeDuration, false);
	}
}
