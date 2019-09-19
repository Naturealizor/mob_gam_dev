using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{

    float timer = 0f;
    Vector3 position;
    float width;
    float height;
    bool timerIsGoing;
    Color originalColor;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        width = (float)Screen.width / 4f;
        height = (float)Screen.height / 4f;
        position = new Vector3(0,0,0);

        // Set the renderer to the one on this object.
        rend = this.GetComponent<Renderer>();
        // Set the original color
        originalColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsGoing) {
            timer += Time.deltaTime;}
        if(timer > 4) {
            rend.material.color = Color.green;
            } 
        else if(timer > 2) {
            rend.material.color = Color.black;
            }
        if(Input.touchCount > 0) {
            Debug.Log("Something's touching me!");
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began) {
                rend.material.color = Color.yellow;
                timerIsGoing = true;
            }
            // if(touch.phase == TouchPhase.Moved) {
            //     Vector2 pos = touch.position;
            //     Debug.Log("Touch position = " + touch.position);

            //     pos.x = (pos.x - width) / width;
            //     pos.y = (pos.y - height) / height;
            //     position = new Vector3(pos.x * 3f, pos.y * 3f, 0);

            //     this.transform.position = position;
            // }

            if(touch.phase == TouchPhase.Ended) {
                rend.material.color = originalColor;
                timerIsGoing = false;
                timer = 0;
            }
        }
        // resizing cube with 2 finger touch
        if(Input.touchCount <= 1) {
            transform.localScale = Vector3.one;
        }
        if(Input.touchCount == 2) {
            transform.localScale = Vector3.one * 2;
        }
        if(Input.touchCount == 3) {
            transform.localScale = Vector3.one * 3;
        }
    }
}
