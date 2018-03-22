using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour 
{
	private CreateBullets removeBullets;
	private Clips clips;
	private int total;
	[SerializeField]private Text totalAmmo;
	[SerializeField]private Image emptyImage;

	private void Start()
	{
		clips = GetComponent<Clips> ();
		removeBullets = GetComponent<CreateBullets> (); 
		showEmpty (false);
		total = clips.amount * clips.capacity + clips.curCapasity;
		updateUI ();
	}

	public void updateUI()
	{
		int curCapasity = clips.amount * clips.capacity + clips.curCapasity;
		totalAmmo.text = curCapasity+"/"+total;
	}

	public void shoot()
	{
		updateUI ();
		removeBullets.removeBullet ();
	}
		
	public void showEmpty(bool value)
	{
		emptyImage.gameObject.SetActive (value);
	}
}
