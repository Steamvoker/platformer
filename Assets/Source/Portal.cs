using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Vector2 teleportExitPosition;
    private bool triggerEntered = false;

    private void Update()
    {
        if (triggerEntered && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<PlayerController>().transform.position = teleportExitPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            triggerEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            triggerEntered = false;
        }
    }
}
