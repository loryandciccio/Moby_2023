using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MainMenu mainMenu;

     public int moscheCatturate = 0;
     public int monetePrese = 0;
     public int energia = 100;

    public TMP_Text testoMosche;
    public TMP_Text testoMonete;
    public RectTransform barra;

    GestioneScene gestioneScene;
    public int valoreMonetePrese;

    // Start is called before the first frame update
    void Start()
    {
        
        gestioneScene = FindObjectOfType<GestioneScene>();
        ScriviValoreMonete();
        ScriviValoreMosche();
    }

    public void ScriviValoreMosche()
    {
        //il ToString mi permette di convertire i numeri che ho nel Tmtext in string
        testoMosche.text = moscheCatturate.ToString();
        if(moscheCatturate == 10)
        {
            PlayerPrefs.SetInt("numeroMosche", 10);
            
        }
    }
    public void ScriviValoreMonete()
    {
        testoMonete.text = monetePrese.ToString();
        valoreMonetePrese = int.Parse(monetePrese.ToString());
        PlayerPrefs.SetInt("MonetePrese", valoreMonetePrese);
        //PlayerPrefs.SetInt("MoneteAccumulate", PlayerPrefs.GetInt("MoneteAccumulate") + 1);

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
