using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;



public class BellSoundActivate : MonoBehaviour
{
    public GameManager gameManager; //this is referenced to the game manager class

    [Header("UI Elements")]
    public Text TxtInteractMsg;

    [Header("Others")]
    public AudioSource audioSource;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.questID == 4)
        {
            TxtInteractMsg.text = "";
            audioSource.Play();
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
            this.gameObject.SetActive(false);
        }
    }
}