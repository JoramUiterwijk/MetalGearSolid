using System.Collections;
using UnityEngine;

public class CalculateLocation : MonoBehaviour 
{
	[Tooltip("Put the Object that the minimap should follow in here")]
	[SerializeField]private Transform personToFollow;
	public float zoomLevel = 10f;
	//public float getZoomLevel{get{return getZoomLevel;}}

	public Vector2 transformPosition(Vector3 position)
	{
		Vector3 offset = position - personToFollow.position;
		Vector2 newPosition = new Vector2(offset.x,offset.z);
		newPosition *= zoomLevel;
		return newPosition;
	}
}
