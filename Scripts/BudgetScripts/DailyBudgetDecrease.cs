using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DailyBudgetDecrease : MonoBehaviour {

    [SerializeField]
    private BudgetManager budgetManager;

    private PenguinUpgradeManager penguUpgradeManager;
    private PandaUpgradeManager pandaUpgradeManager;
    private GorillaUpgradeManager gorillaUpgradeManager;
    private ZebraUpgradeManager zebraUpgradeManager;
    private KangarooUpgradeManager kangarooUpgradeManager;

    [SerializeField] private Text mainPenguBudgetTotal;
    [SerializeField] private Text mainPanBudgetTotal;
    [SerializeField] private Text mainGorBudgetTotal;
    [SerializeField] private Text mainZebBudgetTotal;
    [SerializeField] private Text mainKangBudgetTotal;

    [SerializeField] private Text penguBudgetTotal;
    [SerializeField] private Text panBudgetTotal;
    [SerializeField] private Text gorBudgetTotal;
    [SerializeField] private Text zebBudgetTotal;
    [SerializeField] private Text kangBudgetTotal;

    [SerializeField] private Text penguBudgetDesc;
    [SerializeField] private Text panBudgetDesc;
    [SerializeField] private Text gorBudgetDesc;
    [SerializeField] private Text zebBudgetDesc;
    [SerializeField] private Text kangBudgetDesc;

    private double penguTotalCost = 0;
    private double panTotalCost = 0;
    private double gorTotalCost = 0;
    private double zebTotalCost = 0;
    private double kangTotalCost = 0;

    [HideInInspector] public double dailyPenguFoodCost = 0;
    [HideInInspector] public double dailyPandaFoodCost = 0;
    [HideInInspector] public double dailyGorillaFoodCost = 0;
    [HideInInspector] public double dailyZebraFoodCost = 0;
    [HideInInspector] public double dailyKangarooFoodCost = 0;

    [HideInInspector] public double dailyPenguHabCost = 0;
    [HideInInspector] public double dailyPandaHabCost = 0;
    [HideInInspector] public double dailyGorillaHabCost = 0;
    [HideInInspector] public double dailyZebraHabCost = 0;
    [HideInInspector] public double dailyKangarooHabCost = 0;

    [HideInInspector] public double dailyPenguPopCost = 0;
    [HideInInspector] public double dailyPandaPopCost = 0;
    [HideInInspector] public double dailyGorillaPopCost = 0;
    [HideInInspector] public double dailyZebraPopCost = 0;
    [HideInInspector] public double dailyKangarooPopCost = 0;


    void Start()
    {
        penguUpgradeManager = this.GetComponent<PenguinUpgradeManager>();
        pandaUpgradeManager = this.GetComponent<PandaUpgradeManager>();
        gorillaUpgradeManager = this.GetComponent<GorillaUpgradeManager>();
        zebraUpgradeManager = this.GetComponent<ZebraUpgradeManager>();
        kangarooUpgradeManager = this.GetComponent<KangarooUpgradeManager>();
        //deciding how much is going to be decreased
        DecideCosts();
        //display stuff
        DisplayDailyCosts();
    }

    void Update()
    {
        //deciding how much is going to be decreased
        DecideCosts();
        //display stuff
        DisplayDailyCosts();

        //then if the third day is to be reset, decrease those costs
        if (NewDayManager.ThirdDayReset)
        {
            DecreaseFoodCost();
            DecreaseHabitatCost();
            DecreasePopulationCost();
        }
    }

    /*----------DECIDING HOW MUCH SHIT COSTS-----------*/

    void DecideCosts()
    {
        DecideFoodCost();
        DecideHabitatCost();
        DecidePopulationCost();
    }

    void DecideFoodCost() 
    {
        dailyPenguFoodCost = penguUpgradeManager.FoodCost();
        dailyPandaFoodCost = pandaUpgradeManager.FoodCost();
        dailyGorillaFoodCost = gorillaUpgradeManager.FoodCost();
        dailyZebraFoodCost = zebraUpgradeManager.FoodCost();
        dailyKangarooFoodCost = kangarooUpgradeManager.FoodCost();
    }

    void DecideHabitatCost()
    {
        dailyPenguHabCost = penguUpgradeManager.HabitatCost();
        dailyPandaHabCost = pandaUpgradeManager.HabitatCost();
        dailyGorillaHabCost = gorillaUpgradeManager.HabitatCost();
        dailyZebraHabCost = zebraUpgradeManager.HabitatCost();
        dailyKangarooHabCost = kangarooUpgradeManager.HabitatCost();
    }

    void DecidePopulationCost()
    {
        dailyPenguPopCost = penguUpgradeManager.PopulationCost();
        dailyPandaPopCost = pandaUpgradeManager.PopulationCost();
        dailyGorillaPopCost = gorillaUpgradeManager.PopulationCost();
        dailyZebraPopCost = zebraUpgradeManager.PopulationCost();
        dailyKangarooPopCost = kangarooUpgradeManager.PopulationCost();
    }

    /*----------DECREASING COSTS-----------*/

    void DecreaseFoodCost()
    {
        budgetManager.DailyStatDecrease(dailyPenguFoodCost);
        budgetManager.DailyStatDecrease(dailyPandaFoodCost);
        budgetManager.DailyStatDecrease(dailyGorillaFoodCost);
        budgetManager.DailyStatDecrease(dailyZebraFoodCost);
        budgetManager.DailyStatDecrease(dailyKangarooFoodCost);
    }

    void DecreaseHabitatCost()
    {
        budgetManager.DailyStatDecrease(dailyPenguHabCost);
        budgetManager.DailyStatDecrease(dailyPandaHabCost);
        budgetManager.DailyStatDecrease(dailyGorillaHabCost);
        budgetManager.DailyStatDecrease(dailyZebraHabCost);
        budgetManager.DailyStatDecrease(dailyKangarooHabCost);
    }

    void DecreasePopulationCost()
    {
        budgetManager.DailyStatDecrease(dailyPenguPopCost);
        budgetManager.DailyStatDecrease(dailyPandaPopCost);
        budgetManager.DailyStatDecrease(dailyGorillaPopCost);
        budgetManager.DailyStatDecrease(dailyZebraPopCost);
        budgetManager.DailyStatDecrease(dailyKangarooPopCost);
    }

    /*----------TOTAL ANIMAL COSTS DAILY-----------*/

    void FindTotalDailyCosts()
    {
        penguTotalCost = dailyPenguFoodCost + dailyPenguHabCost + dailyPenguPopCost;
        panTotalCost = dailyPandaFoodCost + dailyPandaHabCost + dailyPandaPopCost;
        gorTotalCost = dailyGorillaFoodCost + dailyGorillaHabCost + dailyGorillaPopCost;
        zebTotalCost = dailyZebraFoodCost + dailyZebraHabCost + dailyZebraPopCost;
        kangTotalCost = dailyKangarooFoodCost + dailyKangarooHabCost + dailyKangarooPopCost;
    }

    /*----------DISPLAY BUDGET IN SUB MENU-----------*/

    void DisplayDailyCosts()
    {
        FindTotalDailyCosts();
        //pengu display
        DisplaySubMenuBudgetText(penguTotalCost, dailyPenguFoodCost, dailyPenguHabCost, dailyPenguPopCost, mainPenguBudgetTotal, 
            penguBudgetTotal, penguBudgetDesc);
        //panda display
        DisplaySubMenuBudgetText(panTotalCost, dailyPandaFoodCost, dailyPandaHabCost, dailyPandaPopCost, mainPanBudgetTotal,
            panBudgetTotal, panBudgetDesc);
        //gorilla display
        DisplaySubMenuBudgetText(gorTotalCost, dailyGorillaFoodCost, dailyGorillaHabCost, dailyGorillaPopCost, mainGorBudgetTotal,
            gorBudgetTotal, gorBudgetDesc);
        //panda display
        DisplaySubMenuBudgetText(zebTotalCost, dailyZebraFoodCost, dailyZebraHabCost, dailyZebraPopCost, mainZebBudgetTotal,
            zebBudgetTotal, zebBudgetDesc);
        //panda display
        DisplaySubMenuBudgetText(kangTotalCost, dailyKangarooFoodCost, dailyKangarooHabCost, dailyKangarooPopCost, mainKangBudgetTotal,
            kangBudgetTotal, kangBudgetDesc);

    }

    void DisplaySubMenuBudgetText(double totalCost, double foodCost, double habCost, double popCost, Text mainMoneyTotal, Text moneyTotal, Text moneyDesc)
    {
        moneyTotal.text = "- $" + totalCost;
        mainMoneyTotal.text = "- $" + totalCost + " budget lost";
        moneyDesc.text =
            "- $" + foodCost + " = Food Costs"
            + "\n- $" + habCost + " = Habitat Upkeep"
            + "\n- $" + popCost + " = Animal Health";
    }

}