using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AnimalSocialUpgrade : MonoBehaviour {

    private AnimalSocialButton animalSocialButtons;

    [SerializeField]
    private DailyBudgetDecrease dailyBudget;

    [SerializeField]
    private Text penguSocialDesc;
    [SerializeField]
    private Text panSocialDesc;
    [SerializeField]
    private Text gorSocialDesc;
    [SerializeField]
    private Text zebSocialDesc;
    [SerializeField]
    private Text kangSocialDesc;

    [SerializeField]
    private List<string> penguinPopulation = new List<string>();

    [SerializeField]
    private List<string> pandaPopulation = new List<string>();

    [SerializeField]
    private List<string> gorillaPopulation = new List<string>();

    [SerializeField]
    private List<string> zebraPopulation = new List<string>();

    [SerializeField]
    private List<string> kangarooPopulation = new List<string>();

    // Use this for initialization
    void Start () 
    {
        animalSocialButtons = this.GetComponent<AnimalSocialButton>();
	}
	
	// Update is called once per frame
	public void SocialUpgrade (int socialLevel, string animal)
    {
        switch (animal)
        {
            case "penguin":
                if(socialLevel == 0)
                {
                    DisplaySocialDescText(penguSocialDesc, penguinPopulation[0], dailyBudget.dailyPenguPopCost);
                }
                else if (socialLevel == 1)
                {
                    DisplaySocialDescText(penguSocialDesc, penguinPopulation[1], dailyBudget.dailyPenguPopCost);
                }
                else if (socialLevel == 2)
                {
                    DisplaySocialDescText(penguSocialDesc, penguinPopulation[2], dailyBudget.dailyPenguPopCost);
                }
                else if (socialLevel == 3)
                {
                    DisplaySocialDescText(penguSocialDesc, penguinPopulation[3], dailyBudget.dailyPenguPopCost);
                }
                break;

            case "panda":
                if (socialLevel == 0)
                {
                    DisplaySocialDescText(panSocialDesc, pandaPopulation[0], dailyBudget.dailyPandaPopCost);
                }
                else if (socialLevel == 1)
                {
                    DisplaySocialDescText(panSocialDesc, pandaPopulation[1], dailyBudget.dailyPandaPopCost);
                }
                else if (socialLevel == 2)
                {
                    DisplaySocialDescText(panSocialDesc, pandaPopulation[2], dailyBudget.dailyPandaPopCost);
                }
                else if (socialLevel == 3)
                {
                    DisplaySocialDescText(panSocialDesc, pandaPopulation[3], dailyBudget.dailyPandaPopCost);
                }
                break;

            case "gorilla":
                if (socialLevel == 0)
                {
                    DisplaySocialDescText(gorSocialDesc, gorillaPopulation[0], dailyBudget.dailyGorillaPopCost);
                }
                else if (socialLevel == 1)
                {
                    DisplaySocialDescText(gorSocialDesc, gorillaPopulation[1], dailyBudget.dailyGorillaPopCost);
                }
                else if (socialLevel == 2)
                {
                    DisplaySocialDescText(gorSocialDesc, gorillaPopulation[2], dailyBudget.dailyGorillaPopCost);
                }
                else if (socialLevel == 3)
                {
                    DisplaySocialDescText(gorSocialDesc, gorillaPopulation[3], dailyBudget.dailyGorillaPopCost);
                }
                break;

            case "zebra":
                if (socialLevel == 0)
                {
                    DisplaySocialDescText(zebSocialDesc, zebraPopulation[0], dailyBudget.dailyZebraPopCost);
                }
                else if (socialLevel == 1)
                {
                    DisplaySocialDescText(zebSocialDesc, zebraPopulation[1], dailyBudget.dailyZebraPopCost);
                }
                else if (socialLevel == 2)
                {
                    DisplaySocialDescText(zebSocialDesc, zebraPopulation[2], dailyBudget.dailyZebraPopCost);
                }
                else if (socialLevel == 3)
                {
                    DisplaySocialDescText(zebSocialDesc, zebraPopulation[3], dailyBudget.dailyZebraPopCost);
                }
                break;


            case "kangaroo":
                if (socialLevel == 0)
                {
                    DisplaySocialDescText(kangSocialDesc, kangarooPopulation[0], dailyBudget.dailyKangarooPopCost);
                }
                else if (socialLevel == 1)
                {
                    DisplaySocialDescText(kangSocialDesc, kangarooPopulation[1], dailyBudget.dailyKangarooPopCost);
                }
                else if (socialLevel == 2)
                {
                    DisplaySocialDescText(kangSocialDesc, kangarooPopulation[2], dailyBudget.dailyKangarooPopCost);
                }
                else if (socialLevel == 3)
                {
                    DisplaySocialDescText(kangSocialDesc, kangarooPopulation[3], dailyBudget.dailyKangarooPopCost);
                }
                break;
        }
	}


    void DisplaySocialDescText(Text socialDesc, string socialType, double socialCost)
    {
        socialDesc.text = "" + socialType + "\n -$" + socialCost + " for health";
    }

}
