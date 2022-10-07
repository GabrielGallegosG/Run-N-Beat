using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Musica : MonoBehaviour
{
    public AudioClip BGM;

    

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Player"){
             Destroy(this.gameObject);  
            AudioManager.Instance.ReproducirSonido(BGM);
       
            }   
        }
}
