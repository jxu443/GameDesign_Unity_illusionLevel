using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relocation : MonoBehaviour
{

    public Transform toWhere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.transform.position = toWhere.position + new Vector3(0, 10f, 0);
        }
    }


}
