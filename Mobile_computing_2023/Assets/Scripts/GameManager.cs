using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

     public int moscheCatturate = 0;
     public int monetePrese = 0;
     public int energia = 100;

    public TMP_Text testoMosche;
    public TMP_Text testoMonete;

    public RectTransform barra;

    GestioneScene gestioneScene;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        gestioneScene = FindObjectOfType<GestioneScene>();
        ScriviValoreMonete();
        ScriviValoreMosche();
    }

    public void ScriviValoreMosche()
    {
        //il ToString mi permette di convertire i numeri che ho nel Tmtext in string
        testoMosche.text = moscheCatturate.ToString();
        if(moscheCatturate == 1)
        {
            gestioneScene.CaricaScena("win");
            PlayerPrefs.SetInt("unlockedLevel", PlayerPrefs.GetInt("unlockedLevel", 1)+1);
        }
    }
    public void ScriviValoreMonete()
    {
        testoMonete.text = monetePrese.ToString();
    }

    public void CambiaBarraEnergia()
    {
        barra.sizeDelta = new Vector2(energia * 3, 40);
        if (energia <= 0)
        {
            gestioneScene.CaricaScena("GameOver");
        }
    }
}
