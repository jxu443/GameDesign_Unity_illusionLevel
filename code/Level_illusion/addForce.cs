using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForce : MonoBehaviour
{
    public Rigidbody rbToPush;
    bool onArc = false;
    Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        force = Vector3.one;
        force =  Quaternion.AngleAxis(transform.rotation.x, Vector3.right) * force;
        force =  Quaternion.AngleAxis(transform.rotation.y, Vector3.up) * force;
        force =  Quaternion.AngleAxis(transform.rotation.z, Vector3.forward) * force;

    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            onArc = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            onArc = false;
            Physics.gravity = new Vector3(0, -9.8F, 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (onArc) {
            Physics.gravity = new Vector3(0, -20F, 0);
            rbToPush.AddForce(force * -100);
        } 
    }
}
