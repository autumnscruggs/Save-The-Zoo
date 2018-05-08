using UnityEngine;
using System.Collections;

public class AnimalHabitatButtons : MonoBehaviour 
{
	[SerializeField] 
	private AudioSource ClickSound;

    private AnimalHabitatUpgrade animalHabUp;
    [SerializeField]
    private Phase1ProblemSolver phase1Solver;

    [SerializeField] private GameObject pengHabUp1Button;
    [SerializeField] private GameObject pengHabUp2Button;
    [SerializeField] private GameObject panHabUp1Button;
    [SerializeField] private GameObject panHabUp2Button;
    [SerializeField] private GameObject gorHabUp1Button;
    [SerializeField] private GameObject zebHabUp1Button;
    [SerializeField] private GameObject kangHabUp1Button;

    [HideInInspector]
    public int pengHabLevel = 0;
    [HideInInspector]
    public int panHabLevel = 0;
    [HideInInspector]
    public int gorHabLevel = 0;
    [HideInInspector]
    public int zebHabLevel = 0;
    [HideInInspector]
    public int kangHabLevel = 0;


    void Start()
    {
        animalHabUp = this.GetComponent<AnimalHabitatUpgrade>();
        UpgradeHabitats();
    }

    void Update()
    {
        HabitatButtonVisibility();
        UpgradeHabitats();
    }

    void HabitatButtonVisibility()
    {
        SettingHabitaButtonVisibility(ref pengHabLevel, pengHabUp1Button, pengHabUp2Button, "penguin");
        SettingHabitaButtonVisibility(ref panHabLevel, panHabUp1Button, panHabUp2Button, "panda");
        SettingHabitaButtonVisibility(ref gorHabLevel, gorHabUp1Button, gorHabUp1Button, "gorilla");
        SettingHabitaButtonVisibility(ref zebHabLevel, zebHabUp1Button, zebHabUp1Button, "zebra");
        SettingHabitaButtonVisibility(ref kangHabLevel, kangHabUp1Button, kangHabUp1Button, "kangaroo");
    }

    void SettingHabitaButtonVisibility(ref int HabLevel, GameObject upgradeButton1, GameObject upgradeButton2, string animal)
    {
        if(animal == "penguin" || animal == "panda")
        {
            switch (HabLevel)
            {
                case 0:
                    upgradeButton1.SetActive(true);
                    upgradeButton2.SetActive(false);
                    break;
                case 1:
                    upgradeButton2.SetActive(true);
                    break;
                case 2:
                    upgradeButton1.SetActive(false);
                    upgradeButton2.SetActive(false);
                    break;
            }
        }
        
    }

    //setting default habitat text
    void UpgradeHabitats()
    {
        animalHabUp.UpgradeHabitats(pengHabLevel, "penguin");
        animalHabUp.UpgradeHabitats(panHabLevel, "panda");
        animalHabUp.UpgradeHabitats(gorHabLevel, "gorilla");
        animalHabUp.UpgradeHabitats(zebHabLevel, "zebra");
        animalHabUp.UpgradeHabitats(kangHabLevel, "kangaroo");
    }

    void Upgrade(ref int habLevel, GameObject upgradeButton, string animal)
    {
        habLevel++;
        upgradeButton.SetActive(false);
    }


    /*------BUTTON SCRIPTS-----*/

    public void PenguinUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref pengHabLevel, pengHabUp1Button, "penguin");
        phase1Solver.ProblemSolver("penguin", 15, true);
    }

    public void PenguinUpgrade2()
    {
		ClickSound.Play ();
        Upgrade(ref pengHabLevel, pengHabUp2Button, "penguin");
        phase1Solver.ProblemSolver("penguin", 16, true);
    }

    public void PandaUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref panHabLevel, panHabUp1Button, "panda");
        phase1Solver.ProblemSolver("panda", 17, true);
    }

    public void PandaUpgrade2()
    {
		ClickSound.Play ();
        Upgrade(ref panHabLevel, panHabUp2Button, "panda");
        phase1Solver.ProblemSolver("panda", 18, true);
    }

    public void GorillaUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref gorHabLevel, gorHabUp1Button, "gorilla");
        phase1Solver.ProblemSolver("gorilla", 19, true);
    }

    public void ZebraUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref zebHabLevel, zebHabUp1Button, "zebra");
        phase1Solver.ProblemSolver("zebra", 20, true);
    }

    public void KangarooUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref kangHabLevel, kangHabUp1Button, "kangaroo");
        phase1Solver.ProblemSolver("kangaroo", 21, true);
    }
}
