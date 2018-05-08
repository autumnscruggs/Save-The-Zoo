using UnityEngine;
using System.Collections;

public class PandaUpgradeManager : MonoBehaviour {

    private AnimalFoodButton animalFoodButton;
    private AnimalHabitatButtons animalHabButton;
    private AnimalSocialButton animalPopButton;

    private int foodUpgradeNumber = 0;
    private int habUpgradeNumber = 0;
    private int popUpgradeNumber = 0;

    public double defaultFoodCost = 1000;
    public double upgrade1FoodCost = 1500;
    public double upgrade2FoodCost = 2000;
    public double upgrade3FoodCost = 2500;

    public double defaultHabCost = 1000;
    public double upgrade1HabCost = 1500;
    public double upgrade2HabCost = 2000;

    public double defaultPopCost = 1000;
    public double upgrade1PopCost = 1500;
    public double upgrade2PopCost = 2000;
    public double upgrade3PopCost = 2500;

    void Start()
    {
        //script refs
        animalFoodButton = GameObject.Find("FoodUpgradeMaster").GetComponent<AnimalFoodButton>();
        animalHabButton = GameObject.Find("HabitatUpgradeMaster").GetComponent<AnimalHabitatButtons>();
        animalPopButton = GameObject.Find("PopulationUpgradeMaster").GetComponent<AnimalSocialButton>();
    }

    void SetUpgradeNumbers()
    {
        foodUpgradeNumber = animalFoodButton.panFoodLevel;
        habUpgradeNumber = animalHabButton.panHabLevel;
        popUpgradeNumber = animalPopButton.panSocialLevel;
    }

    void Update()
    {
        SetUpgradeNumbers();
    }

    public double FoodCost()
    {
        switch (foodUpgradeNumber)
        {
            case 0:
                return defaultFoodCost;
                break;
            case 1:
                return upgrade1FoodCost;
                break;
            case 2:
                return upgrade2FoodCost;
                break;
            case 3:
                return upgrade3FoodCost;
                break;
            default:
                return defaultFoodCost;
                break;
        }
    }

    public double HabitatCost()
    {
        switch (habUpgradeNumber)
        {
            case 0:
                return defaultHabCost;
                break;
            case 1:
                return upgrade1HabCost;
                break;
            case 2:
                return upgrade2HabCost;
                break;
            default:
                return defaultHabCost;
                break;
        }
    }

    public double PopulationCost()
    {
        switch (popUpgradeNumber)
        {
            case 0:
                return defaultPopCost;
                break;
            case 1:
                return upgrade1PopCost;
                break;
            case 2:
                return upgrade2PopCost;
                break;
            case 3:
                return upgrade3PopCost;
                break;
            default:
                return defaultPopCost;
                break;
        }
    }
}
