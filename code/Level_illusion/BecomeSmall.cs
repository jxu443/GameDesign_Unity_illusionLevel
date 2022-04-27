using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeSmall : MonoBehaviour
{
    public Transform player;
    float dist;
    bool transitioning;
    Vector3 oriScale;
    Vector3 endScale = new Vector3(0.1f, 0.1f, 0.1f);
    // Start is called before the first frame update
    void Start()
    {
        GameObject doorSmall = GameObject.Find("DoorSmall");
        dist = Vector3.Distance(transform.position, doorSmall.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (transitioning) {
            float progress = Vector3.Distance(player.position, transform.position)/dist;
            if (progress > 0.98) transitioning = false;
            else {
                Vector3 scale = Vector3.LerpUnclamped(oriScale, endScale, progress);
                player.localScale = Vector3.Scale(oriScale, scale);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            transitioning = true;
            oriScale = other.transform.localScale;
        }
    }
}
