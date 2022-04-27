using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showObj : MonoBehaviour
{

    public GameObject[] objToShow;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    async void OnTriggerEnter(Collider other) {
        for (int i = 0; i < objToShow.Length; i++) {
            objToShow[i].SetActive(true);
        }
        //other.transform.rotation = Quaternion.Euler(0, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
