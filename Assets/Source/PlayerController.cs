using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;

    private Rigidbody2D playerBody;
    public BoxCollider2D boxCollider2D;

    public float speed = 0.0f;
    public int playerHP;
    public float jumpPower = 0.0f;
    public int extraJumpValue;
    private int extraJumps;

    public Text hp;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerBody.transform.position = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Walk(dir);
        //Jump();
        hp.text = playerHP.ToString();
        //Debug.Log(IsGrounded());
    }

    private void FixedUpdate()
    {
        Jump();
    }

    void Walk(Vector2 dir)
    {
        playerBody.velocity = new Vector2(dir.x * speed, playerBody.velocity.y);
    }

    void Jump()
    {
        if (IsGrounded())
        {
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps >= 0)
        {
            playerBody.velocity = Vector2.up * jumpPower;
            extraJumps--;
            Debug.Log("Double jump");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && IsGrounded())
        {
            playerBody.velocity = Vector2.up * jumpPower;
            Debug.Log("jump");
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0.0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }
}