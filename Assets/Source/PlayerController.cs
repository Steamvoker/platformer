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
    public int maxHP;
    public int playerHP;
    public float jumpPower = 0.0f;
    public int extraJumpValue;
    private int extraJumps;
    [HideInInspector] public bool haveKey = false;
    public Animator[] hearts;
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public int points = 0;
    private bool isFlipped = false;
    //[SerializeField] private float dashPower = 0.0f;
    //public Sprite fullHeart;

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
        Jump();
        GravityFlip();
        //Dash(dir);
        hp.text = playerHP.ToString();
        HealthController(playerHP, maxHP);
    }

    void Walk(Vector2 dir)
    {
        playerBody.velocity = new Vector2(dir.x * speed, playerBody.velocity.y);
        if (facingRight == false && dir.x > 0)
        {
            Flip();
        }
        else if (facingRight && dir.x < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    //void Dash(Vector2 _dir)
    //{
    //    if(Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        playerBody.AddForce(_dir, ForceMode2D.Impulse);
    //    }
    //}

    void Jump()
    {
        if (isFlipped == false)
        {
            if (IsGrounded())
            {
                extraJumps = extraJumpValue;
            }

            if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
            {
                playerBody.velocity = Vector2.up * jumpPower;
                extraJumps--;
                //Debug.Log("Double jump");
            }
            else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && IsGrounded())
            {
                playerBody.velocity = Vector2.up * jumpPower;
                //Debug.Log("jump");
            }
        }
        else if (isFlipped == true)
        {
            if (FlippedIsGrounded())
            {
                extraJumps = extraJumpValue;
            }

            if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
            {
                playerBody.velocity = Vector2.down * jumpPower;
                extraJumps--;
                //Debug.Log("Double jump");
            }
            else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && FlippedIsGrounded())
            {
                playerBody.velocity = Vector2.down * jumpPower;
                //Debug.Log("jump");
            }
        }
    }

    void GravityFlip()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && (IsGrounded() || FlippedIsGrounded()))
        {
            playerBody.gravityScale *= -1;
            Vector3 vertScaler = transform.localScale;
            vertScaler.y *= -1;
            transform.localScale = vertScaler;
            isFlipped = !isFlipped;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0.0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }

    private bool FlippedIsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0.0f, Vector2.up, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }

    void HealthController(int _curHP, int _maxHP)
    {
        int numOfHearts = hearts.Length;
        float heartStep = _maxHP / numOfHearts;
        int numOfVisibleHearts = Mathf.CeilToInt(_curHP / heartStep);

        for (int i = 0; i < numOfVisibleHearts; i++)
        {
            hearts[i].SetBool("IsVisible", true);
        }

        for (int i = numOfVisibleHearts; i < hearts.Length; i++)
        {
            hearts[i].SetBool("IsVisible", false);
        }
    }
}
