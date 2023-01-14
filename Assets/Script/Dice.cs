using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    float paddleHit = 3.5f;
    float velocityMulti = 0.2f;
    float minVelocity = 3.5f;
    float random;
    Vector2 lastRecordedVelocity;

    Rigidbody2D rb;

    public AudioSource DiceHit1, DiceHit2, DiceHit3, DiceHit4, DiceHit5;

   
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        lastRecordedVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "paddle")
        {
            Vector2 transformVector = transform.position - col.transform.position;
            Vector2 paddleVelocity = velocityMulti * col.relativeVelocity;
            float movingVelocity = col.gameObject.GetComponent<Move>().dashSpeed;
            minVelocity += movingVelocity;
            paddleHit = minVelocity;
            paddleHit = Mathf.Clamp(paddleHit, 0.1f, 3.0f);
            rb.velocity = (transformVector + paddleVelocity) * paddleHit;
            Vector2 reflect = Vector2.Reflect(lastRecordedVelocity, col.contacts[0].normal);

           
            rb.velocity = reflect;

            random = Random.Range(0, 100);
            if (random >= 0 && random <= 20)
            {
                DiceHit1.Play();
            }
            else if (random >= 21 && random <= 40)
            {
                DiceHit2.Play();
            }
            else if (random >= 41 && random <= 60)
            {
                DiceHit3.Play();
            }
            else if (random >= 61 && random <= 80)
            {
                DiceHit4.Play();
            }
            else if (random >= 81 && random <= 100)
            {
                DiceHit5.Play();
            }
        }
        if (col.gameObject.tag == "AIpaddle")
        {
            Vector2 transformVector = transform.position - col.transform.position;
            Vector2 paddleVelocity = velocityMulti * col.relativeVelocity;
            float movingVelocity = col.gameObject.GetComponent<AI>().speed;
            minVelocity += movingVelocity;
            paddleHit = minVelocity;
            paddleHit = Mathf.Clamp(paddleHit, 2f, 3.0f);
            rb.velocity = (transformVector + paddleVelocity) * paddleHit;
            Vector2 reflect = Vector2.Reflect(lastRecordedVelocity, col.contacts[0].normal);

            
            rb.velocity = reflect;

            random = Random.Range(0, 100);
            if (random >= 0 && random <= 20)
            {
                DiceHit1.Play();
            }
            else if (random >= 21 && random <= 40)
            {
                DiceHit2.Play();
            }
            else if (random >= 41 && random <= 60)
            {
                DiceHit3.Play();
            }
            else if (random >= 61 && random <= 80)
            {
                DiceHit4.Play();
            }
            else if (random >= 81 && random <= 100)
            {
                DiceHit5.Play();
            }
        }

        if (col.gameObject.tag == "Vwall")
        {

            Vector2 reflect = Vector2.Reflect(lastRecordedVelocity, col.contacts[0].normal);

           
            rb.velocity = reflect;

            random = Random.Range(0, 100);
            if (random >= 0 && random <= 20)
            {
                DiceHit1.Play();
            }
            else if (random >= 21 && random <= 40)
            {
                DiceHit2.Play();
            }
            else if (random >= 41 && random <= 60)
            {
                DiceHit3.Play();
            }
            else if (random >= 61 && random <= 80)
            {
                DiceHit4.Play();
            }
            else if (random >= 81 && random <= 100)
            {
                DiceHit5.Play();
            }
        }
       // Debug.Log(col.gameObject.tag);

        
    }
}
