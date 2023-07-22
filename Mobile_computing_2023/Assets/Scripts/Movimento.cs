using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float speed = 5;
    public float jump = 5;

    SpriteRenderer rend;
    Rigidbody2D rb;
    Animator animNewBie;


    bool premoDestro = false;
    bool premoSinistro = false;
    bool salto = false;

    bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animNewBie = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //variabile atterraggio
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // se il tasto premuto e' freccia destra sposto il player di 1 a destra
        if (Input.GetKey(KeyCode.RightArrow) || premoDestro == true)
        {
            // qui cambio la position del player
            transform.Translate(new Vector3(speed*Time.deltaTime, 0, 0));
            // con Time.delta.Time ricavo l'unita di spostamento al secondo
            rend.flipX = false;
            animNewBie.SetInteger("camminata", 1);
        }
       
        else if (Input.GetKey(KeyCode.LeftArrow) || premoSinistro == true )
        {
            // qui cambio la position del player
            transform.Translate(new Vector3(-speed*Time.deltaTime, 0, 0));
            rend.flipX = true;
            animNewBie.SetInteger("camminata", 1);

        }
        else
        {
            animNewBie.SetInteger("camminata", 0);
        }
        if ((Input.GetKeyDown(KeyCode.Space) || salto == true) && isGrounded)
        {
            Debug.Log("salto");
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            animNewBie.SetTrigger("Salto");
            salto = false;
        }
    }
    public void cliccoDestro()
    {
        premoDestro = true;
    }
    public void LascioDestro()
    {
        premoDestro = false;
    }
    public void cliccoSinistro()
    {
        premoSinistro = true;
    }
    public void LascioSinistro()
    {
        premoSinistro = false;
    }

    public void eseguiSalto()
    {
        salto = true;
    }
}
