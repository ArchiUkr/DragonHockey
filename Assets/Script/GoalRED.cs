using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalRED : MonoBehaviour
{
    GameObject dice;
    public TextMeshProUGUI PointText;

    public GameObject DR;
   public static int redPoints;
    public AudioSource Goal;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Disk")
        {
            DR.GetComponent<Animator>().Play("BLAS");
            Goal.Play();
            dice = collision.gameObject;
            dice.SetActive(false);
            if (gameObject.name == "RedGoal")
            {
                
                Debug.Log("RedPoint = " + redPoints);
               
                
            }
        }
        dice.transform.position = new Vector2(0, -1);
        StartCoroutine(WaitTime(1));


    }
    private IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        redPoints++;
        PointText.SetText(redPoints.ToString());
        dice.SetActive(true);


    }
}
