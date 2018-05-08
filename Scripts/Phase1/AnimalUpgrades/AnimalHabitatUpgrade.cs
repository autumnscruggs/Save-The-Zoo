using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AnimalHabitatUpgrade : MonoBehaviour 
{


    private AnimalHabitatButtons animalHabButtons;

    [SerializeField]
    private DailyBudgetDecrease dailyBudget;

    [SerializeField] private GameObject pengHabitat01;
    [SerializeField] private GameObject pengHabitat02;
    [SerializeField] private GameObject panHabitat01;
    [SerializeField] private GameObject panHabitat02;
    [SerializeField] private GameObject gorHabitat01;
    [SerializeField] private GameObject zebHabitat01;
    [SerializeField] private GameObject kangHabitat01;

    [SerializeField]
    private Text penguHabDesc;
    [SerializeField]
    private Text panHabDesc;
    [SerializeField]
    private Text gorHabDesc;
    [SerializeField]
    private Text zebHabDesc;
    [SerializeField]
    private Text kangHabDesc;

    [SerializeField]
    private List<string> penguinHabitats = new List<string>();
    [SerializeField]
    private List<string> pandaHabitats = new List<string>();
    [SerializeField]
    private List<string> gorillaHabitats = new List<string>();
    [SerializeField]
    private List<string> zebraHabitats = new List<string>();
    [SerializeField]
    private List<string> kangarooHabitats = new List<string>();

    void Start()
    {
        animalHabButtons = this.GetComponent<AnimalHabitatButtons>();
        //setting all the things to false initially
        HideHabitats();
    }


    public void UpgradeHabitats(int habLevel, string animal)
    {
        switch(animal)
        {
            case "penguin":
                if(habLevel == 0)
                {
                    DisplayHabDescText(penguHabDesc, penguinHabitats[0], dailyBudget.dailyPenguHabCost);
                }
                else if(habLevel == 1)
                {
                    DisplayHabDescText(penguHabDesc, penguinHabitats[1], dailyBudget.dailyPenguHabCost);
                    pengHabitat01.SetActive(true);
                }
                else
                {
                    DisplayHabDescText(penguHabDesc, penguinHabitats[2], dailyBudget.dailyPenguHabCost);
                    pengHabitat02.SetActive(true);
                }
                break;

            case "panda":
                if(habLevel == 0)
                {
                    DisplayHabDescText(panHabDesc, pandaHabitats[0], dailyBudget.dailyPandaHabCost);
                }
                else if (habLevel == 1)
                {
                    DisplayHabDescText(panHabDesc, pandaHabitats[1], dailyBudget.dailyPandaHabCost);
                    panHabitat01.SetActive(true);
                }
                else
                {
                    DisplayHabDescText(panHabDesc, pandaHabitats[2], dailyBudget.dailyPandaHabCost);
                    panHabitat02.SetActive(true);
                }
                break;

            case "gorilla":
                if(habLevel == 0)
                {
                    DisplayHabDescText(gorHabDesc, gorillaHabitats[0], dailyBudget.dailyGorillaHabCost);
                }
                else if (habLevel == 1)
                {
                    DisplayHabDescText(gorHabDesc, gorillaHabitats[1], dailyBudget.dailyGorillaHabCost);
                    gorHabitat01.SetActive(true);
                }
                else
                {
                    DisplayHabDescText(gorHabDesc, gorillaHabitats[2], dailyBudget.dailyGorillaHabCost);
                }
                break;

            case "zebra":
                if (habLevel == 0)
                {
                    DisplayHabDescText(zebHabDesc, zebraHabitats[0], dailyBudget.dailyZebraHabCost);
                }
                else if (habLevel == 1)
                {
                    DisplayHabDescText(zebHabDesc, zebraHabitats[1], dailyBudget.dailyZebraHabCost);
                    zebHabitat01.SetActive(true);
                }
                else
                {
                    DisplayHabDescText(zebHabDesc, zebraHabitats[2], dailyBudget.dailyZebraHabCost);
                }
                break;

            case "kangaroo":
                if (habLevel == 0)
                {
                    DisplayHabDescText(kangHabDesc, kangarooHabitats[0], dailyBudget.dailyKangarooHabCost);
                }
                else if (habLevel == 1)
                { 
                    DisplayHabDescText(kangHabDesc, kangarooHabitats[1], dailyBudget.dailyKangarooHabCost);
                    kangHabitat01.SetActive(true);
                }
                else
                {
                    DisplayHabDescText(kangHabDesc, kangarooHabitats[2], dailyBudget.dailyKangarooHabCost);
                }
                break;

        }
    }

    void HideHabitats()
    {
        pengHabitat01.SetActive(false);
        pengHabitat02.SetActive(false);
        panHabitat01.SetActive(false);
        panHabitat02.SetActive(false);
        gorHabitat01.SetActive(false);
        zebHabitat01.SetActive(false);
        kangHabitat01.SetActive(false);
    }

    void DisplayHabDescText(Text habDesc, string habType, double habost)
    {
        habDesc.text = "" + habType + "\n -$" + habost + " for upkeep";
    }
}
