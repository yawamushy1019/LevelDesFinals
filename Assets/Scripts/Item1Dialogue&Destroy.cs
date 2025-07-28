using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Item1TextDestroy : MonoBehaviour
{
    public GameManager gameManager; //this is referenced to the game manager class

    [Header("UI Elements")]
    public Text TxtInteractMsg;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.questID == 2 || gameManager.questID == 3)
        {
            TxtInteractMsg.text = "Blue, the ocean's endless grace";
        }


    }

    public void OnTriggerStay(Collider other)
    {
        TxtInteractMsg.text = "Blue, the ocean's endless grace";
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TxtInteractMsg.text = "";
            this.gameObject.SetActive(false);
        }
    }
}
