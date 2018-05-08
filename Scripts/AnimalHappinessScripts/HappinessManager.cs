using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HappinessManager : MonoBehaviour {

    private PandaHappiness panHappy;
    private PenguinHappiness pengHappy;
    private GorillaHappiness gorHappy;
    private ZebrasHappiness zebHappy;
    private KangarooHappiness kanHappy;

    [SerializeField]
    private Text happinessLevel;

    private float overallHappiness = 100;
    public float OverallHappiness { get { return overallHappiness; } }

    private float penguinOverallSum;
    private float penguinRatio = 0.25f;

    private float pandaOverallSum;
    private float pandaRatio = 0.25f;

    private float gorillaOverallSum;
    private float gorillaRatio = 0.18f;

    private float zebraOverallSum;
    private float zebraRatio = 0.17f;

    private float kangarooOverallSum;
    private float kangarooRatio = 0.15f;

    private bool sumsFound = false;

	// Use this for initialization
	void Start () 
    {
        //getting references to the happiness scripts
        pengHappy = this.GetComponent<PenguinHappiness>();
        panHappy = this.GetComponent<PandaHappiness>();
        gorHappy = this.GetComponent<GorillaHappiness>();
        zebHappy = this.GetComponent<ZebrasHappiness>();
        kanHappy = this.GetComponent<KangarooHappiness>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        DisplayMainMenuHappinessText();
        DisplaySubMenuHappinessText();
        UpdateHappinessLevel();
        FindingHappinessSums();
        OverallHappinessLevel();
      
    }


    void UpdateHappinessLevel()
    {
        happinessLevel.text = "" + overallHappiness + "%";
    }

    void FindingHappinessSums()
    {
        //based on the ratio, multiply that with the total per animal
        //this allows each animal to contribute to the overall happiness differently
        penguinOverallSum = pengHappy.PenguinHappinessTotal * penguinRatio;

        pandaOverallSum = panHappy.PandaHappinessTotal * pandaRatio;

        gorillaOverallSum = gorHappy.GorillaHappinessTotal * gorillaRatio;

        zebraOverallSum = zebHappy.ZebraHappinessTotal * zebraRatio;

        kangarooOverallSum = kanHappy.KangarooHappinessTotal * kangarooRatio;

    }

    void OverallHappinessLevel()
    {
        //adding all the sums up
        overallHappiness = penguinOverallSum + pandaOverallSum + gorillaOverallSum + zebraOverallSum + kangarooOverallSum;
    }

    /*-------------DISPLAY METHODS--------------*/

    void DisplayMainMenuHappinessText()
    {
        //displays the happiness sums in the main menu
        DisplayHappinessSums(penguinOverallSum, pengHappy.mainMenuHappinessText);
        DisplayHappinessSums(pandaOverallSum, panHappy.mainMenuHappinessText);
        DisplayHappinessSums(gorillaOverallSum, gorHappy.mainMenuHappinessText);
        DisplayHappinessSums(zebraOverallSum, zebHappy.mainMenuHappinessText);
        DisplayHappinessSums(kangarooOverallSum, kanHappy.mainMenuHappinessText);
    }

    void DisplaySubMenuHappinessText()
    {
        //displays the happiness totals in the sub menu
        //penguin display
        DisplaySubMenuHappinessTotals(pengHappy.PenguinHappinessTotal, pengHappy.foodHappiness, pengHappy.maintHappiness, pengHappy.socialHappiness,
            pengHappy.subMenuHappyTotalText, pengHappy.subMenuHappyDescription);
        //panda display
        DisplaySubMenuHappinessTotals(panHappy.PandaHappinessTotal, panHappy.foodHappiness, panHappy.maintHappiness, panHappy.socialHappiness,
            panHappy.subMenuHappyTotalText, panHappy.subMenuHappyDescription);
        //gorilla display
        DisplaySubMenuHappinessTotals(gorHappy.GorillaHappinessTotal, gorHappy.foodHappiness, gorHappy.maintHappiness, gorHappy.socialHappiness,
            gorHappy.subMenuHappyTotalText, gorHappy.subMenuHappyDescription);
        //zebra display
        DisplaySubMenuHappinessTotals(zebHappy.ZebraHappinessTotal, zebHappy.foodHappiness, zebHappy.maintHappiness, zebHappy.socialHappiness,
            zebHappy.subMenuHappyTotalText, zebHappy.subMenuHappyDescription);
        //kangaroo display
        DisplaySubMenuHappinessTotals(kanHappy.KangarooHappinessTotal, kanHappy.foodHappiness, kanHappy.maintHappiness, kanHappy.socialHappiness,
        kanHappy.subMenuHappyTotalText, kanHappy.subMenuHappyDescription);
    }

    /*---------------GENERIC DISPLAY METHODS------------------*/

    void DisplayHappinessSums(float animalSum, Text animalHappinessText)
    {
        animalHappinessText.text = "+ " + animalSum + "% happiness";
    }

    void DisplaySubMenuHappinessTotals(float happyTotal, float foodTotal, float maintTotal, float socialTotal,
        Text subMenuHappinessText, Text subMenuHappinessDescription)
    {
        subMenuHappinessText.text = "+ " + happyTotal + "%";
        subMenuHappinessDescription.text =
            "+ " + foodTotal + "% = Feed"
            + "\n+ " + maintTotal + "% = Maintenance"
            + "\n+ " + socialTotal + "% = Socialization";
    }

}
