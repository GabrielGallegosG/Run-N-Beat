using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionDelMuro : MonoBehaviour
{
    public static bool act = false;
    public float speed;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
