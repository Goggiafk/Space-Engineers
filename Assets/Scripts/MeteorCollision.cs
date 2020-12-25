using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollision : MonoBehaviour
{
    private Vector2 screenBounds;
    private Rigidbody rb;
    public static float speedOfMeteors = 0;
    void Start()
    {
        speedOfMeteors = MeteorSpawning.scoreCount / 100;
        speedOfMeteors = speedOfMeteors - (2 * speedOfMeteors);
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(speedOfMeteors, speedOfMeteors, speedOfMeteors);
        //rb.AddForce(new Vector3(speedOfMeteors, speedOfMeteors, speedOfMeteors), ForceMode.Impulse);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (this.gameObject.transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }

}
