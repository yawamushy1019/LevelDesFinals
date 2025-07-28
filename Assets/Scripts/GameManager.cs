using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Quest Related")]
    public int questID = 0; //this identifies what quest is currently active

    [Header("UI Related")]
    public Text TextMonologue;
    public Text TextQuest;

    [Header("Others")]
    public GameObject Tablet;
    public GameObject RSide;

    private Animator _Tablet;
    private Animator _RSideAnim;

    void Start()
    {
        _Tablet = Tablet.GetComponent<Animator>();
        _Tablet.SetBool("Activate", true);
        _RSideAnim = RSide.GetComponent<Animator>();
        _RSideAnim.SetBool("Start", true);
    }

    void Update()
    {
        
    }
}
