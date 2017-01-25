using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class volumeLogic : MonoBehaviour 
{
	[SerializeField]private Slider firstItem;

	public void selectFirstItem()
	{
		firstItem.Select ();
	}
}
