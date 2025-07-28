using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAndOut2 : MonoBehaviour
{
    FadeInAndOut fade;
    // Start is called before the first frame update
    void Start()
    {

        fade = FindObjectOfType<FadeInAndOut>();

        fade.FadeOut();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
