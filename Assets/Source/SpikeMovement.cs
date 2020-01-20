using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    private Transform spikeTransform;
    public float speed = 5;
    private float posX;
    public float moveLength = 3;

    // Start is called before the first frame update
    void Start()
    {
        spikeTransform = GetComponent<Transform>();
        //spikeTransform.position = new Vector2(35, 0.1f);
        posX = spikeTransform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        spikeTransform.transform.position = new Vector2(posX + Mathf.PingPong(Time.time * speed, moveLength), transform.position.y);
    }
}
