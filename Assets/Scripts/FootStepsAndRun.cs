using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsAndRun : MonoBehaviour
{
    public AudioSource footsteps_SFX;
    public AudioSource running_SFX;

    void Update()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
                        Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isMoving)
        {
            if (isRunning)
            {
                if (!running_SFX.isPlaying)
                    running_SFX.Play();

                if (footsteps_SFX.isPlaying)
                    footsteps_SFX.Stop();
            }
            else
            {
                if (!footsteps_SFX.isPlaying)
                    footsteps_SFX.Play();

                if (running_SFX.isPlaying)
                    running_SFX.Stop();
            }
        }
        else
        {
            if (footsteps_SFX.isPlaying)
                footsteps_SFX.Stop();

            if (running_SFX.isPlaying)
                running_SFX.Stop();
        }
    }
}
