using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a new one! It adds a component when you add this
// script to something else.
[RequireComponent(typeof(AudioSource))]
public class Play_Sounds : MonoBehaviour
{
    AudioSource aud;
    public AudioClip[] sounds;

    // start is called before the first frame update
    void Start() {
        aud = this.GetComponent<AudioSource>();
    }

    // update is called once per frame
    void Update() {
        if(Input.anyKeyDown) {
            aud.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
            // Destroy(this.gameObject, 1);
            // Destroy(this.GetComponent<Renderer>());
        }
    }
}
