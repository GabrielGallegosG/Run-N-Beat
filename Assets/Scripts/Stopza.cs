using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopza : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Player"){
            foreach(ContactPoint2D punto in other.contacts){
                         other.gameObject.GetComponent<PlayerMovement>().Final();    
                }
            }   
        }      
}
