using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class cliccami : MonoBehaviour
{
    public TextMeshProUGUI elementoDiTesto;
    public string nuovoTesto;
    //Variabile per memorizzare il testo originale del bottone
    private string testoOriginale;

    //La funzione Start() viene chiamata una volta all'avvio del gioco 
    void Start()
    {
        testoOriginale=elementoDiTesto.text;
    }
    public void CambiaTesto()
    {
        //Verifica se il testo attuale è diverso dal nuovo testo impostato
        if (elementoDiTesto.text !=nuovoTesto)
        {
            //Se il testo è diverso, imposta il nuovo testo
            elementoDiTesto.text = nuovoTesto;
        }
        else
        {
            //Se il testo è uguale al nuovo testo, ripristina il testo originale
            elementoDiTesto.text = testoOriginale;
        }
        
    }
}
