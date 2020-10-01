using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] Animator anim;
    [SerializeField] UIController uiController;
    [SerializeField] GameObject bubbleShield;
    [SerializeField] SFXManager sFXManager;
    bool isGrounded;
    bool jump;
    float lastYPos;
    public int coinsCollected = 0;
    public float distanceTraveled;
    bool doubleJump = false;
    bool hasShield = false;

    //
    //  Unity's methods
    //
    void Start()
    {
        lastYPos = transform.position.y;
    }

    // Input checking should be in Update
    void Update()
    {
        IncreaseDistance();
        CheckForInput();
        CheckIfPlayerIsFalling();
    }

    // Unity's Physics methods should go in FixedUpdate
    void FixedUpdate()
    {
        CheckForGrounded();
        CheckForJump();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            if (hasShield)
            {
                hasShield = false;
                sFXManager.PlaySFX("ShieldBreak");
                bubbleShield.SetActive(false);
                Destroy(collision.gameObject);
            }
            else
            {
                sFXManager.PlaySFX("GameOverHit");
                uiController.ShowGameOverScreen();
            }
        }

        if (collision.transform.CompareTag("DeathBox"))
        {
            uiController.ShowGameOverScreen();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Collectible"))
        {
            coinsCollected++;
            sFXManager.PlaySFX("Coin");
            Destroy(collider.gameObject);
        }

        if (collider.CompareTag("DoubleJump"))
        {
            doubleJump = true;
            sFXManager.PlaySFX("DoubleJumpPowerUp");
            Destroy(collider.gameObject);
        }

        if (collider.CompareTag("Shield"))
        {
            hasShield = true;
            sFXManager.PlaySFX("ShieldPowerUp");
            bubbleShield.SetActive(true);
            Destroy(collider.gameObject);
        }
    }

    //
    // Own methods
    //
    void IncreaseDistance()
    {
        distanceTraveled += Time.deltaTime;
    }

    void CheckForJump()
    {
        if (jump)
        {
            jump = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void CheckIfPlayerIsFalling()
    {
        // Is the player falling?
        if (transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
        }

        lastYPos = transform.position.y;
    }

    void CheckForInput()
    {
        if (isGrounded || doubleJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (doubleJump && !isGrounded)
                {
                    doubleJump = false;
                    sFXManager.PlaySFX("DoubleJump");
                } else {
                    sFXManager.PlaySFX("Jump");
                }

                jump = true;
                anim.SetTrigger("Jump");
            }
        }
    }

    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        if (hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                isGrounded = true;
                anim.SetBool("IsGrounded", true);
            }
            else
            {
                isGrounded = false;
                anim.SetBool("IsGrounded", false);
            }
        }
        
    }
}
