using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class OpenGate : MonoBehaviour
{
    public GameManager gameManager; //this is referenced to the game manager class

    [Header("UI Elements")]
    public Text TxtInteractMsg;

    [Header("Others")]
    public GameObject GateOpen;
    public GameObject LeftAreaBlocker;
    public GameObject RightAreaBlocker;
    public GameObject CircleRotation;
    public GameObject MagicFireFloat;
    public GameObject TextDestroyer;


    public AudioSource audioSource;
    public AudioClip UnblockSound;

    private Animator _BarrierOpen1;
    private Animator _BarrierOpen2;

    private Animator _CircleRotate;
    private Animator _MagicFireBob;

    private Animator _GateOpen;

    void Start()
    {
        _BarrierOpen1 = LeftAreaBlocker.GetComponent<Animator>();
        _BarrierOpen1.SetBool("Idle", true);
        _BarrierOpen1.SetBool("Execute", false);

        _BarrierOpen2 = RightAreaBlocker.GetComponent<Animator>();
        _BarrierOpen2.SetBool("Idle", true);
        _BarrierOpen2.SetBool("Execute", false);

        _CircleRotate = CircleRotation.GetComponent<Animator>();
        _CircleRotate.SetBool("Rotate", true);

        _MagicFireBob = MagicFireFloat.GetComponent<Animator>();
        _MagicFireBob.SetBool("Activate", true);

        _GateOpen = GateOpen.GetComponent<Animator>();
        _GateOpen.SetBool("Open", false);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.questID == 0)
        {
            TxtInteractMsg.text = "The Gate is sealed by some sort of magic.";
        }
        else if (other.gameObject.CompareTag("Player") && gameManager.questID == 3)
        {
            TxtInteractMsg.text = "Press [F] to release the seal.";
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && gameManager.questID == 3)
            {
                gameManager.questID = 4;
                audioSource.Play();
                _GateOpen.SetBool("Open", true);
                TextDestroyer.gameObject.SetActive(true);
                CircleRotation.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.questID == 0)
        {
            TxtInteractMsg.text = "";
            audioSource.Play();
            gameManager.questID = 1;
            _BarrierOpen1.SetBool("Idle", false);
            _BarrierOpen1.SetBool("Execute", true);
            _BarrierOpen2.SetBool("Idle", false);
            _BarrierOpen2.SetBool("Execute", true);
            this.gameObject.SetActive(true);

        }
    }

}
