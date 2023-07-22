using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupButton : MonoBehaviour
{
    public int powerupDuration = 10; // Durata del potenziamento in secondi

    public void OnPowerupButtonClick()
    {
        // Imposta la variabile che indica che il salto potenziato è stato sbloccato
        PlayerPrefs.SetInt("PowerupUnlocked", 1);

        // Imposta il tempo in cui il potenziamento sarà attivo
        PlayerPrefs.SetFloat("PowerupEndTime", Time.time + powerupDuration);

        // Salva i dati
        PlayerPrefs.Save();
    }
}
