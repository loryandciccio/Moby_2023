using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iguana : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Newbie") && PlayerPrefs.GetInt("numeroMosche") == 10 && SceneManager.GetActiveScene().name != "level3")
        {
            UnlockNewLevel();
            SceneManager.LoadScene("level" + (SceneManager.GetActiveScene().buildIndex ));
            PlayerPrefs.SetInt("numeroMosche",0);
        }
        if (collision.CompareTag("Newbie") && PlayerPrefs.GetInt("numeroMosche") == 10 && SceneManager.GetActiveScene().name == "level3")
        {
            
            SceneManager.LoadScene("win");
            PlayerPrefs.SetInt("numeroMosche", 0);
        }

    }
    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
  
}
