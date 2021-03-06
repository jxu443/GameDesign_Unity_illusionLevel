using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player;
	public Transform reciever;

	private bool playerIsOverlapping = false;

	// Update is called once per frame
	void FixedUpdate () {
		if (playerIsOverlapping)
		{
			Vector3 portalToPlayer = player.position - transform.position;
			
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            //Debug.Log("dotproduct val is " + dotProduct);

			float angelBetween = Vector3.Angle(portalToPlayer,transform.forward);
			//Debug.Log("angle between is " + angelBetween); 
			
			// If this is true: The player has moved across the portal
			if (dotProduct < 0f)
			{
				// Teleport him!
				//float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
				//rotationDiff += 180;
				//player.Rotate(Vector3.up, 360);

				//Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
				player.position = reciever.position;

				playerIsOverlapping = false;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = false;
		}
	}
}