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



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
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

        FlipImage();
        UpdateImage();
    }
    void FlipImage()
    {
        if (movement.x > 0) 
            sr.flipX = false;
        else if (movement.x < 0)
            sr.flipX = true;
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
