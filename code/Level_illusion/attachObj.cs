using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachObj : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject objToAttach;

    Transform oriParent;
    Vector3 lastPos;
    bool hasAttached = false;
    bool hasLeft = false;
    void Start()
    {
        oriParent = objToAttach.transform.parent;
        lastPos = transform.position;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            hasAttached = true;
            objToAttach.transform.parent = transform; 
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            print("enter");
            hasLeft = true;
            objToAttach.transform.parent = oriParent; 
            objToAttach.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    //Update is called once per frame
    void Update()
    {
        if (hasAttached && !hasLeft) {
            Vector3 currPos = transform.position;
            if (currPos.Equals(lastPos)) {
                Debug.Log("detach due to not moving");
                objToAttach.transform.parent = oriParent; 
            } else {
                
                objToAttach.transform.parent = transform; 
            }
            lastPos = currPos;
        }
    }
}
