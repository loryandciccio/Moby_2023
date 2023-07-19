using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Text Monete;
    public TMP_Text CostoInMonete;
    
    void Start()
    {
        Monete.text = PlayerPrefs.GetInt("MoneteAccumulate").ToString();
        PlayerPrefs.SetInt("MoneteTotali", PlayerPrefs.GetInt("MoneteAccumulate"));
    }

    void Update()
    {
        //Qua volevo aggiornare i soldi scalati dall acquisto durante il gioco
    }
    public void acquistaBoost()
    {
        int moneteDisponibili = int.Parse(Monete.text);
        int costo = int.Parse(CostoInMonete.text);
        if(moneteDisponibili >= costo)
        {
            moneteDisponibili -= costo;
            PlayerPrefs.SetInt("MoneteAccumulate", moneteDisponibili);
        }
    }
    public void playGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }

}
