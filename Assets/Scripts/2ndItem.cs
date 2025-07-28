using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Q2ItemPickUp : MonoBehaviour
{
    public GameManager gameManager; //this is referenced to the game manager class

    [Header("UI Elements")]
    public Text TxtInteractMsg;

    [Header("Others")]
    public GameObject LeftFireBlocker;
    public GameObject RightFireBlocker;
    public GameObject RemoveRSpikes;
    public GameObject FireRObject;
    public GameObject FireNObject;
    public GameObject Item2Dialogue;

    public AudioSource audioSource;
    public AudioSource audioSource1;
    public AudioClip ItemSound2;
    public AudioClip RSpikesDown;

    private Animator _SpikesUnblock2;
    private Animator _ItemFloat2;

    public void Start()
    {
        _ItemFloat2 = GetComponent<Animator>();
        _ItemFloat2.SetBool("Activate", true);
        _SpikesUnblock2 = RemoveRSpikes.GetComponent<Animator>();
        _SpikesUnblock2.SetBool("Idle", true);
        _SpikesUnblock2.SetBool("Execute", false);
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
                FireRObject.gameObject.SetActive(false);
                LeftFireBlocker.gameObject.SetActive(true);
                RightFireBlocker.gameObject.SetActive(false);
                Item2Dialogue.gameObject.SetActive(true);
                _SpikesUnblock2.SetBool("Idle", false);
                _SpikesUnblock2.SetBool("Execute", true);
                audioSource1.Play();
                this.gameObject.SetActive(false);

            }
            else if (Input.GetKeyDown(KeyCode.F) && gameManager.questID == 2)
            {
                gameManager.questID = 3;
                FireRObject.gameObject.SetActive(false);
                FireNObject.gameObject.SetActive(true);
                RightFireBlocker.gameObject.SetActive(false);
                Item2Dialogue.gameObject.SetActive(true);
                _SpikesUnblock2.SetBool("Idle", false);
                _SpikesUnblock2.SetBool("Execute", true);
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