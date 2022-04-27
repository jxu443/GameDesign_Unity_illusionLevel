using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

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
        numOfContact++;
        if (numOfContact <= 1) { // other.tag == "Player"
            targetAnimator.SetTrigger("ButtonPressed");
            if (function == 0) {
                becomeRigid();
            } else if (function == 1) {
                pause();
            }
        }
    }

    void OnTriggerExit(Collider other) {
        numOfContact--;
        if (numOfContact <= 0) { 
            targetAnimator.ResetTrigger("ButtonPressed");
        }
    }

    private void becomeRigid() {
        if (obj.GetComponent<Fractal>() != null) {
            obj.GetComponent<Fractal>().SetTrigger(false);
        } else {
            Debug.Log("graph cubs becomes rigid");
            obj.GetComponent<MathGraphMorph>().NotIsTrigger();
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
