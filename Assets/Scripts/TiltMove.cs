using UnityEngine;

public class TiltMove : MonoBehaviour
{
    // Move object using accelerometer
    public float speed = 10.0f;
    public float rotSpeed = 60f;

    Transform body;

    void Start() {
        body = this.transform.GetChild(0);
    }

    void Update()
    {
        Vector3 dir = Vector3.zero;

        // we assume that device is held parallel to the ground
        // and Home button is in the right hand

        // remap device acceleration axis to game coordinates:
        //  1) XY plane of the device is mapped onto XZ plane
        //  2) rotated 90 degrees around Y axis
        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;

        // clamp acceleration vector to unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        // Move object
        transform.Translate(Vector3.forward * (speed * 0.5f) * Time.deltaTime);  // move forward at 10m per second
        transform.Translate(dir * speed);                              // move left/right and forward/back
        body.transform.Rotate(0, 0, -dir.x * rotSpeed);               // rotate the body around z axis
    }
}