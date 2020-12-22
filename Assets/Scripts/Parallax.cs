using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    bool isParallaxed = false;
    public float speedOfParallax;

    // Update is called once per frame
    void Update()
    {
        if(isParallaxed)
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f * Time.deltaTime, 0f);
    }

    public void startParallax()
    {
        isParallaxed = true;
        float time = 1;
        float parallaxPosition = transform.position.y;
        while (time > 0)
        {
            time -= Time.deltaTime;
            parallaxPosition -= time;
            transform.position = new Vector3(transform.position.x, 0f, 0f);
        }
    }
    public void stopParallax()
    {
        isParallaxed = false;
        transform.position = new Vector3(transform.position.x, 15f, 0f);
       
    }
}
