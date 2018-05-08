using UnityEngine;
using System.Collections;

public class WinAndLoseConditions : MonoBehaviour {

    private bool winGame = false;
    private bool gameOver = false;

    [SerializeField]
    private int daysSurvivedToWin = 30;
    [SerializeField]
    private double debtAmountForLosing = -100000;
    [SerializeField]
    private float happinessAmountForLosing = 25f;

    [SerializeField]
    private BudgetManager budgetManager;
    [SerializeField]
    private HappinessManager happinessManager;

	void Update () 
    {
        //they can't win or lose on the first day
        if (NewDayManager.DayCount > 0)
        {
            CheckWinCondition();
            CheckLoseCondition();
        }

	}

    void CheckWinCondition()
    {
        //the plus one just means they have to survive the whole day
        if (NewDayManager.DayCount >= daysSurvivedToWin + 1)
        {
            winGame = true;
        }

        WinAndLoseGame();
    }


    void CheckLoseCondition()
    {
        if (budgetManager.budgetTotal <= debtAmountForLosing) 
        {
            gameOver = true;
        }
        if (happinessManager.OverallHappiness <= happinessAmountForLosing) 
         {
             gameOver = true;
         }

        WinAndLoseGame();
    }

    void WinAndLoseGame()
    {
        if (winGame)
        {
            Application.LoadLevel("WinScene");
        }
        else if(gameOver)
        {
            Application.LoadLevel("Gameovasucka");
        }
    }
}
