using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Text Monete;
    public TMP_Text CostoInMonete;
    private int moneteTotali; // Aggiungiamo una variabile per memorizzare il totale delle monete.

    void Start()
    {
        // Recuperiamo il valore corrente delle monete totali (se presente) dal PlayerPref.
        moneteTotali = PlayerPrefs.GetInt("MoneteAccumulate", 0);
        UpdateMoneteText();
    }

    void Update()
    {
        // Qui puoi aggiornare visivamente le monete durante il gioco, se necessario.
    }

    public void AcquistaBoost()
    {
        int moneteDisponibili = int.Parse(Monete.text);
        int costo = int.Parse(CostoInMonete.text);
        if (moneteDisponibili >= costo)
        {
            moneteDisponibili -= costo;
            moneteTotali -= costo; // Decrementiamo anche il totale delle monete.
            PlayerPrefs.SetInt("MoneteAccumulate", moneteDisponibili);
            UpdateMoneteText();
        }
    }

    public void IncrementaMonete(int quantitaMonete)
    {
        moneteTotali += quantitaMonete; // Incrementiamo il totale delle monete quando il giocatore ne raccoglie durante il gioco.
        UpdateMoneteText();
    }

    private void UpdateMoneteText()
    {
        Monete.text = moneteTotali.ToString();
        PlayerPrefs.SetInt("MoneteTotali", moneteTotali); // Salviamo il nuovo totale delle monete nel PlayerPref.
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
