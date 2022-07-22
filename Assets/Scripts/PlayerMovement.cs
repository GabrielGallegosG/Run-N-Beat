using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Variables p�blicas
    public Rigidbody2D rbody;
    public Animator anim;
    public float speed=0;
    public float jumpForce;
    public float walkSpeed;
    //public Transform pies;

    public Vector2 pies;
    public LayerMask layerPiso;
    public float radioColision;

    // Variables boleanas
    public bool enSuelo = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   private void Update()
    {
        
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

        //Aparece el boton de restart cuando Zorrito muere
        //SE TIENE QUE VALIDAR QUE ZORRITO MUERA CUANDO UN ENEMIGO LO GOLPEA, DENTRO DE ESA CONDICION SE AGREGA LA SIGUIENTE LINEA, AL FINAL.
        SceneManager.LoadScene("RestartScene");
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Enemy"){
            if(enSuelo==false){
                Destroy(other.gameObject);
            }else{
                 Muerte();      
            }
           
        }
    }
    private void Muerte(){
        anim.SetBool("muerte", true);
       
    }

}
