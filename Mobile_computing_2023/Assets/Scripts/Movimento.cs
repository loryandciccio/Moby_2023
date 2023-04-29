using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float speed = 5;
    public float jump = 5;
    SpriteRenderer renderer;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // se il tasto premuto e' freccia destra sposto il player di 1 a destra
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // qui cambio la position del player
            transform.Translate(new Vector3(speed*Time.deltaTime, 0, 0));
            // con Time.delta.Time ricavo l'unita di spostamento al secondo
            renderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // qui cambio la position del player
            transform.Translate(new Vector3(-speed*Time.deltaTime, 0, 0));
            renderer.flipX = true;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("salto");
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }
}
