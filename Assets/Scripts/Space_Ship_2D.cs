using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Ship_2D : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        rb.AddRelativeForce(Vector2.up * speed);
    }
}
