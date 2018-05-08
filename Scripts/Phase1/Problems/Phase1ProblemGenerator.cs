using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Phase1ProblemGenerator : MonoBehaviour {

    [SerializeField]
    private AnimalFoodButton animalFood;
    [SerializeField]
    private AnimalSocialButton animalSocial;
    [SerializeField]
    private AnimalHabitatButtons animalHab;

    private ProblemDisplay problemDisplay;

    private GameObject happyManager;
    private PenguinHappiness penguHappy;
    private PandaHappiness panHappy;
    private GorillaHappiness gorHappy;
    private ZebrasHappiness zebHappy;
    private KangarooHappiness kangHappy;

    public List<string> ProblemsList = new List<string>();
    private List<string> ProblemsToGenFrom = new List<string>();
    [HideInInspector]
    public List<string> DisplayedProblemsList = new List<string>();
    //[SerializeField]
    private List<string> ProblemsStillInPlay = new List<string>();
    [HideInInspector]
    public List<string> CompletedProblemList = new List<string>();
    [SerializeField]
    private List<Text> objectiveHolders;
    [SerializeField]
    private List<GameObject> objectiveParents;

    private int numberofProblemsInList;
    private int problemAmount = 0;
    private int problemsToCreate = 0;

    private int maxNumberOfProblemsAtOnce = 4;
    private string problem = null;

    // Use this for initialization
    void Start()
    {
        //getting reference to scripts
        happyManager = GameObject.Find("HappinessManager");
        penguHappy = happyManager.GetComponent<PenguinHappiness>();
        panHappy = happyManager.GetComponent<PandaHappiness>();
        gorHappy = happyManager.GetComponent<GorillaHappiness>();
        zebHappy = happyManager.GetComponent<ZebrasHappiness>();
        kangHappy = happyManager.GetComponent<KangarooHappiness>();
        problemDisplay = this.GetComponent<ProblemDisplay>();
        //hiding objectives initially
        HideAllObjectives();
        //counting the number of problems in the list
        numberofProblemsInList = ProblemsList.Count + 1;
        //do the things that set up the generator
        SetUpGenerator();
    }

    void Update()
    {
        //if it's time for the first day to reset, 
        //set up the generator again
        if (NewDayManager.FirstDayReset)
        {
            SetUpGenerator();
        }

        CompleteProblem();
    }

    void DisplayDeductionScreen()
    {
        if (ProblemsStillInPlay.Count != 0)
        { problemDisplay.ShowProblemDeductionDisplay(true); }
        else
        {  problemDisplay.ShowProblemDeductionDisplay(false); }

    }

    void SetUpGenerator()
    {
        //remove the problems that have been complete
        RemoveCompletedProblems();
        //punish the player for the problems still in play
        ProblemPunishment();
        //show player what's going on if needed
        DisplayDeductionScreen();
        //checking which problems to gen from
        OnlyGenFromCertainProblems();
        //getting the amount of problems
        GetRandomNumberofProblems();
        //adding the problems that are still in play to the list
        AddProblemsInPlay();
        //finding the number of problems to gen
        FindingNumberOfProblemsToCreate();
        //populate the list/gen the problems
        PopulateLists(problemAmount);
        //display the objectives
        DisplayObjectives();
        //stop the first day reset
        NewDayManager.FirstDayReset = false;
        //then clear problems in play list
        ProblemsStillInPlay.Clear();
    }

    void FindingNumberOfProblemsToCreate()
    {
        if (DisplayedProblemsList.Count != 0)
        { problemsToCreate = DisplayedProblemsList.Count - problemAmount; }
        else
        { problemsToCreate = problemAmount; }

       // print("displayed problems " + DisplayedProblemsList.Count);
        //print("problems to create " + problemsToCreate);

        if(problemsToCreate > maxNumberOfProblemsAtOnce)
            { problemsToCreate = maxNumberOfProblemsAtOnce; }
        if (problemsToCreate < 0)
        { problemsToCreate = 0; }
    }


    void ProblemPunishment()
    {
        foreach (string unsolvedProblem in ProblemsStillInPlay)
        {
            //find it in the problems list and send that index into the 
            //deduct happiness method
            if (ProblemsList.Contains(unsolvedProblem))
            {
                int index = ProblemsList.IndexOf(unsolvedProblem);
                DeductHappinessForProblemsInPlay(index);
            }
        }

    }

    void AddProblemsInPlay()
    {
        foreach (string unsolvedProblem in ProblemsStillInPlay)
        {
            //if it's NOT in the displayed list, put it there
            if (!DisplayedProblemsList.Contains(unsolvedProblem))
            { DisplayedProblemsList.Add(unsolvedProblem); }
        }

        //then clear this list
        ProblemsStillInPlay.Clear();
    }


    void PopulateLists(int problemAmount)
    {
        //while x is less than the problem amount
        for (int x = 0; x < problemsToCreate; x++)
        {
            if(CompletedProblemList.Count != 37)
            {
                //generate random problem
                problem = ProblemsToGenFrom[Random.Range(0, ProblemsToGenFrom.Count)];

                //if the completed problem list nor the displayed problems list contains the problem
                //add it to the displayed problems list
                 if (!CompletedProblemList.Contains(problem) && !DisplayedProblemsList.Contains(problem))
                 { DisplayedProblemsList.Add(problem); }
           }

        }
    }

    void DisplayObjectives()
    {

        foreach (Text objective in objectiveHolders)
        {
            objective.transform.FindChild("StrikeOut").gameObject.SetActive(false);
        }

        //set the text for the objective text boxes as the displayed problem ones
        for (int z = 0; z < DisplayedProblemsList.Count; z++)
        {
            objectiveHolders[z].text = DisplayedProblemsList[z];
        }

        //show the block holding the objective and number for each displayed problem
        for (int y = 0; y < DisplayedProblemsList.Count; y++)
        {
            objectiveParents[y].SetActive(true);
        }
    }


    void RemoveCompletedProblems()
    {
        for (int x = 0; x < DisplayedProblemsList.Count; x++)
        {
            if (!CompletedProblemList.Contains(DisplayedProblemsList[x]))
            {
                ProblemsStillInPlay.Add(DisplayedProblemsList[x]);
            }
        }

       ClearDisplaylist();
       ProblemsToGenFrom.Clear();
    }

    void ClearDisplaylist()
    {
        for (int z = 0; z < objectiveHolders.Count; z++)
        {
            objectiveHolders[z].text = "";
            objectiveParents[z].SetActive(false);
        }

        DisplayedProblemsList.Clear();
    }

    void CompleteProblem()
    {
        foreach (string problem in DisplayedProblemsList)
        {
            if (CompletedProblemList.Contains(problem))
            {
                objectiveHolders[DisplayedProblemsList.IndexOf(problem)].transform.FindChild("StrikeOut").gameObject.SetActive(true);
            }
        }
    }


    public void GetRandomNumberofProblems()
    {
        problemAmount = Random.Range(1, numberofProblemsInList);
    }


    //hide all objective blocks
    void HideAllObjectives()
    {
        foreach(GameObject parent in objectiveParents)
        {
            parent.SetActive(false);
        }
    }

    //this prevents the player from getting a problem
    //when the upgrade isn't unlocked
    void OnlyGenFromCertainProblems()
    {
        switch (animalFood.pengFoodLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[0]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[1]);
                break;
            case 2:
                ProblemsToGenFrom.Add(ProblemsList[2]);
                break;
        }

        switch (animalFood.panFoodLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[3]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[4]);
                break;
            case 2:
                ProblemsToGenFrom.Add(ProblemsList[5]);
                break;
        }

        switch (animalFood.gorFoodLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[6]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[7]);
                break;
            case 2:
                ProblemsToGenFrom.Add(ProblemsList[8]);
                break;
        }

        switch (animalFood.zebFoodLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[9]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[10]);
                break;
            case 2:
                ProblemsToGenFrom.Add(ProblemsList[11]);
                break;
        }

        switch (animalFood.kangFoodLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[12]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[13]);
                break;
            case 2:
                ProblemsToGenFrom.Add(ProblemsList[14]);
                break;
        }

        switch (animalHab.pengHabLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[15]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[16]);
                break;
        }

        switch (animalHab.panHabLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[17]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[18]);
                break;
        }

        switch (animalHab.gorHabLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[19]);
                break;
        }

        switch (animalHab.zebHabLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[20]);
                break;
        }

        switch (animalHab.kangHabLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[21]);
                break;
        }

        switch (animalSocial.pengSocialLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[22]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[23]);
                break;
            case 2:
                ProblemsToGenFrom.Add(ProblemsList[24]);
                break;
        }

        switch (animalSocial.panSocialLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[25]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[26]);
                break;
            case 2:
                ProblemsToGenFrom.Add(ProblemsList[27]);
                break;
        }

        switch (animalSocial.gorSocialLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[28]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[29]);
                break;
            case 2:
                ProblemsToGenFrom.Add(ProblemsList[30]);
                break;
        }

        switch (animalSocial.zebSocialLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[31]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[32]);
                break;
            case 2:
                ProblemsToGenFrom.Add(ProblemsList[33]);
                break;
        }

        switch (animalSocial.kangSocialLevel)
        {
            case 0:
                ProblemsToGenFrom.Add(ProblemsList[34]);
                break;
            case 1:
                ProblemsToGenFrom.Add(ProblemsList[35]);
                break;
            case 2:
                ProblemsToGenFrom.Add(ProblemsList[36]);
                break;
        }

    }

    //depending on the problem, deduct happiness if it's still in play
    void DeductHappinessForProblemsInPlay(int index)
    {
        if (index <= 0 && index <= 2)
        {
            penguHappy.foodHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Penguin's food happiness \n\n";
        }
        else if (index >= 3 && index <= 5)
        {
            panHappy.foodHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Panda's food happiness \n\n";
        }
        else if (index >= 6 && index <= 8)
        {
            gorHappy.foodHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Gorilla's food happiness \n\n";
        }
        else if (index >= 9 && index <= 11)
        {
            zebHappy.foodHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Zebra's food happiness \n\n";
        }
        else if (index >= 12 && index <= 14)
        {
            kangHappy.foodHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Kangaroo's food happiness \n\n";
        }
        else if (index >= 15 && index <= 16)
        {
            penguHappy.maintHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Penguin's maintenance happiness \n\n";
        }
        else if (index >= 17 && index <= 18)
        {
            panHappy.maintHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Panda's maintenance happiness \n\n";
        }
        else if (index == 19)
        {
            gorHappy.maintHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Gorilla's maintenance happiness \n\n";
        }
        else if (index == 20)
        {
            zebHappy.maintHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Zebra's maintenance happiness \n\n";
        }
        else if (index == 21)
        {
            kangHappy.maintHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Kangaroo's maintenance happiness \n\n";
        }
        else if (index >= 22 && index <= 24)
        {
            penguHappy.socialHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Penguin's amusement happiness \n\n";
        }
        else if (index >= 25 && index <= 27)
        {
            panHappy.socialHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Panda's amusement happiness \n\n";
        }
        else if (index >= 28 && index <= 30)
        {
            gorHappy.socialHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Gorilla's amusement happiness \n\n";
        }
        else if (index >= 31 && index <= 33)
        {
            zebHappy.socialHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Zebra's amusement happiness \n\n";
        }
        else if (index >= 34 && index <= 36)
        {
            kangHappy.socialHappiness -= 5;
            problemDisplay.deductionDescription.text += "-5% from the Kangaroo's amusement happiness \n\n";
        }
    }

}
