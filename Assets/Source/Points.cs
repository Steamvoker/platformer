using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.points++;
            text.text = "Points: " + playerController.points.ToString();
            Debug.Log(playerController.points);
            this.gameObject.SetActive(false);
        }
    }
}
