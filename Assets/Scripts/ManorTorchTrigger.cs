using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;



public class RowTrigger : MonoBehaviour
{
    public GameManager gameManager; //this is referenced to the game manager class

    [Header("UI Elements")]
    public Text TxtInteractMsg;

    [Header("Others")]
    public GameObject TorchRow;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.questID == 4)
        {
            TxtInteractMsg.text = "";
        }

    }

    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && gameManager.questID == 4)
        {
            TxtInteractMsg.text = "";
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TxtInteractMsg.text = "";
            TorchRow.gameObject.SetActive(true);
        }
    }
}