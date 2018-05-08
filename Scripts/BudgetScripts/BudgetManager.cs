using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BudgetManager : MonoBehaviour {

    public double budgetTotal = 2000000;//actual budget total which can be subtracted/added to

    [SerializeField]
    private Text budgetText;
    [HideInInspector]
    public double budgetLoss = 0;

    void Update()
    {
        //reset budget loss on first day
        if(NewDayManager.FirstDayReset)
        {  budgetLoss = 0; }

        UpdateBudgetText();
    }

    void UpdateBudgetText()
    {
        budgetText.text = "$" + budgetTotal;
    }

    //methods used whenever subtract money from budget from phase 1 problems
    public double DecreaseBudget(double decreaseAmount)//make void instead and add custum variables?
    {
        budgetLoss += decreaseAmount;
        budgetTotal = budgetTotal - decreaseAmount;

        return budgetTotal;
    }

    public double DailyStatDecrease(double statDecrease)
    {
        budgetLoss += statDecrease;
        budgetTotal = budgetTotal - statDecrease;
        return budgetTotal;
    }

    //For phase 2 problems
    public double DecreaseFeed(double decreaseFoodFee)
    {
        budgetLoss += decreaseFoodFee;
        budgetTotal = budgetTotal - decreaseFoodFee;
        return budgetTotal;
    }

    public double DecreaseMaintenance(double decreaseMaintenanceFee)
    {
        budgetLoss += decreaseMaintenanceFee;
        budgetTotal = budgetTotal - decreaseMaintenanceFee;
        return budgetTotal;
    }

    public double DecreaseSocial(double decreaseSocialFee)
    {
        budgetLoss += decreaseSocialFee;
        budgetTotal = budgetTotal - decreaseSocialFee;
        return budgetTotal;
    }


}
