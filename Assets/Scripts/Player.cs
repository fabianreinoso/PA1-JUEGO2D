using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb2d;

    private float move; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
