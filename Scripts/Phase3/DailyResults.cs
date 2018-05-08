using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DailyResults : MonoBehaviour {

    [SerializeField]
    private BudgetManager budgetManager;
    [SerializeField]
    private ProfitManager profitManager;
    [SerializeField]
    private HappinessManager happinessManager;
    [SerializeField]
    private BossReportManager bossReportManager;

    [HideInInspector]
    public float previousHappiness;

    [SerializeField]
    private Text budgetGain;
    [SerializeField]
    private Text budgetLoss;
    [SerializeField]
    private Text happinessResult;
    [SerializeField]
    private Text happinessDifference;
    [SerializeField]
    private Text bossBonuses;
    [SerializeField]
    private Text bossMood;

    void Start()
    { previousHappiness = 0; }

	void Update ()
    {
        if(NewDayManager.ThirdDayReset)
        {   UpdateResultsText(); }
	}

    void UpdateResultsText()
    {
        //budget and happiness text
        budgetGain.text = "Money Earned: $" + profitManager.BossPlusEarnings;
        budgetLoss.text = "Money Lost: $" + budgetManager.budgetLoss;
        happinessResult.text = "Animal Happiness: " + happinessManager.OverallHappiness + "%";
        float happinessDiff = (happinessManager.OverallHappiness - previousHappiness);
        happinessDifference.text = happinessDiff.ToString("f1") + " % difference";
        //Show boss bonus based on boss's mood
        if (bossReportManager.bossIsHappy)
        { bossBonuses.text = "Bonus from Boss: " + profitManager.bossBonus; }
        else if (bossReportManager.bossIsUnhappy)
        { bossBonuses.text = "No Bonuses."; }
        else
        { bossBonuses.text = "Deductions from Boss: " + profitManager.bossBonus; }
        //boss mood
        bossMood.text = "Boss's Mood: " + bossReportManager.bossMood;


        //turn off third day reset
        NewDayManager.ThirdDayReset = false;
    }

}
