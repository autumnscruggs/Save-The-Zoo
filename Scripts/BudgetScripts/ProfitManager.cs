using UnityEngine;
using System.Collections;

public class ProfitManager : MonoBehaviour 
{
    //[SerializeField]
    //private HappinessManager happyMan;
    [SerializeField]
    private ChangingPhases changingPhase;
    [SerializeField]
    private DayCycleManager dayCycle;

    private float averageHappiness;
    private float baselineEarnings = 500f;
    private float dailyEarnings;

    private float happyBossBonus = 2f;
    private float pissedBossDeduction = 2f;

    [HideInInspector]
    public float bossBonus;

    private BudgetManager budgetManager;

    [SerializeField]
    private BossReportManager bossReports;

    private float bossPlusEarnings = 0f;
    public float BossPlusEarnings { get { return bossPlusEarnings; } }

    void Start()
    {
        budgetManager = this.GetComponent<BudgetManager>();
    }

	// Update is called once per frame
	void Update () 
    {

        if (NewDayManager.ThirdDayReset)
        {
            AddEarningsToBudget();
        }

        CalculateDailyEarnings();

        FigureOutBossBonus();
	}


    void FindingAverageDailyHappiness()
    {
        averageHappiness = (changingPhase.phase1Happiness + dayCycle.phase2happiness) / 2; 
    }

    void CalculateDailyEarnings()
    {
        //get the average happiness from phase 1 and phase 2 (so we don't punish the player for failing hard on one or the other)
        FindingAverageDailyHappiness();
        //then multiply that by a base earnings to see how much they make
        dailyEarnings = baselineEarnings * averageHappiness;

        //change daily earnings based on boss mood
        if (bossReports.bossIsHappy)
        { 
            bossPlusEarnings = dailyEarnings * happyBossBonus;
        }
        else if (bossReports.bossIsPissed)
        {
            bossPlusEarnings =  dailyEarnings / pissedBossDeduction;
        }
        else
        { return; }

    }

    public void AddEarningsToBudget()
    {
        budgetManager.budgetTotal += dailyEarnings;
    }

    void FigureOutBossBonus()
    {
        if (bossReports.bossIsHappy)
        { bossBonus = bossPlusEarnings - dailyEarnings; }
        else if (bossReports.bossIsPissed)
        { 
            bossBonus = (bossPlusEarnings / pissedBossDeduction); 
        }
        else
        { 
            bossBonus = 0;
            bossPlusEarnings = dailyEarnings;
        }
    }
}
