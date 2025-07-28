using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class TextRead : MonoBehaviour
{
    public GameManager gameManager; //this is referenced to the game manager class

    [Header("UI Elements")]
    public Text TxtInteractMsg;

    [Header("Others")]
    public AudioSource audioSource;
    public AudioClip ReadTablet;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.questID == 0 || gameManager.questID == 1 || gameManager.questID == 2 || gameManager.questID == 3)
        {
            TxtInteractMsg.text = "Press [F] to Read";
        }
       

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && gameManager.questID == 0)
            {
                audioSource.Play();
                TxtInteractMsg.text = "Courage and Wisdom intertwine.";
            }
            else if (Input.GetKeyDown(KeyCode.F) && gameManager.questID == 1)
            {
                audioSource.Play();
                TxtInteractMsg.text = "One cannot be without the other.";
            }
            else if (Input.GetKeyDown(KeyCode.F) && gameManager.questID == 2)
            {
                audioSource.Play();
                TxtInteractMsg.text = "Both must be found to proceed.";
            }
            else if (Input.GetKeyDown(KeyCode.F) && gameManager.questID == 3)
            {
                audioSource.Play();
                TxtInteractMsg.text = "Red, a fire ablaze. \nBlue, the ocean's grace.";
            }

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TxtInteractMsg.text = "";
        }
    }
}