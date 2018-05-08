using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhaseTwoProblemSolver : MonoBehaviour {

    [SerializeField]
    private NotificationsDisplay notiDisplay;

    [SerializeField]
    private PhaseTwoProblemGenerator problemGen;
    [SerializeField]
    private BudgetManager budgetMang;
 
    #region Happiness Scripts
    [SerializeField]
    private GorillaHappiness gorHappiness;
    [SerializeField]
    private KangarooHappiness kangHappiness;
    [SerializeField]
    private PandaHappiness panHappiness;
    [SerializeField]
    private PenguinHappiness penHappiness;
    [SerializeField]
    private ZebrasHappiness zebHappiness;
    #endregion

    #region Button Pressed Bools
    public bool penguKeeperPressed { get; set; }
    public bool penguVetPressed { get; set; }

    public bool pandaKeeperPressed { get; set; }
    public bool pandaVetPressed { get; set; }

    public bool gorKeeperPressed { get; set; }
    public bool gorVetPressed { get; set; }

    public bool zebKeeperPressed { get; set; }
    public bool zebVetPressed { get; set; }

    public bool kangKeeperPressed { get; set; }
    public bool kangVetPressed { get; set; }
    #endregion

    #region Fees
    private double KeeperFee = 500;
    private double VetFee = 700;
    private double CuratorFee = 600;
    private double ServicesFee = 800;
    #endregion

    private int chanceOfHappyIncrease;

    private Dictionary<string, float> ButtonDisable = new Dictionary<string, float>();

	void Start () 
    {
        problemGen = this.GetComponent<PhaseTwoProblemGenerator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        /*print("penguin keeper bool : " + penguKeeperPressed);
        print("penguin vet bool : " + penguVetPressed);
        print("panda keeper bool : " + pandaKeeperPressed);
        print("panda vet bool : " + pandaVetPressed);
        print("gorilla keeper bool : " + gorKeeperPressed);
        print("gorilla vet bool : " + gorVetPressed);
        print("zebra keeper bool : " + zebKeeperPressed);
        print("zebra vet bool : " + zebVetPressed);
        print("kangaroo keeper bool : " + kangKeeperPressed);
        print("kangaroo vet bool : " + kangVetPressed);*/
	}

    public void KeeperProblemSolver(string animal, int minRange, int maxRange, bool ButtonPress)
    {
        //this prevents it from doing this until one item is solved
        if(!AllowButtonPress("keeper", animal))
        {
            return;
        }

        foreach (string problem in problemGen.DisplayedPhaseTwoProblemsList)
        {
            if (problemGen.Phase2Problems.IndexOf(problem) >= minRange && problemGen.Phase2Problems.IndexOf(problem) <= maxRange)
            {
                if (ButtonPress)
                {
                    HappinessIncreaseTest(animal, "Keeper");
                    budgetMang.DecreaseBudget(KeeperFee);
                    problemGen.CompletedPhaseTwoProblemsList.Add(problem);

                    // allow only one item to be solved per button press
                    return;
                }
            }
        }
    }

    public void VetProblemSolver(string animal, int minRange, int maxRange, bool ButtonPressed)
    {
        if (!AllowButtonPress("vet", animal))
        {
            return;
        }

        foreach (string problem in problemGen.DisplayedPhaseTwoProblemsList)
        {
            if (problemGen.Phase2Problems.IndexOf(problem) >= minRange && problemGen.Phase2Problems.IndexOf(problem) <= maxRange)
            {
                if (ButtonPressed)
                {
                    HappinessIncreaseTest(animal, "Vet");
                    budgetMang.DecreaseBudget(VetFee);
                    problemGen.CompletedPhaseTwoProblemsList.Add(problem);

                    // allow only one item to be solved per button press
                    return;
                }
            }
        }
    }

    public void GeneralCuratorProblemSolver(string type, int minRange, int maxRange, bool ButtonPressed)
    {
        if (!AllowButtonPress("curator", type))
        {
            return;
        }

        foreach (string problem in problemGen.DisplayedPhaseTwoProblemsList)
        {
            if (problemGen.Phase2Problems.IndexOf(problem) >= minRange && problemGen.Phase2Problems.IndexOf(problem) <= maxRange)
            {
                if (ButtonPressed)
                {
                    budgetMang.DecreaseBudget(CuratorFee);
                    problemGen.CompletedPhaseTwoProblemsList.Add(problem);
                    // allow only one item to be solved per button press
                    return;
                }
            }
        }
    }

    public void GeneralServicesProblemSolver(string type, int minRange, int maxRange, bool ButtonPressed)
    {
        if (!AllowButtonPress("services", type))
        {
            return;
        }

        foreach (string problem in problemGen.DisplayedPhaseTwoProblemsList)
        {
            if (problemGen.Phase2Problems.IndexOf(problem) >= minRange && problemGen.Phase2Problems.IndexOf(problem) <= maxRange)
            {
                if (ButtonPressed)
                {
                    budgetMang.DecreaseBudget(ServicesFee);
                    problemGen.CompletedPhaseTwoProblemsList.Add(problem);

                    // allow only one item to be solved per button press
                    return;
                }
            }
        }
    }

    public void Phase2KeeperProblemExpired(string animal)
    {
        //decrease animal happiness by 5 depending on animal 
        MaintenanceHappinessControl(animal, -5);
    }

    public void Phase2VetProblemsExpired(string animal)
    {
        //decrease animal happiness by 5 depending on animal 
       SocialHappinessControl(animal, -5);
    }


    //random chance for player to gain happiness
    void HappinessIncreaseTest(string animal, string problemType)
    {
        chanceOfHappyIncrease = Random.Range(0, 4);

        if(chanceOfHappyIncrease == 1 || chanceOfHappyIncrease == 3)
        {
            if(problemType == "Keeper")
            {
                string happyType = "maintenance";
                //increase happiness by 5 based on animal
                MaintenanceHappinessControl(animal, 5);
                notiDisplay.NewNotification(animal, happyType, "+");
            }
            else
            {
                string happyType = "amusement";
                // increase happiness by 5 based on animal
                SocialHappinessControl(animal, 5);
                notiDisplay.NewNotification(animal, happyType, "+");
            }
        }
        else
        { return; }
    }

    void MaintenanceHappinessControl(string animal, int changeAmount)
    {
        switch (animal)
        {
            case "penguin":
                penHappiness.maintHappiness += changeAmount;
                break;

            case "panda":
                panHappiness.maintHappiness += changeAmount;
                break;

            case "gorilla":
                gorHappiness.maintHappiness += changeAmount;
                break;

            case "zebra":
                zebHappiness.maintHappiness += changeAmount;
                break;

            case "kangaroo":
                kangHappiness.maintHappiness += changeAmount;
                break;
        }
    }

    void SocialHappinessControl(string animal, int changeAmount)
    {
        switch (animal)
        {
            case "penguin":
                penHappiness.socialHappiness += changeAmount;
                break;

            case "panda":
                panHappiness.socialHappiness += changeAmount;
                break;

            case "gorilla":
                gorHappiness.socialHappiness += changeAmount;
                break;

            case "zebra":
                zebHappiness.socialHappiness += changeAmount;
                break;

            case "kangaroo":
                kangHappiness.socialHappiness += changeAmount;
                break;
        }
    }

    void BudgetControl(int changeAmount)
    {
        budgetMang.DecreaseBudget(changeAmount);
    }

    private bool AllowButtonPress(string type, string animal)
    {
        // Key is the method of identifying each particular button.
        // This could be keeper_pengu, vet_gorilla, etc.
        string Key = type + "_" + animal;

        // Get the current time in seconds
        float CurrentTimestamp = Time.time;
        float ButtonLastPressed;

        // If the player has pushed this button before it will already be in the dictionary
        if (ButtonDisable.ContainsKey(Key))
        {
            // If it is in the dictionary, get the last successful time the player pushed the button
            ButtonLastPressed = ButtonDisable[Key];

            // If at least x seconds have passed since the last time the player pushed bhe button...
            if (CurrentTimestamp - ButtonLastPressed > 2)
            {
                // Update the time stored in the dictionary to the current time and allow the button press to work
                ButtonDisable[Key] = CurrentTimestamp;

                return true;
            }
            // If x seconds have not passed, don't allow the button press to do anything
            else
            {
                return false;
            }
        }
        // If this is the first time the player has pushed this button..
        else
        {
            // Store the button identifier in the dictionary and set it's value to the current time
            ButtonDisable[Key] = CurrentTimestamp;

            // Allow the button press to work
            return true;
        }
    }
}
