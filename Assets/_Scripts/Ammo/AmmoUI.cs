using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour 
{
	private Clips clips;
	[SerializeField]private Text totalAmmo;
	[SerializeField]private Text currentClip;
	[SerializeField]private Image bullets;

	private void Start()
	{
		clips = GetComponent<Clips> ();
		updateUI ();
	}

	private void Update()
	{
		updateUI ();
	}

	private void updateUI()
	{
		float bulletWidth = (float)(clips.curCapasity) / (float)(clips.capacity);
		bullets.fillAmount = bulletWidth;
		int total = (clips.amount-1) * clips.capacity + clips.curCapasity;
		totalAmmo.text = clips.curCapasity+"/"+total;
	}
}
