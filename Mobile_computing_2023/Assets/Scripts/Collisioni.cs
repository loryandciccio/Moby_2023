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
            Debug.Log("Ho colpito una mosca");
            Destroy(collision.gameObject);
            gameManager.ScriviValoreMosche();
            
        }

        if (collision.gameObject.tag == "moneta")
        {
            gameManager.monetePrese++;
            Debug.Log("Ho colpito una moneta");
            Destroy(collision.gameObject);
            gameManager.ScriviValoreMonete();
            
        }

        if (collision.gameObject.tag == "cibo")
        {
            gameManager.energia += 10;
            Debug.Log("Ho colpito un cibo");
            Destroy(collision.gameObject);
         }
    }
    //Se voglio che l'oggetto venga colpito ma il personaggio ci può passare sopra abilito IsTrigger sull'oggetto
    //e faccio questo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "puntina")
        {
            gameManager.energia -= 10;
            Debug.Log("Ho colpito una puntina");
        }
    }

}
