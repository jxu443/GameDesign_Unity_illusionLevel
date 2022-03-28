using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class illusionButtonPressed : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField, Range(0, 1)] int function;
    [SerializeField] AudioClip buttonAudioClip;
    private AudioSource buttonAudioSource;
    private Animator targetAnimator;
    private int numOfContact;
    void Start()
    {
        targetAnimator = this.GetComponent<Animator>();
        buttonAudioSource = this.GetComponent<AudioSource>();
        numOfContact = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            targetAnimator.SetTrigger("ButtonPressed");
            if (function == 0) {
                becomeRigid();
            } else if (function == 1) {
                pause();
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") { 
            targetAnimator.ResetTrigger("ButtonPressed");
        }
    }

    private void becomeRigid() {
        if (obj.GetComponent<Fractal>() != null) {
            obj.GetComponent<Fractal>().SetTrigger(false);
        } else {
            obj.GetComponent<BoxCollider>().isTrigger = false;
        }
        buttonAudioSource.clip = buttonAudioClip;
        buttonAudioSource.Play();
    }
    private void pause() {
        if (obj.GetComponent<Fractal>() != null) {
            obj.GetComponent<Fractal>().toggleIsAnimating();
        } else {
            obj.GetComponent<MathGraphMorph>().toggleIsAnimating();
        }
        buttonAudioSource.clip = buttonAudioClip;
        buttonAudioSource.Play();
    }
    
}
