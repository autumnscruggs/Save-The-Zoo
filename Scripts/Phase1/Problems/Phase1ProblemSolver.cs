using UnityEngine;
using System.Collections;

public class Phase1ProblemSolver : MonoBehaviour {

    private Phase1ProblemGenerator phase1Gen;
    [SerializeField]
    private BudgetManager budgetMang;
    [SerializeField]
    private AnimalFoodButton animalFood;
    [SerializeField]
    private AnimalHabitatButtons animalHab;
    [SerializeField]
    private AnimalSocialButton animalSoc;

    private int foodUpgradeNum = 0;
    private int habitatUpgradeNum = 0;
    private int populationUpgradeNum = 0;



    // Use this for initialization
    void Start () 
    {
        phase1Gen = this.GetComponent<Phase1ProblemGenerator>();
	}


    public void ProblemSolver(string animal, int buttonNum, bool ButtonPress)
    {
            string problemInQuestion = phase1Gen.ProblemsList[buttonNum];

            if (ButtonPress)
            {
                UpgradeDeduction(buttonNum);
                phase1Gen.CompletedProblemList.Add(problemInQuestion);

            }
    }

    public void UpgradeDeduction(int buttonNum)
    {
        switch (buttonNum)
        {
            //penguin food problems
            case 0://sardines and herring
                budgetMang.DecreaseBudget(100f);
                break;
            case 1://smelt and anchovies
                budgetMang.DecreaseBudget(100f);
                break;
            case 2: //squid
                budgetMang.DecreaseBudget(65f);
                break;
            //panda food problems
            case 3://10% more bamboo
                budgetMang.DecreaseBudget(100f);
                break;
            case 4://bamboo & fruit
                budgetMang.DecreaseBudget(60f);
                break;
            case 5://leafeater biscuits
                budgetMang.DecreaseBudget(50f);
                break;
            //gorilla food problems
            case 6: //romaine lettuce & greens
                budgetMang.DecreaseBudget(50f);
                break;
            case 7: //stems and natural food
                budgetMang.DecreaseBudget(70f);
                break;
            case 8: //fruits
                budgetMang.DecreaseBudget(60f);
                break;
            //zebra food problems
            case 9: //timothy hay
                budgetMang.DecreaseBudget(200f);
                break;
            case 10: //hay and herbivore pellets
                budgetMang.DecreaseBudget(60f);
                break;
            case 11: //hay, pellets, carrots, apples
                budgetMang.DecreaseBudget(50f);
                break;
            //kangaroo food problems
            case 12: //herbivore pellets
                budgetMang.DecreaseBudget(60f);
                break;
            case 13: //broccoli
                budgetMang.DecreaseBudget(70f);
                break;
            case 14: //sweet potatoes
                budgetMang.DecreaseBudget(20f);
                break;
            //penguin habitat problems
            case 15://expanded habitat
                budgetMang.DecreaseBudget(10000f);
                break;
            case 16://deep tank
                budgetMang.DecreaseBudget(10000f);
                break;
            //panda habitat problems
            case 17://2 sq mile forest
                budgetMang.DecreaseBudget(4000f);
                break;
            case 18://2.5 sq mile forest
                budgetMang.DecreaseBudget(4500f);
                break;
            //gorilla habitat problems
            case 19: //expand habitat
                budgetMang.DecreaseBudget(1200f);
                break;
            //zebra habitat problems
            case 20: //expand habitat
                budgetMang.DecreaseBudget(2000f);
                break;
            //kangaroo habitat problems
            case 21: //open grasslands
                budgetMang.DecreaseBudget(6000f);
                break;
            //penguin population problems
            case 22://more penguins
                budgetMang.DecreaseBudget(6000f);
                break;
            case 23://more penguins
                budgetMang.DecreaseBudget(6000f);
                break;
            case 24://penguin toys
                budgetMang.DecreaseBudget(200f);
                break;
            //panda population problems
            case 25://bamboo barriers
                budgetMang.DecreaseBudget(100f);
                break;
            case 26://panda dens
                budgetMang.DecreaseBudget(200f);
                break;
            case 27://water pond
                budgetMang.DecreaseBudget(300f);
                break;
            //gorilla population problems
            case 28: //toys
                budgetMang.DecreaseBudget(150f);
                break;
            case 29: //hammocks
                budgetMang.DecreaseBudget(600f);
                break;
            case 30: //fake trees
                budgetMang.DecreaseBudget(2500f);
                break;
            //zebra population problems
            case 31: //add pond
                budgetMang.DecreaseBudget(4000f);
                break;
            case 32: //marula trees
                budgetMang.DecreaseBudget(2500f);
                break;
            case 33: //huts
                budgetMang.DecreaseBudget(3000f);
                break;
            //kangaroo population problems
            case 34:
                budgetMang.DecreaseBudget(55f);
                break;
            case 35:
                budgetMang.DecreaseBudget(125f);
                break;
            case 36:
                budgetMang.DecreaseBudget(250f);
                break;
        }
    }


}
