using System.Collections;
using UnityEngine;

public class Clips : MonoBehaviour 
{
	private int clipAmount;
	public int amount
	{
		get
		{
			return clipAmount;
		}
	}

	private int clipCapacity;
	public int capacity
	{
		get
		{ 
			return clipCapacity;
		}
	}

	private int curClipCapacity;
	public int curCapasity
	{
		get
		{ 
			return curClipCapacity;
		}
	}

	private bool reloading;
	public bool isReloading
	{
		get
		{ 
			return reloading;
		}
	}

	private AmmoUI ui;
	private CreateBullets bullets;
	private void Awake()
	{
		ui = GetComponent<AmmoUI> ();
		bullets = GetComponent<CreateBullets> ();
		clipCapacity = 15;
		clipAmount = 6;
		curClipCapacity = clipCapacity;
		reloading = false;
	}

	private void Update()
	{
		if (curClipCapacity < 1&&!reloading)
		{
			ui.showEmpty (true);
			reload ();
		}
	}

	public void reload()
	{
		if (clipAmount > 0)
		{
			StartCoroutine ("reloadTime");
		}
	}

	IEnumerator reloadTime()
	{
		reloading = true;
		yield return new WaitForSeconds (1);
		clipAmount --;
		curClipCapacity = clipCapacity;
		reloading = false;
		ui.showEmpty (false);
		bullets.createBullets (1);
		ui.updateUI ();
	}

	public void addClip(int amount)
	{
		clipAmount += amount;
	}

	public void removeBullet(int amount)
	{
		curClipCapacity -= amount;
		ui.shoot ();
	}
}