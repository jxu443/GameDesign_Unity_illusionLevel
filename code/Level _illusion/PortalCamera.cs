using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform player;

    public Transform portal;
    public Transform otherPortal; 

    void Update()
    {
        //player to portalA = cameraB to portalB
        Vector3 offset = player.position - otherPortal.position;
        transform.position = portal.position + offset;

        // float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
		// Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		// Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
		// transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}

