using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabControls : MonoBehaviour
{
    [SerializeField] GameObject signUpTab, logInTab, startPanel, HUD;
    public TextMesh username, emailSign, passwordSign, emailLog, passwordLog, errorSign, errorLog;
    string encryptedPassword;


    public void SignUpTab()
    {
        signUpTab.SetActive(true);
        logInTab.SetActive(false);
    }
    public void LogInTab()
    {
        signUpTab.SetActive(false);
        logInTab.SetActive(true);
    }
}