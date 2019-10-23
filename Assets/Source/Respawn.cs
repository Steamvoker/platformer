using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Respawn : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;
    public TMP_Text gameOverText;
    private bool triggerEntered = false;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (triggerEntered)
        {
            player.transform.position = respawnPoint.transform.position;
            playerController.playerHP--;
            triggerEntered = false;
            if (playerController.playerHP <= 0)
            {
                //Time.timeScale = 0;
                gameOverText.gameObject.SetActive(true);
                Invoke("GameOver", 3);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEntered = true;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }
}