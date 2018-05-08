using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PandaHappiness : MonoBehaviour {

    private AnimalHappiness animalHap;
    private AnimalFoodButton animalFoodButton;
    private AnimalSocialButton animalSocialButton;
    private AnimalHabitatButtons animalHabButton;

    [HideInInspector]
    public int PandaHappinessTotal;

    public Text mainMenuHappinessText;

    public int foodWorth = 55;
    public int maintenanceWorth = 35;
    public int socialWorth = 10;

    public Image mainMenuTotalStars;
    public Image subMenuTotalStars;
    public Image phase2TotalStars;

    public Image mainFoodImage;
    public Image subFoodImage;
    public Image mainMaintImage;
    public Image subMaintImage;
    public Image mainSocialImage;
    public Image subSocialImage;

    public Text subMenuHappyTotalText;
    public Text subMenuHappyDescription;

    [HideInInspector]
    public int foodHappiness;
    [HideInInspector]
    public int maintHappiness;
    [HideInInspector]
    public int socialHappiness;

    private float foodRatio;
    private float maintRatio;
    private float socialRatio;

    private float subFoodHappy;
    private float subMaintHappy;
    private float subSocialHappy;

    private bool foodUpgrade1 = false;
    private bool foodUpgrade2 = false;
    private bool foodUpgrade3 = false;

    private bool maintUpgrade1 = false;
    private bool maintUpgrade2 = false;

    private bool socialUpgrade1 = false;
    private bool socialUpgrade2 = false;
    private bool socialUpgrade3 = false;

    void Start()
    {
        //default happiness numbers
        foodHappiness = 35;
        maintHappiness = 20;
        socialHappiness = 5;
        //get animal happiness reference
        animalHap = this.GetComponent<AnimalHappiness>();
        animalFoodButton = GameObject.Find("FoodUpgradeMaster").GetComponent<AnimalFoodButton>();
        animalSocialButton = GameObject.Find("PopulationUpgradeMaster").GetComponent<AnimalSocialButton>();
        animalHabButton = GameObject.Find("HabitatUpgradeMaster").GetComponent<AnimalHabitatButtons>();
    }

    // Update is called once per frame
    void Update()
    {

        TotalAnimalHappiness();
        animalHap.DisplayMainAnimalHappiness(PandaHappinessTotal, mainMenuTotalStars, subMenuTotalStars, phase2TotalStars);
    }


    /*---STAT METHOD---*/

    void FoodLevel()
    {
        TotalFoodHappiness();
        animalHap.DisplayStatHappiness(subFoodHappy, mainFoodImage, subFoodImage);
    }

    void MaintenanceLevel()
    {
        TotalMaintHappiness();
        animalHap.DisplayStatHappiness(subMaintHappy, mainMaintImage, subMaintImage);
    }

    void SocialLevel()
    {
        TotalSocialHappiness();
        animalHap.DisplayStatHappiness(subSocialHappy, mainSocialImage, subSocialImage);
    }



    /*---TOTALLING NUMBERS---*/

    void TotalAnimalHappiness()
    {
        //calculating each animal's level
        FoodLevel();
        MaintenanceLevel();
        SocialLevel();
        //calculating total happy
        PandaHappinessTotal = foodHappiness + maintHappiness + socialHappiness;
    }

    void CalculateStatDisplayRatio(float ratio, float worth, ref float subHappy, float happiness)
    {
        ratio = 100 / worth;
        subHappy = happiness * ratio;
    }

    void TotalFoodHappiness()
    {
        switch (animalFoodButton.panFoodLevel)
        {
            case 0:
                foodHappiness += 0;
                break;
            case 1:
                if (!foodUpgrade1)
                {
                    foodHappiness += 9;
                    foodUpgrade1 = true;
                }
                break;
            case 2:
                if (!foodUpgrade2)
                {
                    foodHappiness += 6;
                    foodUpgrade2 = true;
                }
                break;
            case 3:
                if (!foodUpgrade3)
                {
                    foodHappiness += 5;
                    foodUpgrade3 = true;
                }
                break;
        }

        if (foodHappiness > foodWorth)
        { foodHappiness = foodWorth; }

        CalculateStatDisplayRatio(foodRatio, foodWorth, ref subFoodHappy, foodHappiness);
    }

    void TotalMaintHappiness()
    {
        switch (animalHabButton.panHabLevel)
        {
            case 0:
                maintHappiness += 0;
                break;
            case 1:
                if (!maintUpgrade1)
                {
                    maintHappiness += 10;
                    maintUpgrade1 = true;
                }
                break;
            case 2:
                if (!maintUpgrade2)
                {
                    maintHappiness += 5;
                    maintUpgrade2 = true;
                }
                break;
        }

        if (maintHappiness > maintenanceWorth)
        { maintHappiness = maintenanceWorth; }

        CalculateStatDisplayRatio(maintRatio, maintenanceWorth, ref subMaintHappy, maintHappiness);
    }

    void TotalSocialHappiness()
    {
        switch (animalSocialButton.panSocialLevel)
        {
            case 0:
                socialHappiness += 0;
                break;
            case 1:
                if (!socialUpgrade1)
                {
                    socialHappiness += 2;
                    socialUpgrade1 = true;
                }
                break;
            case 2:
                if (!socialUpgrade2)
                {
                    socialHappiness += 2;
                    socialUpgrade2 = true;
                }
                break;
            case 3:
                if (!socialUpgrade3)
                {
                    socialHappiness += 1;
                    socialUpgrade3 = true;
                }
                break;
        }

        if (socialHappiness > socialWorth)
        { socialHappiness = socialWorth; }

        CalculateStatDisplayRatio(socialRatio, socialWorth, ref subSocialHappy, socialHappiness);

    }
}
