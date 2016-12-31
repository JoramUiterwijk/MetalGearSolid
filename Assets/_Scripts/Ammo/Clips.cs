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
	private void Start()
	{
		clipCapacity = 15;
		clipAmount = 5;
		curClipCapacity = clipCapacity;
		reloading = false;
	}

	private void Update()
	{
		if (curClipCapacity < 1&&clipAmount>0&&!reloading)
		{
			StartCoroutine ("reloadTime");
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
	}

	public void addClip(int amount)
	{
		clipAmount += amount;
	}

	public void removeBullet(int amount)
	{
		curClipCapacity -= amount;
	}
}