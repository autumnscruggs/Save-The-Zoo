using UnityEngine;
using System.Collections;

public class AnimalSocialButton : MonoBehaviour 
{
	[SerializeField] 
	private AudioSource ClickSound;

    private AnimalSocialUpgrade animalSocialUp;
    [SerializeField]
    private Phase1ProblemSolver phase1Solver;

    [SerializeField]
    private GameObject pengSocialUp1Button;
    [SerializeField]
    private GameObject pengSocialUp2Button;
    [SerializeField]
    private GameObject pengSocialUp3Button;

    [SerializeField]
    private GameObject panSocialUp1Button;
    [SerializeField]
    private GameObject panSocialUp2Button;
    [SerializeField]
    private GameObject panSocialUp3Button;

    [SerializeField]
    private GameObject gorSocialUp1Button;
    [SerializeField]
    private GameObject gorSocialUp2Button;
    [SerializeField]
    private GameObject gorSocialUp3Button;

    [SerializeField]
    private GameObject zebSocialUp1Button;
    [SerializeField]
    private GameObject zebSocialUp2Button;
    [SerializeField]
    private GameObject zebSocialUp3Button;

    [SerializeField]
    private GameObject kangSocialUp1Button;
    [SerializeField]
    private GameObject kangSocialUp2Button;
    [SerializeField]
    private GameObject kangSocialUp3Button;

    [HideInInspector]
    public int pengSocialLevel = 0;
    [HideInInspector]
    public int panSocialLevel = 0;
    [HideInInspector]
    public int gorSocialLevel = 0;
    [HideInInspector]
    public int zebSocialLevel = 0;
    [HideInInspector]
    public int kangSocialLevel = 0;

	void Start () 
    {
        animalSocialUp = this.GetComponent<AnimalSocialUpgrade>();
        UpgradeSocial();
    }

    void Update()
    {
        SocialButtonVisibility();
        UpgradeSocial();
    }

    //setting default Socials
    void UpgradeSocial()
    {
        animalSocialUp.SocialUpgrade(pengSocialLevel, "penguin");
        animalSocialUp.SocialUpgrade(panSocialLevel, "panda");
        animalSocialUp.SocialUpgrade(gorSocialLevel, "gorilla");
        animalSocialUp.SocialUpgrade(zebSocialLevel, "zebra");
        animalSocialUp.SocialUpgrade(kangSocialLevel, "kangaroo");
    }


    void SocialButtonVisibility()
    {
        SettingSocialButtonVisibility(ref pengSocialLevel, pengSocialUp1Button, pengSocialUp2Button, pengSocialUp3Button, "penguin");
        SettingSocialButtonVisibility(ref panSocialLevel, panSocialUp1Button, panSocialUp2Button, panSocialUp3Button, "panda");
        SettingSocialButtonVisibility(ref gorSocialLevel, gorSocialUp1Button, gorSocialUp2Button, gorSocialUp3Button, "gorilla");
        SettingSocialButtonVisibility(ref zebSocialLevel, zebSocialUp1Button, zebSocialUp2Button, zebSocialUp3Button, "zebra");
        SettingSocialButtonVisibility(ref kangSocialLevel, kangSocialUp1Button, kangSocialUp2Button, kangSocialUp3Button, "kangaroo");
    }

    void SettingSocialButtonVisibility(ref int SocialLevel, GameObject upgradeButton1, GameObject upgradeButton2, GameObject upgradeButton3, string animal)
    {

        switch (SocialLevel)
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
    void Upgrade (ref int socialLevel, GameObject upgradeButton, string animal) 
    {
		ClickSound.Play ();
        socialLevel++;
        animalSocialUp.SocialUpgrade(socialLevel, animal);
        //print(animal + " social upgrade button " + socialLevel);
        upgradeButton.SetActive(false);
	}

    public void PenguinUpgrades1()
    {
		ClickSound.Play ();
        Upgrade(ref pengSocialLevel, pengSocialUp1Button, "penguin");
        phase1Solver.ProblemSolver("penguin", 22, true);
    }
    public void PenguinUpgrades2()
    {
		ClickSound.Play ();
        Upgrade(ref pengSocialLevel, pengSocialUp2Button, "penguin");
        phase1Solver.ProblemSolver("penguin", 23, true);
    }

    public void PenguinUpgrades3()
    {
		ClickSound.Play ();
        Upgrade(ref pengSocialLevel, pengSocialUp3Button, "penguin");
        phase1Solver.ProblemSolver("penguin", 24, true);
    }


    public void PandaUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref panSocialLevel, panSocialUp1Button, "panda");
        phase1Solver.ProblemSolver("panda", 25, true);
    }
    public void PandaUpgrade2()
    {
		ClickSound.Play ();
        Upgrade(ref panSocialLevel, panSocialUp2Button, "panda");
        phase1Solver.ProblemSolver("panda", 26, true);
    }
    public void PandaUpgrade3()
    {
		ClickSound.Play ();
        Upgrade(ref panSocialLevel, panSocialUp3Button, "panda");
        phase1Solver.ProblemSolver("panda", 27, true);
    }

    public void GorillaUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref gorSocialLevel, gorSocialUp1Button, "gorilla");
        phase1Solver.ProblemSolver("gorilla", 28, true);
    }
    public void GorillaUpgrade2()
    {
		ClickSound.Play ();
        Upgrade(ref gorSocialLevel, gorSocialUp2Button, "gorilla");
        phase1Solver.ProblemSolver("gorilla", 29, true);
    }
    public void GorillaUpgrade3()
    {
		ClickSound.Play ();
        Upgrade(ref gorSocialLevel, gorSocialUp3Button, "gorilla");
        phase1Solver.ProblemSolver("gorilla", 30, true);
    }

    public void ZebraUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref zebSocialLevel, zebSocialUp1Button, "zebra");
        phase1Solver.ProblemSolver("zebra", 31, true);
    }
    public void ZebraUpgrade2()
    {
		ClickSound.Play ();
        Upgrade(ref zebSocialLevel, zebSocialUp2Button, "zebra");
        phase1Solver.ProblemSolver("zebra", 32, true);
    }
    public void ZebraUpgrade3()
    {
		ClickSound.Play ();
        Upgrade(ref zebSocialLevel, zebSocialUp3Button, "zebra");
        phase1Solver.ProblemSolver("zebra", 33, true);
    }

    public void KangarooUpgrade1()
    {
		ClickSound.Play ();
        Upgrade(ref kangSocialLevel, kangSocialUp1Button, "kangaroo");
        phase1Solver.ProblemSolver("kangaroo", 34, true);
    }
    public void KangarooUpgrade2()
    {
		ClickSound.Play ();
        Upgrade(ref kangSocialLevel, kangSocialUp2Button, "kangaroo");
        phase1Solver.ProblemSolver("kangaroo", 35, true);
    }
    public void KangarooUpgrade3()
    {
		ClickSound.Play ();
        Upgrade(ref kangSocialLevel, kangSocialUp3Button, "kangaroo");
        phase1Solver.ProblemSolver("kangaroo", 36, true);
    }
}
