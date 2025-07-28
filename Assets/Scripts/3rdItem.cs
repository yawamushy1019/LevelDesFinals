using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Q3ItemPickUp : MonoBehaviour
{

    public GameManager gameManager; //this is referenced to the game manager class

    [Header("UI Elements")]
    public Text TxtInteractMsg;

    [Header("Others")]
    public AudioSource audioSource1;
    public AudioSource audioSource2;// Reference to AudioSource component
    public AudioSource BGMusicStop;
    public AudioClip ResetSound1;
    public AudioClip ResetSound2;
    public FadeInAndOut fade;

    private Animator _ItemFloat3;

    private bool triggered = false;

    void Start()
    {
        fade = FindObjectOfType<FadeInAndOut>();
        _ItemFloat3 = GetComponent<Animator>();
        _ItemFloat3.SetBool("Activate", true);
    }

    public IEnumerator RestartScene()
    {
        yield return StartCoroutine(fade.FadeInCanvas());       // Fade to black
        yield return new WaitForSeconds(5.5f);
        // Small pause (optional)
        TxtInteractMsg.text = "Cursed"; // Optional: Clear message
        SceneManager.LoadScene("Blocking_Midterms");
        // No fade out here — new scene will have its own fade
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TxtInteractMsg.text = "Press [F] to pick up Item.";
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !triggered)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                triggered = true;
                TxtInteractMsg.text = "Cursed"; // Optional: Clear message
                BGMusicStop.Stop();
                StartCoroutine(RestartScene());
                audioSource1.Play();
                audioSource2.Play();
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