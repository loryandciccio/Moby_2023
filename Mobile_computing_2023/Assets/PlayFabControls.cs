using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System.Collections;

public class PlayFabControls : MonoBehaviour
{
    [SerializeField] GameObject signUpTab, logInTab, startPanel, HUD;
    public TextMeshProUGUI username, userEmail, userPassword,userEmailLogIn, userPasswordLogIn, errorSignUp, errorLogIn,errorSendRecovery;
    string encryptedPassword;
    private string playfabTitleId = "title.32B77";


    public void SignUpTab()
    {
        signUpTab.SetActive(true);
        logInTab.SetActive(false);
        errorSignUp.text = " ";
        errorLogIn.text = " ";
    }
    public void LogInTab()
    {
        signUpTab.SetActive(false);
        logInTab.SetActive(true);
        errorSignUp.text = " ";
        errorLogIn.text = " ";
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
    /*
    public void SignUp()
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = emailSign.text, Password = passwordSign.text, Username = username.text };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, registerSuccess, registerError);
    }*/
    public void SignUp()
    {
        Debug.Log(userEmail.text + username.text);
        var usernameNoWhiteSpace = username.text.Remove(username.text.Length - 1);
        var registerRequest = new RegisterPlayFabUserRequest { Email = userEmail.text, Password = Encrypt(userPassword.text), Username = usernameNoWhiteSpace };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, registerSuccess, registerError);

    }

    private void registerSuccess(RegisterPlayFabUserResult result)
    {
        errorSignUp.text = " ";
        errorLogIn.text = " ";
        StartGame();

    }



    private void registerError(PlayFabError error)
    {
        errorSignUp.text = error.GenerateErrorReport();
    }

    public void  Login()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogIn.text, Password = Encrypt(userPasswordLogIn.text)};
        PlayFabClientAPI.LoginWithEmailAddress(request,LogInSuccess, LogInSuccess);

    }

    public void LogInSuccess(LoginResult result)
    {
        errorSignUp.text = " ";
        errorLogIn.text = " ";
        StartGame();
    }
    private void LogInSuccess(PlayFabError error)
    {
        StartCoroutine(ShowErrorAndHide(error));
    }

    private IEnumerator ShowErrorAndHide(PlayFabError error)
    {
        float duration = 3f;

        // Attiva il Canvas
        errorLogIn.gameObject.SetActive(true);

        // Attendere per la durata specificata
        yield return new WaitForSeconds(duration);

        // Disattiva il Canvas dopo il ritardo
        errorLogIn.gameObject.SetActive(false);
    }

    void StartGame()
    {
        startPanel.SetActive(false);
        HUD.SetActive(true);
    }



    public void RecoverPassword()
    {
        if (string.IsNullOrEmpty(userEmail.text))
        {
            Debug.LogError("Inserisci prima l'email per il recupero della password!");
            return;
        }

        SendAccountRecoveryEmailRequest request = new SendAccountRecoveryEmailRequest { Email = userEmailLogIn.text, TitleId =playfabTitleId };
   

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordRecoverySuccess, OnPasswordRecoveryFailure);
    }

    private void OnPasswordRecoverySuccess(SendAccountRecoveryEmailResult result)
    {
        Debug.Log("Email di recupero inviata con successo all'indirizzo: " + userEmail);
    }

    private IEnumerator ShowErrorAndHideRecovery(PlayFabError error)
    {
        Debug.LogError("Recupero password fallito: " + error.ErrorMessage);
        float duration = 3f;

        // Attiva il Canvas
        errorSendRecovery.gameObject.SetActive(true);

        // Attendere per la durata specificata
        yield return new WaitForSeconds(duration);

        // Disattiva il Canvas dopo il ritardo
        errorSendRecovery.gameObject.SetActive(false);
    }
    private void OnPasswordRecoveryFailure(PlayFabError error)
    {
        StartCoroutine(ShowErrorAndHideRecovery(error));
    }
}


