using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBullets : MonoBehaviour 
{
	private GameObject[] backgroundBullets;
	private List<GameObject> forgroundBullets;
	[SerializeField]private Transform canvas;
	[SerializeField]private GameObject[] bulletPrefabs;

	private void Start()
	{
		if (bulletPrefabs.Length != 2)
		{
			throw new UnityException ("To many or to few bullets, make sure you have two different bullets");
			return;
		}
		backgroundBullets = new GameObject[15];
		forgroundBullets = new List<GameObject> ();
		createBullets (0);
		createBullets (1);
	}

	public void createBullets(int index)
	{
		for (int i = 0; i < backgroundBullets.Length; i++)
		{
			GameObject backBullet = Instantiate (bulletPrefabs [index]) as GameObject;
			backBullet.transform.SetParent (canvas);
			backBullet.GetComponent<RectTransform> ().localPosition = new Vector3 (i * -10 + 80, -62, 0);
			backBullet.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
			if (index == 0)
			{
				backgroundBullets [i] = backBullet;
			}
			if (index == 1)
			{
				forgroundBullets.Add (backBullet);
			}
		}
	}

	public void removeBullet()
	{
		if (forgroundBullets.Count > 0)
		{
			Destroy (forgroundBullets [forgroundBullets.Count - 1]);
			forgroundBullets.RemoveAt (forgroundBullets.Count - 1);
		}
	}
}
