using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public int Duration;
    private int remainingDuration;

    public bool stop = false;


    [Header("GameObjects")]
    public GameObject MainMenu;
    public GameObject Dice;
    public GameObject DRR;
    public GameObject DRB;

    public GameObject WinManager;
    public GameObject Victory;
    public GameObject Lose;
    public GameObject Draw;

    private void Update()
    {
        if(stop == true)
        {
            Time.timeScale = 0;
        }
        if(stop == false)
        {
            Time.timeScale = 1;
        }

       
       

    }

   public void onPause()
    {
        stop = true;
        MainMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        stop = false;
        MainMenu.SetActive(false);

    }
    public void NewGame()
    {
        Being(Duration);
        MainMenu.SetActive(false);
        GoalBLUE.bluePoints = 0;
        GoalRED.redPoints = 0;
        Time.timeScale = 1;

        DRR.SetActive(true);
        DRB.SetActive(true);
        Dice.SetActive(true);
    }

    private void Being(int sec)
    {
        remainingDuration = sec;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            remainingDuration--;
            yield return new WaitForSeconds(1f);

        }
        OnEnd();
    }

    private void OnEnd()
    {
        WinManager.SetActive(true);
        if(GoalBLUE.bluePoints > GoalRED.redPoints )
        {
            Victory.SetActive(true);
            Lose.SetActive(false);
            Draw.SetActive(false);

        }
        if(GoalBLUE.bluePoints < GoalRED.redPoints )
        {
            Lose.SetActive(true);
            Draw.SetActive(false);
            Victory.SetActive(false);
        }
        if (GoalBLUE.bluePoints == GoalRED.redPoints)
        {
            Draw.SetActive(true);
            Lose.SetActive(false);
            Victory.SetActive(false);

        }
    }

    public void CloseWinManager()
    {
        WinManager.SetActive(false);
        MainMenu.SetActive(true);
    }

}
