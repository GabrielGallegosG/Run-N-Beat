using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaMuerte : MonoBehaviour
{
     public AudioClip Death;

     private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Player"){
            foreach(ContactPoint2D punto in other.contacts){
                AudioManager.Instance.ReproducirSonido(Death);
                         other.gameObject.GetComponent<PlayerMovement>().Muerte();    
                }
            }   
        }       
    }

