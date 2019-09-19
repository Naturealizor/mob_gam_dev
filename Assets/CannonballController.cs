using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    void OnCollision(Collision other) {
        if(other.gameObject.CompareTag("Target")) {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
