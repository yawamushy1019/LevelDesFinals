using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GateSealDestroy : MonoBehaviour
{
    public GameManager gameManager; //this is referenced to the game manager class

    [Header("UI Elements")]
    public Text TxtInteractMsg;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.questID == 2 || gameManager.questID == 3)
        {
            TxtInteractMsg.text = "Red, a fire in the hearth";
        }


    }

    public void OnTriggerStay(Collider other)
    {
        TxtInteractMsg.text = "Red, a fire in the hearth";
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
