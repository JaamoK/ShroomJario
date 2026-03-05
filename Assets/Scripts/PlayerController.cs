using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D PlayerRigbod2D;
    public float force = 0f;
    public float jumpForce = 0f;
    Vector2 movement;
    bool grounded;
    bool hittable = false;

    int coinAmount = 0;

    public AudioClip hyppySound;
    public AudioClip hitSound;
    public AudioClip deathSound;

    public AudioSource playerAS;

    EnemyScript currentEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRigbod2D = GetComponent<Rigidbody2D>();
        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontal, 0).normalized;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("JUMP");
            playerAS.PlayOneShot(hyppySound);
            PlayerRigbod2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }

        if (Input.GetButtonDown("Fire1") && hittable)
        {
            Debug.Log("HIT");
            playerAS.PlayOneShot(hitSound);
            currentEnemy.TakeDamage(1);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * force * Time.deltaTime);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Debug.Log("NotGrounded");
            grounded = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hitting Someone");
        if (collision.GetComponent<EnemyScript>() != null)
        {
            hittable = true;
            currentEnemy = collision.GetComponent<EnemyScript>();
        }

        if (collision.transform.tag == "Coin")
        {
            GetCoin(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyScript>() != null)
        {
            hittable = false;
            currentEnemy = null;
        }
    }

    void GetCoin(GameObject _coin)
    {
        coinAmount++;
        _coin.GetComponent<Coin>().makeSound();
        Destroy(_coin.GetComponent<SpriteRenderer>());
        Destroy(_coin.GetComponent<BoxCollider2D>());
        Destroy(_coin.gameObject, 2);
        Debug.Log("Coins: " + coinAmount);
        Console.WriteLine(" jotain ");
    }

}
