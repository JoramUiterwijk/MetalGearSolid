using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonIndicator : MonoBehaviour 
{
	[Tooltip ("Put the player or enemy you want to show up on the minimap in this slot")]
	[SerializeField] private Transform objectToIndicate;

	private CalculateLocation locationScript;
	private RectTransform rectTransform;

	private void Start()
	{
		locationScript = GetComponentInParent<CalculateLocation> ();
		rectTransform = GetComponent<RectTransform> ();
	}

	private void LateUpdate()
	{
		Vector2 newPosition = locationScript.transformPosition (objectToIndicate.position);
		rectTransform.localScale = new Vector3 (locationScript.zoomLevel, locationScript.zoomLevel, 1);
		rectTransform.localEulerAngles = new Vector3(0,0,objectToIndicate.eulerAngles.y);
		rectTransform.localPosition = newPosition;
	}
}
