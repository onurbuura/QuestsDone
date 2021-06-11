using UnityEngine;
using UnityEngine.UI;

public class MessageReciever : MonoBehaviour
{
    /// <summary>
    /// Check TODO Instructions inside of the Test2 folder
    /// </summary>
    public Text recievedText;
    string SentMessage;

    private void Start()
    {
        MessageSender messageSender = FindObjectOfType<MessageSender>();
        messageSender.messageSent += PrintMessage;
    }

    private void PrintMessage(string message)
    {
        recievedText.text = message;
    }

    public void ClearText()
    {
        recievedText.text = "";
    }
}
