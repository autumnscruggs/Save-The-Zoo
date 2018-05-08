using UnityEngine;
using System.Collections;

public class ChangingPhases : MonoBehaviour {

    [SerializeField]
    private GameObject phase1Interface;
    public GameObject phase2UIButton;
    public GameObject phase3UIButton;
    [SerializeField]
    private GameObject phase2Interface;
    [SerializeField]
    private GameObject phase3Interface;
    [SerializeField]
    private GameObject notificationList;
    [SerializeField]
    private GameObject objectiveList;

    [SerializeField]
    private DayCycleManager dayCycle;
    [SerializeField]
    private Phase1ProblemGenerator phase1Problems;
    [SerializeField]
    private DailyResults dailyResult;

    [SerializeField]
    private HappinessManager happinessMan;

    [HideInInspector]
    public float phase1Happiness;

	[SerializeField] 
	private AudioSource ClickSound;

    public bool collidersOn;

    void Start()
    {
        //hiding notificationlist and phase2 interface
        notificationList.SetActive(false);
        phase2Interface.SetActive(false);
        NewDayManager.FirstDayReset = true;
    }

    private void EnterPhase2()
    {
        //can reset second day
        NewDayManager.SecondDayReset = true;
        phase1Happiness = happinessMan.OverallHappiness;
        //BEGIN PHASE 2
        CanBeginWhatPhase(2);
        //hiding phase 1 interface
        phase1Interface.SetActive(false);
        //hiding enter phase 2 button
        phase2UIButton.SetActive(false);
        //hiding objectives
        objectiveList.SetActive(false);
        //showing notifications
        notificationList.SetActive(true);
        //showing interface
        phase2Interface.SetActive(true);
        //hide enter phase 2 button
        phase3UIButton.SetActive(false);

    }

    private void EnterPhase3()
    {
        //BEGIN PHASE 3, STOP PHASE 2
        CanBeginWhatPhase(3);
        //hiding phase 2 interface
        phase2Interface.SetActive(false);
        //showing phase 3 interface
        phase3Interface.SetActive(true);
    }

    private void BacktoPhase1()
    {
        CanBeginWhatPhase(1);
        //hiding phase 3 interface
        phase3Interface.SetActive(false);
        //showing phase 1 interface
        phase1Interface.SetActive(true);
        //show enter phase 2 button
        phase2UIButton.SetActive(true);
        //hiding notifications
        notificationList.SetActive(false);
        //showing objectives
        objectiveList.SetActive(true);
        //reset phase 1 problems
        phase1Problems.GetRandomNumberofProblems();
    }

    //on button press, enter phase 2
    public void Phase2Button()
    {
		ClickSound.Play ();
        EnterPhase2();
    }

    //on button press, enter phase 3
    public void Phase3Button()
    {
		ClickSound.Play ();
        NewDayManager.ThirdDayReset = true;
        EnterPhase3();
    }

    //on button press, return to phase 1
    public void NextDayButton()
    {
		ClickSound.Play ();
        //storing previous happiness
        dailyResult.previousHappiness = happinessMan.OverallHappiness;

        BacktoPhase1();
        //if first day hasn't been completed, complete it
        if(!dayCycle.firstDayComplete)
        {
            dayCycle.firstDayComplete = true;
        }
        else
        {
            //do nothing
        }
        //begin phase 1 and start next day cycle
        dayCycle.canBeginPhase1 = true;
        dayCycle.ResetPhase2Timer();
        dayCycle.NextDayCycle();
        NewDayManager.DayCount++;
        NewDayManager.FirstDayReset = true;
    }

    public void CanBeginWhatPhase(int phase)
    {
        switch(phase)
        {
            case 1:
                dayCycle.canBeginPhase1 = true;
                dayCycle.canBeginPhase2 = false;
                dayCycle.canBeginPhase3 = false;
                collidersOn = false;
                break;
            case 2:
                dayCycle.canBeginPhase1 = false;
                dayCycle.canBeginPhase2 = true;
                dayCycle.canBeginPhase3 = false;
                collidersOn = true;
                break;
            case 3:
                dayCycle.canBeginPhase1 = false;
                dayCycle.canBeginPhase2 = false;
                dayCycle.canBeginPhase3 = true;
                collidersOn = false;
                break;
        }
    }

}
