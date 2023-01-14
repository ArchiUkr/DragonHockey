using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalBLUE : MonoBehaviour
{
    GameObject dice;
    public TextMeshProUGUI PointText;

    public static  int bluePoints;
    public AudioSource Goal;
    public GameObject DRB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Disk")
        {
            DRB.GetComponent<Animator>().Play("RDAS");
            Goal.Play();
            dice = collision.gameObject;
            dice.SetActive(false);
            if (gameObject.name == "BlueGoal")
            {
                
                Debug.Log("BluePoint = " + bluePoints);
                

            }
        }
        dice.transform.position = new Vector2(0, -1);
        StartCoroutine(WaitTime(1));


    }
    private IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        bluePoints++;
        PointText.SetText(bluePoints.ToString());
        dice.SetActive(true);

    }
}
