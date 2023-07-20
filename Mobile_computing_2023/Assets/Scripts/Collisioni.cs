using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisioni : MonoBehaviour
{
    public GameManager gameManager;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    //Se voglio che l'oggetto venga colpito ma il personaggio ci può passare sopra abilito IsTrigger sull'oggetto
    //e faccio questo
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //se il tag dell'oggetto con cui sono entrato in collisione aggiungo una mosca
        //ad una variabile mosca che si incrementa
        if (collision.gameObject.tag == "mosca")
        {
            gameManager.moscheCatturate++;
            Debug.Log("Ho colpito una mosca");
            gameManager.ScriviValoreMosche();  // mostro il valore aggiornato
            audioManager.EseguiAudio(collision.gameObject.GetComponent<AudioSource>());
            Destroy(collision.gameObject);   // elimino l'oggetto una volta colpito 
            gameManager.ScriviValoreMosche();  // mostro il valore aggiornato
        }

        if (collision.gameObject.tag == "moneta")
        {
            gameManager.monetePrese++;
            
            
            Debug.Log("Ho colpito una moneta");

            //gameManager.mainMenu.IncrementaMonete(1);
            
            
            gameManager.ScriviValoreMonete();
            audioManager.EseguiAudio(collision.gameObject.GetComponent<AudioSource>());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "cibo")
        {
            gameManager.energia += 10;
            if (gameManager.energia > 100)
            {
                gameManager.energia = 100;
            }
            Debug.Log("Ho colpito un cibo");
            
            gameManager.CambiaBarraEnergia();
            audioManager.EseguiAudio(collision.gameObject.GetComponent<AudioSource>());
            Destroy(collision.gameObject);
        }
        //collisione con un'iguana
        if (collision.gameObject.tag == "iguana")
        {
            //gameManager.monetePrese++;
            
     
            Debug.Log("Ho colpito un iguana");

            //gameManager.ScriviValoreMonete();
            //audioManager.EseguiAudio(collision.gameObject.GetComponent<AudioSource>());
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "puntina")
        {
            gameManager.energia -= 30;
            if (gameManager.energia < 0)
            {
                gameManager.energia = 0;
                // GAME OVER
            }
            Debug.Log("Ho colpito una puntina");
            gameManager.CambiaBarraEnergia();
            audioManager.EseguiAudio(collision.gameObject.GetComponent<AudioSource>());
        }
    }

}
