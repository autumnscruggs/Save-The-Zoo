using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AnimalFoodUpgrade : MonoBehaviour {

    private AnimalFoodButton animalFoodButtons;

    [SerializeField]
    private DailyBudgetDecrease dailyBudget;

    [SerializeField] private Text penguFoodDesc;
    [SerializeField] private Text panFoodDesc;
    [SerializeField] private Text gorFoodDesc;
    [SerializeField] private Text zebFoodDesc;
    [SerializeField] private Text kangFoodDesc;

    [SerializeField]
    private List<string> penguinFood = new List<string>();

    [SerializeField]
    private List<string> pandaFood = new List<string>();

    [SerializeField]
    private List<string> gorillaFood = new List<string>();

    [SerializeField]
    private List<string> zebraFood = new List<string>();

    [SerializeField]
    private List<string> kangarooFood = new List<string>();

    void Start () 
    {
        animalFoodButtons = this.GetComponent<AnimalFoodButton>();
	}

	
	// Update is called once per frame
    public void UpgradeFoods(int foodLevel, string animal) 
    {
	    switch(animal)
        {
            case "penguin":
                if(foodLevel == 0)
                {
                    DisplayFoodDescText(penguFoodDesc, penguinFood[0], dailyBudget.dailyPenguFoodCost);
                }
                else if(foodLevel == 1)
                {
                    DisplayFoodDescText(penguFoodDesc, penguinFood[1], dailyBudget.dailyPenguFoodCost);
                }
                else if(foodLevel == 2)
                {
                    DisplayFoodDescText(penguFoodDesc, penguinFood[2], dailyBudget.dailyPenguFoodCost);
                }
                else if (foodLevel == 3)
                {
                    DisplayFoodDescText(penguFoodDesc, penguinFood[3], dailyBudget.dailyPenguFoodCost);
                }
                break;

            case "panda":
                if (foodLevel == 0)
                {
                    DisplayFoodDescText(panFoodDesc, pandaFood[0], dailyBudget.dailyPandaFoodCost);
                }
                else if(foodLevel == 1)
                {
                    DisplayFoodDescText(panFoodDesc, pandaFood[1], dailyBudget.dailyPandaFoodCost);
                }
                else if(foodLevel == 2)
                {
                    DisplayFoodDescText(panFoodDesc, pandaFood[2], dailyBudget.dailyPandaFoodCost);
                }
                else if (foodLevel == 3)
                {
                    DisplayFoodDescText(panFoodDesc, pandaFood[3], dailyBudget.dailyPandaFoodCost);
                }
                break;

            case "gorilla":
                if (foodLevel == 0)
                {
                    DisplayFoodDescText(gorFoodDesc, gorillaFood[0], dailyBudget.dailyGorillaFoodCost);
                }
                else if (foodLevel == 1)
                {
                    DisplayFoodDescText(gorFoodDesc, gorillaFood[1], dailyBudget.dailyGorillaFoodCost);
                }
                else if (foodLevel == 2)
                {
                    DisplayFoodDescText(gorFoodDesc, gorillaFood[2], dailyBudget.dailyGorillaFoodCost);
                }
                else if (foodLevel == 3)
                {
                    DisplayFoodDescText(gorFoodDesc, gorillaFood[3], dailyBudget.dailyGorillaFoodCost);
                }
                break;

            case "zebra":
                if (foodLevel == 0)
                {
                    DisplayFoodDescText(zebFoodDesc, zebraFood[0], dailyBudget.dailyZebraFoodCost);
                }
                else if (foodLevel == 1)
                {
                    DisplayFoodDescText(zebFoodDesc, zebraFood[1], dailyBudget.dailyZebraFoodCost);
                }
                else if (foodLevel == 2)
                {
                    DisplayFoodDescText(zebFoodDesc, zebraFood[2], dailyBudget.dailyZebraFoodCost);
                }
                else if (foodLevel == 3)
                {
                    DisplayFoodDescText(zebFoodDesc, zebraFood[3], dailyBudget.dailyZebraFoodCost);
                }
                break;


            case "kangaroo":
                if (foodLevel == 0)
                {
                    DisplayFoodDescText(kangFoodDesc, kangarooFood[0], dailyBudget.dailyKangarooFoodCost);
                }
                else if (foodLevel == 1)
                {
                    DisplayFoodDescText(kangFoodDesc, kangarooFood[1], dailyBudget.dailyKangarooFoodCost);
                }
                else if (foodLevel == 2)
                {
                    DisplayFoodDescText(kangFoodDesc, kangarooFood[2], dailyBudget.dailyKangarooFoodCost);
                }
                else if (foodLevel == 3)
                {
                    DisplayFoodDescText(kangFoodDesc, kangarooFood[3], dailyBudget.dailyKangarooFoodCost);
                }
                break;
        }
	}


    void DisplayFoodDescText(Text foodDesc, string foodType, double foodCost)
    {
        foodDesc.text = "" + foodType + "\n -$" + foodCost + " for food";
    }

}
