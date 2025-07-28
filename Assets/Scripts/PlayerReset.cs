using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerReset : MonoBehaviour
{
    public Transform respawnPoint; // assign in Inspector
    private CharacterController controller;
    private Character characterScript;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        characterScript = GetComponent<Character>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spikes"))
        {
            ResetPosition();
        }
        else if (other.CompareTag("Checkpoint"))
        {
            SetCheckpoint(other.transform);
        }
    }

    void ResetPosition()
    {
        controller.enabled = false;
        transform.position = respawnPoint.position;
        controller.enabled = true;

        if (characterScript != null)
        {
            characterScript.ResetMovement();
        }
    }

    void SetCheckpoint(Transform newCheckpoint)
    {
        respawnPoint = newCheckpoint;
    }
}

