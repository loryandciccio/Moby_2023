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

    // Start is called before the first frame update
    void Start()
    {
        ScriviValoreMonete();
        ScriviValoreMosche();
    }

    public void ScriviValoreMosche()
    {
        testoMosche.text = moscheCatturate.ToString();
    }
    public void ScriviValoreMonete()
    {
        testoMonete.text = monetePrese.ToString();
    }
}
