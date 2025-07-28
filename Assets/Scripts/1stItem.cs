using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Q1ItemPickUp : MonoBehaviour
{
    public GameManager gameManager; //this is referenced to the game manager class

    [Header("UI Elements")]
    public Text TxtInteractMsg;

    [Header("Others")]
    public GameObject LeftFireBlocker;
    public GameObject RightFireBlocker;
    public GameObject RemoveLSpikes;
    public GameObject FireLObject;
    public GameObject FireNObject;
    public GameObject Item1Dialogue;

    public AudioSource audioSource;
    public AudioSource audioSource1;
    public AudioClip ItemSound1;
    public AudioClip LSpikesDown;

    private Animator _SpikesUnblock1;
    private Animator _ItemFloat1;

    public void Start()
    {
        _ItemFloat1 = GetComponent<Animator>();
        _ItemFloat1.SetBool("Activate", true);
        _SpikesUnblock1 = RemoveLSpikes.GetComponent<Animator>();
        _SpikesUnblock1.SetBool("Idle", true);
        _SpikesUnblock1.SetBool("Execute", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.questID == 1 || gameManager.questID == 2)
        {
            TxtInteractMsg.text = "Press [F] to pick up Item.";
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && gameManager.questID == 1)
            {
                gameManager.questID = 2;
                FireLObject.gameObject.SetActive(false);
                LeftFireBlocker.gameObject.SetActive(false);
                RightFireBlocker.gameObject.SetActive(true);
                Item1Dialogue.gameObject.SetActive(true);
                _SpikesUnblock1.SetBool("Idle", false);
                _SpikesUnblock1.SetBool("Execute", true);
                audioSource1.Play();
                this.gameObject.SetActive(false);

            }
            else if (Input.GetKeyDown(KeyCode.F) && gameManager.questID == 2)
            {
                gameManager.questID = 3;
                FireLObject.gameObject.SetActive(false);
                FireNObject.gameObject.SetActive(true);
                LeftFireBlocker.gameObject.SetActive(false);
                Item1Dialogue.gameObject.SetActive(true);
                _SpikesUnblock1.SetBool("Idle", false);
                _SpikesUnblock1.SetBool("Execute", true);
                audioSource1.Play();
                this.gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has exited the trigger area.");
            TxtInteractMsg.text = "";
        }
    }
}