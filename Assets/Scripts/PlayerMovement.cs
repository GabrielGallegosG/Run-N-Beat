using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables públicas
    public Rigidbody2D rbody;
    public float speed;
    public float jumpForce;
    public LayerMask layer;

    //Variables boleanas
    private bool onFloor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        //SALTO
        if (Input.GetKeyDown("space"))
        {
            if (onFloor)
            {
                Debug.Log("Jump!");
                rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
            }
        }
        //MOVIMIENTO HACIA LA DERECHA
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void CheckGround()
    {

        RaycastHit2D hit = Physics2D.Raycast(rbody.position, Vector2.down, 8);
        Debug.DrawRay(rbody.position, Vector2.down, Color.yellow, 8);
        if (hit.collider != null)
        {
            onFloor = true;
        }
        else
        {
            onFloor = false;
        }
    }
}
