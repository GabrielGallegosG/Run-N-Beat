using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzas : MonoBehaviour
{
 

     Rigidbody2D rbody;


     private void Start(){
        rbody=GetComponent<Rigidbody2D>();
     }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="Player"){
            rbody.gravityScale=35;
        }
    }
    

 
}
