using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Variables publicas
    public Rigidbody2D rbody;
    public Animator anim;
    public float speed=0;
    public float jumpForce;
    public float walkSpeed;
    
    public int score = 0;
    public Text TXTscore;

    private int cereza=0;
    [SerializeField]private Text cherryText;

    //public Transform pies;
  
    public float velocidadRebote;

    public Vector2 pies;
    public LayerMask layerPiso;
    public float radioColision;
    public AudioClip sonidoCherry;

    // Variables boleanas
    public bool enSuelo = true;

    // Update is called once per frame
   private void Update()
    {
        TXTscore.text = "Score: " + score;

        cherryText.text = cereza.ToString();
        rbody.velocity = new Vector2(speed, rbody.velocity.y);
        CheckGround();
        if(enSuelo)
        {
            anim.SetBool("saltar", false);
         
        }
        else
        {
            if(rbody.velocity.y > 0)
            {
                anim.SetBool("saltar", true);
                  anim.SetFloat("velocidadVertical",1);
            }
            else if(rbody.velocity.y < 0)
            {
                anim.SetBool("saltar", true);
                anim.SetFloat("velocidadVertical",-1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cerezas")
        {
            Destroy(collision.gameObject);
            cereza += 1;
            cherryText.text = cereza.ToString();
            AudioManager.Instance.ReproducirSonido(sonidoCherry);
            score = score + 25;
        }
    }

    private void OnJump()
    {
        Debug.Log("Jump!");
        if (enSuelo == true)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
        }
    }

     private void OnMove(InputValue inputValue)
    {
        float moveValue=inputValue.Get<float>();
        Debug.Log("Run!");
        speed = moveValue  * walkSpeed;

        if(moveValue < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        else if(moveValue > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
        {
            anim.SetBool("correr", false);
        }
 
 
        if(enSuelo)
        {
            anim.SetBool("correr", true);
            if(moveValue==0){
                anim.SetBool("correr",false);
            }
        }
    }

    private void CheckGround()
    {
        enSuelo = Physics2D.OverlapCircle((Vector2)transform.position + pies, radioColision, layerPiso);
    }

    public void WhenZorritoDies() {

           GetComponent<Rigidbody2D>().mass = 10000;
        //Aparece el boton de restart cuando Zorrito muere
        //SE TIENE QUE VALIDAR QUE ZORRITO MUERA CUANDO UN ENEMIGO LO GOLPEA, DENTRO DE ESA CONDICION SE AGREGA LA SIGUIENTE LINEA, AL FINAL.
        SceneManager.LoadScene("RestartScene");
    }

    public void Rebote(){
        rbody.velocity = new Vector2(rbody.velocity.x, velocidadRebote);
    }

    /*private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Enemy"){
            if(enSuelo==false){
                Destroy(other.gameObject);
            }else{
                 Muerte();      
            }
           
        }
    }*/

    public void Muerte(){
        anim.SetBool("muerte", true);
       
    }

    public void Final(){
        anim.SetBool("final", true);
        
        SceneManager.LoadScene("MainMenuScene");
    }

}
