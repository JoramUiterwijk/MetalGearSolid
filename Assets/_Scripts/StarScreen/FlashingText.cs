using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour 
{
	[SerializeField]private Text textToFlash;

	private void Start()
	{
			StartCoroutine (fade ("out"));
	}

	private IEnumerator fade(string type)
	{
		float duration = 1f;
		float currentTime = 0f;

		if (type == "out")
		{
			while (currentTime < duration)
			{
				float alpha = Mathf.Lerp (1f, 0f, currentTime / duration);
				textToFlash.color = new Color (textToFlash.color.r, textToFlash.color.g, textToFlash.color.b, alpha);
				currentTime += Time.deltaTime;
				yield return null;
			}
			StartCoroutine (fade ("in"));
			yield break;
		}

		if (type == "in")
		{
			while (currentTime < duration)
			{
				float alpha = Mathf.Lerp (0f, 1f, currentTime / duration);
				textToFlash.color = new Color (textToFlash.color.r, textToFlash.color.g, textToFlash.color.b, alpha);
				currentTime += Time.deltaTime;
				yield return null;
			}
			StartCoroutine (fade ("out"));
			yield break;
		}
	}
}
