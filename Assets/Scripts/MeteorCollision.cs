using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollision : MonoBehaviour
{
    private Vector2 screenBounds;
    private Rigidbody rb;
    public static float speedOfMeteors = 0;
    float reversedSpeedOfMeteors;
    void Start()
    {
        speedOfMeteors = MeteorSpawning.scoreCount / 150;
        reversedSpeedOfMeteors = speedOfMeteors - (2 * speedOfMeteors) - 1;
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(reversedSpeedOfMeteors, reversedSpeedOfMeteors, reversedSpeedOfMeteors);
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
