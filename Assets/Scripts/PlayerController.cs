using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField]
    float speed = 3f;

    [Header("Sprites")]
    [SerializeField]
    Sprite MovingTopImage;

    [SerializeField]
    Sprite MovingBotImage;

    [SerializeField]
    Sprite MovingHorizontalImage;


    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector2 movement;
    PlayerAnimatorController playerAnimatorController;
    int lastMovement = 0;

    void Start()
    {
        playerAnimatorController = GetComponent<PlayerAnimatorController>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 0 && movement.y == 0) { 

            int move  = 5;
            if(lastMovement == 1)
                move = 5;
            else if (lastMovement == 2)
                move = 6;
            else if (lastMovement == 3)
                move = 7;
            else if (lastMovement == 4)
                move = 8;

            playerAnimatorController.SetWalkAnimation(move);
        }
        else if (movement.x != 0)
        {
            if (movement.x == 1)
            {
                lastMovement = 4;
                playerAnimatorController.SetWalkAnimation(4);
            }
            else if (movement.x == -1)
            {
                lastMovement = 3;
                playerAnimatorController.SetWalkAnimation(3);
            }
        }
        else if (movement.y != 0)
        {
            if (movement.y == 1)
            {
                lastMovement = 1;
                playerAnimatorController.SetWalkAnimation(1);
            }
            else if (movement.y == -1)
            {
                lastMovement = 2;
                playerAnimatorController.SetWalkAnimation(2);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1f);

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        UpdateImage();
    }

    void UpdateImage()
    {
        if (movement.x > 0 || movement.x < 0)
            sr.sprite = MovingHorizontalImage;
        else if (movement.y > 0)
            sr.sprite = MovingTopImage;
        else if (movement.y < 0)
            sr.sprite = MovingBotImage;
    }
}
