using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoCamera : MonoBehaviour
{
    //tutti gli oggetti nella Hierarchy sono GameObject
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*Mettendp queste righe di codice qui sotto nella funzione LateUpdate mi 
     permette di dare maggiore fluidità alla canera quando si muove con il personaggio*/
    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x,
            player.transform.position.y + 1.2f, -10);
    }
}
