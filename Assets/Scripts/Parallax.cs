using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    bool isParallaxed = false;
    public static bool checkRotationOrNot = true;
    public GameObject cube;
    public GameObject backImage;

    // Update is called once per frame
    void Update()
    {
        if (isParallaxed)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f * Time.deltaTime, 0f);
        }
    }

    public void startParallax()
    {
        cube.transform.localEulerAngles = new Vector3(0, 0, 0);
        checkRotationOrNot = false;
        isParallaxed = true;
        float time = 1;
        float parallaxPosition = transform.position.y;
        while (time > 0)
        {
            time -= Time.deltaTime;
            parallaxPosition -= time;
            transform.position = new Vector3(transform.position.x, 0f, 0f);
        }
        backImage.SetActive(false);
    }
    public void stopParallax()
    {
        checkRotationOrNot = true;
        isParallaxed = false;
        transform.position = new Vector3(transform.position.x, 15f, 0f);
        backImage.SetActive(true);
    }
}
