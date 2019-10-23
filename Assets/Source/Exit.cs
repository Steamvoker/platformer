using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] TMP_Text winText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        winText.gameObject.SetActive(true);
        Invoke("Win", 3);
    }

    void Win()
    {
        SceneManager.LoadScene(0);
    }
}