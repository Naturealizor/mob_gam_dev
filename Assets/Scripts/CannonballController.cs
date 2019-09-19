using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    void Start() {
        Destroy(this.gameObject, 5);
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Target")) {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
