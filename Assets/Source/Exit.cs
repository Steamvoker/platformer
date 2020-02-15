using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] TMP_Text winText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        winText.text = "Level Complete \n\n Points Collected: " + playerController.points.ToString();
        winText.gameObject.SetActive(true);
        Invoke("Win", 3);
    }

    void Win()
    {
        SceneManager.LoadScene(0);
    }
}