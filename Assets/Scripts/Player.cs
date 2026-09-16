using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    private Animator animator;

    private int coins;
    public TMP_Text textCoins;

    public AudioSource audioSource;

    public AudioClip coinClip;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetFloat("VerticalVelocity", rb2d.linearVelocity.y);
        animator.SetBool("IsGrounded", isGrounded);                                                     

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Coin")){

            audioSource.PlayOneShot(coinClip);
            Destroy(collision.gameObject);
            coins++;
            textCoins.text = coins.ToString();
        }

        if(collision.transform.CompareTag("Spikes"))
        {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }                                                       

    }
    
}
