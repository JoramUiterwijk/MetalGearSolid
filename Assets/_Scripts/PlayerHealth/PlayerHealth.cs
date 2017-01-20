using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	private PlayerHealthUI healthUI;

	private float health;
	public float getHealth{get{return health;}}

	private void Start()
	{
		health = 100;

		healthUI = GetComponent<PlayerHealthUI> ();
	}

	public void doDamage(int damage)
	{
		if (health > 0)
		{
			health -= damage;
		}
		if (health < 0)
		{
			health = 0;
		}
		healthUI.updateBar ();
	}
}
