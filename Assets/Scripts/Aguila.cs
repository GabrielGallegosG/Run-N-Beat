using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aguila : MonoBehaviour
{
    
    [SerializeField] private float velocidadMovimiento;

    [SerializeField] private Transform[] puntosMovimiento;

    [SerializeField] private Transform[] puntosMovimiento_ataque;

    [SerializeField] private float distanciaMinima;

    private int numeroAleatorio;

    private int ruta = 0;

    private SpriteRenderer spriteRenderer;

    public Animator an;

    public static bool ataque;

    public GameObject apagar;

    void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        Girar();
    }

    
    void Update()
    {
        if(ataque == false){
            transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, velocidadMovimiento * Time.deltaTime);
            if(Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
            {
                numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
                Girar();
            }
        }
        else
        {
            velocidadMovimiento = 10;
            transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento_ataque[ruta].position, velocidadMovimiento * Time.deltaTime);
            an.SetBool("Ataque", true);
            if(Vector2.Distance(transform.position, puntosMovimiento_ataque[ruta].position) < distanciaMinima)
            {
                ruta += 1;
                if(ruta >= puntosMovimiento_ataque.Length)
                {
                    apagar.SetActive(false);
                    ruta = 0;
                    ataque = false;
                }
                Girar2();
            }
        }
    }

    private void Girar()
    {
        if(transform.position.x < puntosMovimiento[numeroAleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Girar2()
    {
        if(transform.position.x < puntosMovimiento_ataque[ruta].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
