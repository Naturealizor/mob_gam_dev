using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    float shotPower = 1;
    bool timerIsGoing = false;
    float timer = 0;

    public Rigidbody cannonball;
    public float shotPowerMultiplier = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsGoing) {
            if(timer > 5) timer = 5;
            if(timer < 2.5f) timer = 2.5f;
            timer += Time.deltaTime;
            shotPower = timer;
            
        }

        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began) {
                timerIsGoing = true;
            }
            if(touch.phase == TouchPhase.Ended) {
                timerIsGoing = true;
                Shoot();
                timer = 0;
            }
        }
    }

    void Shoot() {
        Rigidbody ball = Instantiate(cannonball, this.transform.position, this.transform.rotation);
        ball.AddRelativeForce(Vector3.back * shotPowerMultiplier * shotPower, ForceMode.Impulse);
    }
}
