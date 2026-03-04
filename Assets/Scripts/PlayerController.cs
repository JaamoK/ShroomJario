using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D PlayerRigbod2D;
    public float force = 0f;
    public float jumpForce = 0f;
    Vector2 movement;
    bool grounded;

    public AudioResource hyppySound;
    public AudioResource hitSound;
    public AudioResource deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRigbod2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontal, 0).normalized;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("JUMP");
            PlayerRigbod2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * force * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Common Style
        if (collision.transform.tag == "Ground")
        {
            Debug.Log("IsGrounded");
            grounded = true;
        }

        //Hardcore Style
        //if (collision.transform.parent.name == "Platforms")
        //{
        //    grounded = true;
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Debug.Log("NotGrounded");
            grounded = false;
        }
    }

}
