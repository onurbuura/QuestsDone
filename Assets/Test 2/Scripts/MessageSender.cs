using UnityEngine;
using UnityEngine.UI;

public class MessageSender : MonoBehaviour
{
    /// <summary>
    /// Check TODO Instructions inside of the Test2 folder
    /// </summary>
    public InputField userInput;
    public Button sendButton;

    public delegate void OnMessageSent(string text);
    public event OnMessageSent messageSent = delegate { };

    private void Start()
    {

    }

    public void SendMessage()
    {
        string message = userInput.textComponent.text;
        messageSent(message);
    }


}
