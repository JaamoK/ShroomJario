using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinClip;
    AudioSource coinAS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeSound()
    {
        coinAS.PlayOneShot(coinClip);
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject, 2);
    }
}
