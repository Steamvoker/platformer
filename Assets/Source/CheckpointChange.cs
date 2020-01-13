using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointChange : MonoBehaviour
{
    [SerializeField] private GameObject checkpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            checkpoint.transform.position = this.transform.position;
        }
    }
}