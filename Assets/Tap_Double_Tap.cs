using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Double_Tap : MonoBehaviour
{

    float tapTimer = 0f;
    bool tapped = false;
    public float doubleTapInterval = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if tapped = true start tap timer
        if(tapped) {
            tapTimer += Time.deltaTime;
            // if it has been more than 0.2 seconds...
            if(tapTimer > doubleTapInterval) {
                SingleTap();
                tapped = false;
            }
        }

        if(Input.anyKeyDown) {
            // a wild tap appears! If a tap happens
            if(tapped) {
                DoubleTap();
                tapped = false;
            } else {
                tapped = true;
            }   
        }
    }

    void SingleTap() {
        Debug.Log("<color=red>Single Tap</color>");
        Debug.Log("Timer = " + tapTimer);
        tapTimer = 0;

        // change the color to a random color
        this.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
    void DoubleTap () {
        Debug.Log("<color=blue>Double Tap</color>");
        Debug.Log("Timer = " + tapTimer);
        tapTimer = 0;

        // increase the size by 20%
        this.transform.localScale += Vector3.one * 0.2f;
        // if scale is greater than 5, reset to 1
        if(this.transform.localScale.x > 5) {
            this.transform.localScale = Vector3.one;
        }
    }
}
