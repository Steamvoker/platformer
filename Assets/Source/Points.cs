using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerController playerController;
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(CompareTag("Player"))
        {
            text.text = "Points: " +  playerController.points.ToString();
            Debug.Log(playerController.points);
        }
    }
}
