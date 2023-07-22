using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float speed = 5;
    public float jump = 5;
    bool isPowerupUnlocked = false;
    float powerupEndTime = 0f;

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
        // All'inizio del gioco, assicurati che il potenziamento sia disattivato
        isPowerupUnlocked = PlayerPrefs.GetInt("PowerupUnlocked", 0) == 1;
        powerupEndTime = PlayerPrefs.GetFloat("PowerupEndTime", 0f);

        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animNewBie = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Controlla se il salto potenziato è sbloccato e se il tempo di potenziamento è ancora valido
        if ((Input.GetKeyDown(KeyCode.Space) || salto == true) && isGrounded)
        {
            if (isPowerupUnlocked && Time.time < powerupEndTime)
            {
                // Esegui il salto potenziato
                rb.AddForce(new Vector2(0, jump * 2), ForceMode2D.Impulse);
            }
            else
            {
                // Esegui il salto normale
                rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            }

            animNewBie.SetTrigger("Salto");
            salto = false;
        }

        // Verifica se il potenziamento è scaduto e resetta il potenziamento
        if (isPowerupUnlocked && Time.time >= powerupEndTime)
        {
            isPowerupUnlocked = false;
            PlayerPrefs.SetInt("PowerupUnlocked", 0); // Imposta il potenziamento a "non sbloccato"
            PlayerPrefs.Save();
        }

        // Variabile di atterraggio
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // Movimento orizzontale
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Orienta il personaggio
        if (moveInput > 0)
        {
            rend.flipX = false;
            animNewBie.SetInteger("camminata", 1);
        }
        else if (moveInput < 0)
        {
            rend.flipX = true;
            animNewBie.SetInteger("camminata", 1);
        }
        else
        {
            animNewBie.SetInteger("camminata", 0);
        }
    }

    public void eseguiSalto()
    {
        salto = true;
    }
}
