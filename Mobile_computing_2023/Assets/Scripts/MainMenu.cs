using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Text Monete;
    public TMP_Text CostoInMonete;
    //public int moneteTotali; // Aggiungiamo una variabile per memorizzare il totale delle monete.

    void Start()
    {
        // Recuperiamo il valore corrente delle monete totali (se presente) dal PlayerPref.
        // moneteTotali = PlayerPrefs.GetInt("MonetePrese");
        // UpdateMoneteText();
        Monete.text = PlayerPrefs.GetInt("MoneteAccumulate").ToString();
    }

    /*
    void Update()
    {
        //UpdateMoneteText();
        // Qui puoi aggiornare visivamente le monete durante il gioco, se necessario.
        Monete.text = PlayerPrefs.GetInt("MoneteAccumulate").ToString();
    }*/

    public void AcquistaBoost()
    {
        int moneteDisponibili = int.Parse(Monete.text);
        int costo = int.Parse(CostoInMonete.text);
        if (moneteDisponibili >= costo)
        {
            moneteDisponibili -= costo;
           // moneteTotali -= costo; // Decrementiamo anche il totale delle monete.
            PlayerPrefs.SetInt("MoneteAccumulate", moneteDisponibili);
             //UpdateMoneteText();
        }
    }


    /*private void UpdateMoneteText()
    {
        Monete.text = moneteTotali.ToString();
        PlayerPrefs.SetInt("MonetePrese", moneteTotali); // Salviamo il nuovo totale delle monete nel PlayerPref.
    }*/

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
