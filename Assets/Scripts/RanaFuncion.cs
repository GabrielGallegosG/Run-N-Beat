using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanaFuncion : MonoBehaviour
{
    // Variables publicas
    public Rigidbody2D rbody;
    public Animator anim;
    public float jumpForce;
    public float speed;

    public Vector2 ancas;
    public LayerMask layerPiso;
    public float radioColision;
    public AudioClip BGM;

    // Variables boleanas
    public bool enSuelo = true;


    // Update is called once per frame
    void Update()
    {
        rbody.velocity = new Vector2(speed,jumpForce);
        CheckGround();
        if(enSuelo)
        {
            anim.SetBool("salto", false);
         
        }
        else
        {
            if(rbody.velocity.y > 0)
            {
                anim.SetBool("salto", true);
                anim.SetBool("caida",false);
                
            }
            else if(rbody.velocity.y < 0)
            {
                anim.SetBool("salto", false);
                anim.SetBool("caida",true);
            }
        }
    }

    public void Saltar(){
        if (enSuelo == true)
        {
           
            rbody.velocity = new Vector2(speed, jumpForce);
        }

    }

    private void CheckGround(){
        enSuelo = Physics2D.OverlapCircle((Vector2)transform.position + ancas, radioColision, layerPiso);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Player"){
            foreach(ContactPoint2D punto in other.contacts){
                if(punto.normal.y<=-0.9){
                    other.gameObject.GetComponent<PlayerMovement>().Rebote();  
                    anim.SetBool("muerte", true);
                    
                }else{
                    other.gameObject.GetComponent<PlayerMovement>().Muerte();    
                }
            }   
        }       
    }

    private void Morir(){
        Destroy(this.gameObject);  
        AudioManager.Instance.ReproducirSonido(BGM);
    }
}
