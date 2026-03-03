using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D PlayerRigbod2D;
    public float force = 0f;
    public float jumpForce = 0f;
    Vector2 movement;

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

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("JUMP");
            PlayerRigbod2D.AddForce(transform.up * jumpForce,ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * force * Time.deltaTime,Space.World);
    }
}
