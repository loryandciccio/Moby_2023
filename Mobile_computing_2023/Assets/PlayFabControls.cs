using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System;

public class PlayFabControls : MonoBehaviour
{
    [SerializeField] GameObject signUpTab, logInTab, startPanel, HUD;
    public TextMeshProUGUI username, emailSign, passwordSign, emailLog, passwordLog, errorSign, errorLog;
    string encryptedPassword;


    public void SignUpTab()
    {
        signUpTab.SetActive(true);
        logInTab.SetActive(false);
        errorSign.text = " ";
        errorLog.text = " ";
    }
    public void LogInTab()
    {
        signUpTab.SetActive(false);
        logInTab.SetActive(true);
        errorSign.text = " ";
        errorLog.text = " ";
    }
    
    string Encrypt(string pass)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();

        byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);

        bs = x.ComputeHash(bs);

        System.Text.StringBuilder s = new System.Text.StringBuilder();


        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }


        return s.ToString();
    }
    public void SignUp()
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = emailSign.text, Password = Encrypt(passwordSign.text), Username = username.text };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, registerSuccess, registerError);
    }

    private void registerSuccess(RegisterPlayFabUserResult result)
    {
        errorSign.text = " ";
        errorLog.text = " ";
        StartGame();

    }



    private void registerError(PlayFabError error)
    {
        errorSign.text = error.GenerateErrorReport();
    }

    public void  Login()
    {
        var request = new LoginWithEmailAddressRequest { Email = emailLog.text, Password = Encrypt(passwordLog.text)};
        PlayFabClientAPI.LoginWithEmailAddress(request,LogInSuccess, LogInSuccess);

    }

    public void LogInSuccess(LoginResult result)
    {
        errorSign.text = " ";
        errorLog.text = " ";
        StartGame();
    }
    private void LogInSuccess(PlayFabError error)
    {
        errorLog.text = error.GenerateErrorReport();
    }

    void StartGame()
    {
        startPanel.SetActive(false);
        HUD.SetActive(true);
    }
}