using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeWall : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float speed;
    public bool activation;

    // Update is called once per frame
    void Update()
    {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.GetComponent<Rigidbody2D>().velocity.y);
    }
}
