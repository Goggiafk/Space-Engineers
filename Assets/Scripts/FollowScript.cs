using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject cube;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cube.transform.position.x >= 2.5f)
        {
            cube.transform.position = new Vector3(2.5f, cube.transform.position.y, 0f);
        }
        if (cube.transform.position.x <= -2.5f)
        {
            cube.transform.position = new Vector3(-2.5f, cube.transform.position.y, 0f);
        }
        if (cube.transform.position.y >= 0f)
        {
            cube.transform.position = new Vector3(cube.transform.position.x, 0f, 0f);
        }
        if (cube.transform.position.y <= -3f )
        {
            cube.transform.position = new Vector3(cube.transform.position.x, -3f, 0f);
        }
        if (Input.touchCount > 0)
        {
            Touch touch1 = Input.GetTouch(0);
            if (touch1.phase == TouchPhase.Moved)
            {
                cube.transform.position = new Vector3(cube.transform.position.x + touch1.deltaPosition.x * speed * Time.deltaTime, cube.transform.position.y + touch1.deltaPosition.y * speed * Time.deltaTime, 0f);
            }
        }
        //transform.LookAt(cube.transform.position);
        //transform.LookAt(cube.transform.position);
    }
}
