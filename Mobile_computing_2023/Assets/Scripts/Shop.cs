using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Riferimento al componente "Text" separato.

    public void OnButtonClick()
    {
        messageText.gameObject.SetActive(true); // Mostra il testo.

        // Invoca un metodo per nascondere il testo dopo 10 secondi.
        Invoke("HideMessage", 10f);
    }

    private void HideMessage()
    {
        messageText.gameObject.SetActive(false); // Nascondi il testo.
    }
}
