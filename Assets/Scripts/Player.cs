using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb2d;

    private float move; 

    public float jumpforce = 4;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb2d.linearVelocity = new Vector2(move*speed, rb2d.linearVelocity.y);

        if(move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move),1,1);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpforce);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }
}
