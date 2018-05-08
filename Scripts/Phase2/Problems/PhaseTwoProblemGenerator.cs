using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PhaseTwoProblemGenerator : MonoBehaviour
{
    #region Script References
    [SerializeField]
    private DayCycleManager dayCycle;
    [SerializeField]
    private PhaseTwoProblemSolver phase2Solver;
    [SerializeField]
    private NotificationsDisplay notiDisplay;
    #endregion

    public float WaittimefornextProblem = 30f;
    private float WaitTime = 0f;

    #region Lists
    [SerializeField]
    private List<Text> PhaseTwoProblemHolders;
    [SerializeField]
    public List<string> Phase2Problems;
    [HideInInspector]
    public List<string> DisplayedPhaseTwoProblemsList = new List<string>();
    [HideInInspector]
    public List<string> CompletedPhaseTwoProblemsList = new List<string>();
    [SerializeField]
    private List<GameObject> Borders = new List<GameObject>();
    #endregion

    private int problemGenerationDecider;
    private bool decideIfProblemsCanGenerate = false;
    private float decisionTimer = 20f;
    private float decisionTimerCountdown;

    [HideInInspector]
    public int ProblemIDNumber;

    private int problemAmount;
    private int PhaseTwoProblemsAmount;
    private int howManyProblemsAtOneTime = 2;

    private bool problemsCanGenerate = true;

    #region Timer Bar Stuff
    [SerializeField]
    private Image timerBar;
    [SerializeField]
    private Color greenTimer;
    [SerializeField]
    private Color yellowTimer;
    [SerializeField]
    private Color badTimer;
    #endregion

    #region Happiness Management References
    private GameObject happyManager;
    private PenguinHappiness penguHappy;
    private PandaHappiness panHappy;
    private GorillaHappiness gorHappy;
    private ZebrasHappiness zebHappy;
    private KangarooHappiness kangHappy;
    #endregion

    #region Janitor Spawn Stuff
    private JanitorEmblemSpawn janiSpawn;
    public List<string> JanitorProblems = new List<string>();
    #endregion


    private int loopTime = 0;

    void Start()
    {
        //how many times the for loop will go through in the generate function
        //this is a complicated fix for it but it works
        WaitTime = WaittimefornextProblem / 1.5f;
        //gets number for timer and sets the problems amount
        decisionTimerCountdown = decisionTimer;
        PhaseTwoProblemsAmount = Phase2Problems.Count + 1;
        //get reference to janitor script
        janiSpawn = this.GetComponent<JanitorEmblemSpawn>();
        //put the right problems in the janitor problems list
        PopulateJanitorProblemList();
    }

	void Update () 
	{
        //remove problem from play if it is solved
        RemoveProblemFromPlayIfSolved();

        //if the second day needs to be reset, set up the generator
        if (NewDayManager.SecondDayReset)
        {  SetUpGenerator(); }

        //decide if problems can occur
        //DecideIfProblemsOccur();

        //check to see if the janitor emblem needs to be spawned
        SpawnJanitor();

        //if problems can generate at any time, do that
        if (problemsCanGenerate)
        {  
            StartCoroutine("GenerateProblem");
        }
        
        //if time is up, erase everything
        if(dayCycle.Phase2TimeLeft == 0)
        {
            HideBorders();
            EraseDisplayedProblemsList();
            EraseCompletedProblemsList();
        }

    }

   void PopulateJanitorProblemList()
    {
        JanitorProblems.Add(Phase2Problems[40]);
        JanitorProblems.Add(Phase2Problems[41]);
        JanitorProblems.Add(Phase2Problems[42]);
        JanitorProblems.Add(Phase2Problems[43]);
    }

    void SpawnJanitor()
    {
        foreach(string problem in DisplayedPhaseTwoProblemsList)
        {
            if (JanitorProblems.Contains(problem))
            {
                janiSpawn.JanitorProblem = true;
            }
        }
    }

    void SetUpGenerator()
    {
        //prevent second day from resetting until next day
        NewDayManager.SecondDayReset = false;
    }


    void GenerateProblemID()
    {
        ProblemIDNumber = Random.Range(1, Phase2Problems.Count);
        ProblemIDNumber -= 1;
    }


    IEnumerator GenerateProblem()
	{
        problemsCanGenerate = false;

        for (int x = 0; x <= howManyProblemsAtOneTime; x++)
        {
            //this prevents more than 3 problems from being displayed at once
            if (DisplayedPhaseTwoProblemsList.Count == 3)
            { break; }

            //this allows it to generate stuff that's not duplicating
            while (true)
            {
                GenerateProblemID();

                if (!CompletedPhaseTwoProblemsList.Contains(Phase2Problems[ProblemIDNumber])
                     && !DisplayedPhaseTwoProblemsList.Contains(Phase2Problems[ProblemIDNumber]))
                {
                    DisplayedPhaseTwoProblemsList.Add(Phase2Problems[ProblemIDNumber]);
                    break;
                }
            }

         }

        SetBorders();
        FillPhaseTwoProblemUi();


        for (float x = WaitTime; x > 0; x-- )
        {
            //make the timer bar do the thing
            timerBar.fillAmount = (x / WaitTime);

            #region Timer bar color changing
            if (timerBar.fillAmount > 0.75)
            {
                timerBar.color = greenTimer;
            }
            else if (timerBar.fillAmount < 0.75 && timerBar.fillAmount > 0.45)
            {
                timerBar.color = yellowTimer;
            }
            else
            {
                timerBar.color = badTimer;
            }
            #endregion

            x += 0.99f;

            yield return new WaitForSeconds(0.01f);
        }

            HideBorders();
            CheckProblemSolver();
            EraseDisplayedProblemsList();
	}

    void ResetTimerBar()
    {
        timerBar.fillAmount = 1;
        timerBar.gameObject.SetActive(true);
    }

    void RemoveProblemFromPlayIfSolved()
    {
       foreach (string problem in CompletedPhaseTwoProblemsList)
       {
            if (DisplayedPhaseTwoProblemsList.Contains(problem))
            {
                DisplayedPhaseTwoProblemsList.Remove(problem);
                EraseProblemText();
                HideBorders();
                FillPhaseTwoProblemUi();
                SetBorders();
            }

            if (JanitorProblems.Contains(problem))
            {
                janiSpawn.HideJanitor();
            }
        }
    }

    void RemoveProblemFromPlayIfNotSolved()
    {
        foreach (string problem in DisplayedPhaseTwoProblemsList)
        {
            if (!CompletedPhaseTwoProblemsList.Contains(problem))
            {
                DisplayedPhaseTwoProblemsList.Remove(problem);
                EraseProblemText();
                HideBorders();
                FillPhaseTwoProblemUi();
                SetBorders();
            }
        }
    }

    void DecideIfProblemsOccur()
    {
        //decide whether or not the problem can generate
        if (DisplayedPhaseTwoProblemsList.Count == 0)
        {
            problemsCanGenerate = true;
            return;
        }

        //after x amount of time, it will decide whether or not to gen more problems
        decisionTimer -= Time.deltaTime;
        //Debug.Log("Decision Timer: " + decisionTimer);

        if (decisionTimer <= 0)
        {
            problemGenerationDecider = Random.Range(1, 5);

            if (problemGenerationDecider == 1 || problemGenerationDecider == 3)
            {
                decisionTimer = decisionTimerCountdown;
                problemsCanGenerate = true;
            }
            else
            {
                decisionTimer = decisionTimerCountdown;
                problemsCanGenerate = false;
            }
        }
        else
        {
            problemsCanGenerate = false;
        }
    }

    void FillPhaseTwoProblemUi()
    {
        for (int y = 0; y < DisplayedPhaseTwoProblemsList.Count; y++)
        {
            PhaseTwoProblemHolders[y].text = DisplayedPhaseTwoProblemsList[y];
        }
    }


    void EraseDisplayedProblemsList()
    {
        janiSpawn.HideJanitor();
        DisplayedPhaseTwoProblemsList.Clear();
        EraseProblemText();
        ResetTimerBar();
        problemsCanGenerate = true;
    }

    void EraseProblemText()
    {
        foreach (Text PhaseTwoProblem in PhaseTwoProblemHolders)
        {
            PhaseTwoProblem.text = "";
        }
    }

    void EraseCompletedProblemsList()
    {
        CompletedPhaseTwoProblemsList.Clear();
    }

    void CheckProblemSolver()
    {
        foreach (string problem in DisplayedPhaseTwoProblemsList)
        {
            int index = DisplayedPhaseTwoProblemsList.IndexOf(problem);

            if (!CompletedPhaseTwoProblemsList.Contains(problem))
            {
                if (index >= 0 && index <= 3)//ZooKeeper Problems start
                {
                    phase2Solver.Phase2KeeperProblemExpired("penguin");
                    notiDisplay.NewNotification("penguin", "maintenance", "-");
                }
                else if (index >= 8 && index <= 11)
                {
                    phase2Solver.Phase2KeeperProblemExpired("panda");
                    notiDisplay.NewNotification("panda", "maintenance", "-");
                }
                else if (index >= 16 && index <= 19)
                {
                    phase2Solver.Phase2KeeperProblemExpired("gorilla");
                    notiDisplay.NewNotification("gorilla", "maintenance", "-");
                }
                else if (index >= 24 && index <= 27)
                {
                    phase2Solver.Phase2KeeperProblemExpired("zebra");
                    notiDisplay.NewNotification("zebra", "maintenance", "-");
                }
                else if (index >= 32 && index <= 35)
                {
                    phase2Solver.Phase2KeeperProblemExpired("kangaroo");
                    notiDisplay.NewNotification("kangaroo", "maintenance", "-");
                }
                else if (index >= 4 && index <= 7)//Vet problems start
                {
                    phase2Solver.Phase2VetProblemsExpired("penguin");
                    notiDisplay.NewNotification("penguin", "amusement", "-");
                }
                else if (index >= 12 && index <= 15)
                {
                    phase2Solver.Phase2VetProblemsExpired("panda");
                    notiDisplay.NewNotification("panda", "amusement", "-");
                }
                else if (index >= 20 && index <= 23)
                {
                    phase2Solver.Phase2VetProblemsExpired("gorilla");
                    notiDisplay.NewNotification("gorilla", "amusement", "-");
                }
                else if (index >= 28 && index <= 31)
                {
                    phase2Solver.Phase2VetProblemsExpired("zebra");
                    notiDisplay.NewNotification("zebra", "amusement", "-");
                }
                else if (index >= 36 && index <= 39)
                {
                    phase2Solver.Phase2VetProblemsExpired("kangaroo");
                    notiDisplay.NewNotification("kangaroo", "amusement", "-");
                }

            }

        }

    }


    void HideBorders()
    {
        foreach (GameObject border in Borders)
        {
            border.SetActive(false);
        }

    }

    void SetBorders()
    {
        for (int x = 0; x < DisplayedPhaseTwoProblemsList.Count; x++)
        {
            if (x < Borders.Count)
            { Borders[x].SetActive(true); }
            else
            { break; }
        }
    }


}

