using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private PlayerController playerController;
    private Damage damage;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        damage = FindObjectOfType<Damage>();
    }

    private void HeartAnimation()
    {

    }
}
