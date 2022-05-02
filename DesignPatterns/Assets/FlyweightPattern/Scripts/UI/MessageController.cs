using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    private Text message;
    // Start is called before the first frame update
    void Start()
    {
        message = this.GetComponent<Text>();
        message.enabled = false;
    }

    public void SetMessage()
    {
        message.text = "You picked up an item !";
        message.enabled = true;
        Invoke("TurnOffMessage",2);
    }

    public void TurnOffMessage()
    {
        message.enabled = false;
    }
}
