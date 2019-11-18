using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private GameObject door;
    private bool triggerEntered = false;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (playerController.haveKey == true && Input.GetKeyDown(KeyCode.E))
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