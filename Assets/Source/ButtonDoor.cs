using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private bool triggerEntered = false;

    private void Update()
    {
        if (triggerEntered && Input.GetKeyDown(KeyCode.E))
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEntered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerEntered = false;
    }
}
