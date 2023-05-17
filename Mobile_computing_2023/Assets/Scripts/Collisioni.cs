using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisioni : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //se il tag dell'oggetto con cui sono entrato in collisione aggiungo una mosca
        //ad una variabile mosca che si incrementa
        if (collision.gameObject.tag == "mosca")
        {
            gameManager.moscheCatturate++;
            Destroy(collision.gameObject);
            Debug.Log("Ho colpito una mosca");
        }

        if (collision.gameObject.tag == "moneta")
        {
            gameManager.monetePrese++;
            Destroy(collision.gameObject);
            Debug.Log("Ho colpito una moneta");
        }

        if (collision.gameObject.tag == "cibo")
        {
            gameManager.energia += 10;
            Destroy(collision.gameObject);
            Debug.Log("Ho colpito il cibo");
        }
    }
    //Se voglio che l'oggetto venga colpito ma il personaggio ci può passare sopra abilito IsTrigger sull'oggetto
    //e faccio questo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "puntina")
        {
            gameManager.energia -= 20;
            Debug.Log("Ho colpito una puntina");
        }
    }

}
