using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollision : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("destroy", 3f, 1f);
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }

}
