using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Double_Tap : MonoBehaviour
{

    float tapTimer = 0f;
    bool tapped = false;
    bool grounded = false;
    Rigidbody rb;
    public int forwardSpeed = 20;
    public int jumpPower = 5;
    public float doubleTapInterval = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
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

        // && grounded
        if(Input.anyKeyDown && grounded) {
            // a wild tap appears! If a tap happens
            if(tapped) {
                DoubleTap();
                tapped = false;
            } else {
                tapped = true;
            }   
        }
    }

    void FixedUpdate() {
        rb.AddRelativeForce(Vector3.right * forwardSpeed);
    }

    void SingleTap() {
        Debug.Log("<color=red>Single Tap</color>");
        Debug.Log("Timer = " + tapTimer);
        tapTimer = 0;

        // change the color to a random color
        // this.GetComponent<Renderer>().material.color = Random.ColorHSV();

        // Code the jump mechanic
        rb.AddRelativeForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    void DoubleTap () {
        Debug.Log("<color=blue>Double Tap</color>");
        Debug.Log("Timer = " + tapTimer);
        tapTimer = 0;

        rb.AddRelativeForce(Vector3.up * jumpPower * 2, ForceMode.Impulse);
        // increase the size by 20%
        // this.transform.localScale += Vector3.one * 0.2f;
        // if scale is greater than 5, reset to 1
        // if(this.transform.localScale.x > 5) {
        //     this.transform.localScale = Vector3.one;
        // }
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ground")) {
            grounded = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Ground")) {
            grounded = false;
        }
    }
}
