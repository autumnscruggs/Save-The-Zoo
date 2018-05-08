using UnityEngine;
using System.Collections;

public class AnimalFoodButton : MonoBehaviour 
{
	[SerializeField] 
	private AudioSource ClickSound;

    private AnimalFoodUpgrade animalFoodUp;
    [SerializeField]
    private Phase1ProblemSolver phase1Solver;


    [SerializeField]
    private GameObject pengFoodUp1Button;
    [SerializeField]
    private GameObject pengFoodUp2Button;
    [SerializeField]
    private GameObject pengFoodUp3Button;

    [SerializeField]
    private GameObject panFoodUp1Button;
    [SerializeField]
    private GameObject panFoodUp2Button;
    [SerializeField]
    private GameObject panFoodUp3Button;

    [SerializeField]
    private GameObject gorFoodUp1Button;
    [SerializeField]
    private GameObject gorFoodUp2Button;
    [SerializeField]
    private GameObject gorFoodUp3Button;

    [SerializeField]
    private GameObject zebFoodUp1Button;
    [SerializeField]
    private GameObject zebFoodUp2Button;
    [SerializeField]
    private GameObject zebFoodUp3Button;

    [SerializeField]
    private GameObject kangFoodUp1Button;
    [SerializeField]
    private GameObject kangFoodUp2Button;
    [SerializeField]
    private GameObject kangFoodUp3Button;

    [HideInInspector]
    public int pengFoodLevel = 0;
    [HideInInspector]
    public int panFoodLevel = 0;
    [HideInInspector]
    public int gorFoodLevel = 0;
    [HideInInspector]
    public int zebFoodLevel = 0;
    [HideInInspector]
    public int kangFoodLevel = 0;

	void Start () 
    {
        animalFoodUp = this.GetComponent<AnimalFoodUpgrade>();
        UpgradeFoods();
    }
	
    void Update()
    {
        FoodButtonVisibility();
        UpgradeFoods();
    }

    //setting default foods
    void UpgradeFoods()
    {
        animalFoodUp.UpgradeFoods(pengFoodLevel, "penguin");
        animalFoodUp.UpgradeFoods(panFoodLevel, "panda");
        animalFoodUp.UpgradeFoods(gorFoodLevel, "gorilla");
        animalFoodUp.UpgradeFoods(zebFoodLevel, "zebra");
        animalFoodUp.UpgradeFoods(kangFoodLevel, "kangaroo");
    }

    void FoodButtonVisibility()
    {
        SettingFoodButtonVisibility(ref pengFoodLevel, pengFoodUp1Button, pengFoodUp2Button, pengFoodUp3Button, "penguin");
        SettingFoodButtonVisibility(ref panFoodLevel, panFoodUp1Button, panFoodUp2Button, panFoodUp3Button, "panda");
        SettingFoodButtonVisibility(ref gorFoodLevel, gorFoodUp1Button, gorFoodUp2Button, gorFoodUp3Button, "gorilla");
        SettingFoodButtonVisibility(ref zebFoodLevel, zebFoodUp1Button, zebFoodUp2Button, zebFoodUp3Button, "zebra");
        SettingFoodButtonVisibility(ref kangFoodLevel, kangFoodUp1Button, kangFoodUp2Button, kangFoodUp3Button, "kangaroo");
    }

    void SettingFoodButtonVisibility(ref int foodLevel, GameObject upgradeButton1, GameObject upgradeButton2, GameObject upgradeButton3, string animal)
    {
         switch(foodLevel)
        {
            case 0:
                upgradeButton1.SetActive(true);
                upgradeButton2.SetActive(false);
                upgradeButton3.SetActive(false);
                break;
            case 1:
                upgradeButton2.SetActive(true);
                upgradeButton3.SetActive(false);
                break;
            case 2:
                upgradeButton3.SetActive(true);
                break;
            case 3:
                upgradeButton1.SetActive(false);
                upgradeButton2.SetActive(false);
                upgradeButton3.SetActive(false);
                break;
        }
    }


	void Upgrade (ref int foodLevel, GameObject upgradeButton, string animal) 
    {
		ClickSound.Play ();
        foodLevel++;
        upgradeButton.SetActive(false);
	}

    public void PenguinUpgrades1()
    {
		ClickSound.Play ();
        Upgrade(ref pengFoodLevel, pengFoodUp1Button, "penguin");
        phase1Solver.ProblemSolver("penguin", 0, true);
    }
    public void PenguinUpgrades2()
    {
		ClickSound.Play ();
        Upgrade(ref pengFoodLevel, pengFoodUp2Button, "penguin");
        phase1Solver.ProblemSolver("penguin", 1, true);
    }

    public void PenguinUpgrades3()
    {
		ClickSound.Play ();
        Upgrade(ref pengFoodLevel, pengFoodUp3Button, "penguin");
        phase1Solver.ProblemSolver("penguin", 2, true);
    }

    public void PandaUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref panFoodLevel, panFoodUp1Button, "panda");
        phase1Solver.ProblemSolver("panda", 3, true);
    }
    public void PandaUpgrade2()
    {
		ClickSound.Play ();
        Upgrade(ref panFoodLevel, panFoodUp2Button, "panda");
        phase1Solver.ProblemSolver("panda", 4, true);
    }
    public void PandaUpgrade3()
    {
		ClickSound.Play ();
        Upgrade(ref panFoodLevel, panFoodUp3Button, "panda");
        phase1Solver.ProblemSolver("panda", 5, true);
    }

    public void GorillaUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref gorFoodLevel, gorFoodUp1Button, "gorilla");
        phase1Solver.ProblemSolver("gorilla", 6, true);
    }
    public void GorillaUpgrade2()
    {
		ClickSound.Play ();
        Upgrade(ref gorFoodLevel, gorFoodUp2Button, "gorilla");
        phase1Solver.ProblemSolver("gorilla", 7, true);
    }
    public void GorillaUpgrade3()
    {
		ClickSound.Play ();
        Upgrade(ref gorFoodLevel, gorFoodUp3Button, "gorilla");
        phase1Solver.ProblemSolver("gorilla", 8, true);
    }

    public void ZebraUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref zebFoodLevel, zebFoodUp1Button, "zebra");
        phase1Solver.ProblemSolver("zebra", 9, true);
    }
    public void ZebraUpgrade2()
    {
        Upgrade(ref zebFoodLevel, zebFoodUp2Button, "zebra");
        phase1Solver.ProblemSolver("zebra", 10, true);
    }
    public void ZebraUpgrade3()
    {
		ClickSound.Play ();
        Upgrade(ref zebFoodLevel, zebFoodUp3Button, "zebra");
        phase1Solver.ProblemSolver("zebra", 11, true);
    }

    public void KangarooUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref kangFoodLevel, kangFoodUp1Button, "kangaroo");
        phase1Solver.ProblemSolver("kangaroo", 12, true);
    }
    public void KangarooUpgrade2()
    {
		ClickSound.Play ();
        Upgrade(ref kangFoodLevel, kangFoodUp2Button, "kangaroo");
        phase1Solver.ProblemSolver("kangaroo", 13, true);
    }
    public void KangarooUpgrade3()
    {
		ClickSound.Play ();
        Upgrade(ref kangFoodLevel, kangFoodUp3Button, "kangaroo");
        phase1Solver.ProblemSolver("kangaroo", 14, true);
    }
}
