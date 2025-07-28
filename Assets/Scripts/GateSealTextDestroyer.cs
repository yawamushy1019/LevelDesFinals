using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GateTextDestroy : MonoBehaviour
{
    public GameManager gameManager; //this is referenced to the game manager class

    [Header("UI Elements")]
    public Text TxtInteractMsg;
    public GameObject GateDestroy;
    public GameObject GateOpen;

    public AudioSource audioSource;
    public AudioClip whisper;
    public AudioClip whisper1;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.questID == 4)
        {
            audioSource.Play();
            GateDestroy.gameObject.SetActive(false);
            GateOpen.gameObject.SetActive(true);
        }


    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TxtInteractMsg.text = "-Whispers-: Come... We await on your arrival...";
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