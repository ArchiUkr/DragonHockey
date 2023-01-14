using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject dice;
    public float speed;
    public bool hitDice;
    //Vector2 startPos;

    public Transform startPos;
    public Vector2 str;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
          
            if (CheckSc.Active == true )
            {
            if (dice.transform.position.x < 7 && dice.transform.position.x > 0.2)
            {
                if (dice.transform.position.y < transform.position.y && !hitDice)
                {
                    //move towords the dice.
                    transform.position = Vector2.MoveTowards(transform.position, dice.transform.position, speed * Time.deltaTime);
                
                }
                else
                {
                    //move towords the goal.
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 4f), speed * Time.deltaTime);
                }
            }

            }
            else
            {
                //Moves back to Start Position.
                transform.position = Vector2.MoveTowards(transform.position, str, speed * Time.deltaTime);
            }
            if (hitDice == true)
            {
            
                StartCoroutine(WaitTime(2f));
                
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Disk")
        {
            hitDice = true;
           
        }
    }

    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        hitDice = false;
        
    }
}
