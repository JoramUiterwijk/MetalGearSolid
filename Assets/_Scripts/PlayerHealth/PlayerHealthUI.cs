using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour 
{
	[SerializeField] private Image foreGround;
	private PlayerHealth health;

	private void Start()
	{
		health = GetComponent<PlayerHealth> ();
	}
		
	public void updateBar()
	{
		float fillAmount = health.getHealth / 100;
		foreGround.fillAmount = fillAmount;	
	}
}
