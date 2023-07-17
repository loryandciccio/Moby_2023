using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestioneScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CaricaScena(string nome)
    {
        SceneManager.LoadScene(nome);
    }

    public void CaricaLivello()
    {
        int indiceAttuale =  SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(indiceAttuale - 1);
        
    }
}
