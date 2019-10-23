using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Damage : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private GameObject player;
    private Respawn respawn;
    public TMP_Text gameOverText;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        respawn = FindObjectOfType<Respawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController.playerHP--;
        if (playerController.playerHP <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            respawn.Invoke("GameOver", 3);
        }
    }
}