using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayCycleManager : MonoBehaviour {

    [SerializeField]
    private ChangingPhases changingPhases;
    [SerializeField]
    private Text phase2TimerText;
    [SerializeField]
    private float phase2TimeLeft = 300f;
    //property to get phase2TimeLeft but prevent it from being set
    public float Phase2TimeLeft { get { return phase2TimeLeft; } }
    private float originalTimeLeft;
    private Color originalColor;

    //hides these things from the inspector
    [HideInInspector]
    public bool firstDayComplete = false;
    [HideInInspector]
    public bool canBeginPhase1 = false;
    [HideInInspector]
    public bool canBeginPhase2 = false;
    [HideInInspector]
    public bool canBeginPhase3 = false;

    [SerializeField]
    private HappinessManager happinessMan;
    [HideInInspector]
    public float phase2happiness;

    private PauseMenu pauseMenu;

    void Start()
    {  
        //sets original time
        originalTimeLeft = phase2TimeLeft;
        changingPhases.CanBeginWhatPhase(1);
        pauseMenu = this.GetComponent<PauseMenu>();
        originalColor = phase2TimerText.color;
    }


    void Update()
    {
        //prints for debugging
        //print("original time: " + originalTimeLeft);
        //print("phase2TimeLeft: " + phase2TimeLeft);
        //print("CanBeginPhase1:" + canBeginPhase1);
        //print("CanBeginPhase2:" + canBeginPhase2);
        //print("CanBeginPhase3:" + canBeginPhase3);

        if (!firstDayComplete)
        {
            FirstDayCycle();
        }
        else
        {
            NextDayCycle();
        }
    }

    public void NextDayCycle()
    {
        if (canBeginPhase1)
        {
            Phase1();
        }
        else if (canBeginPhase2)
        {
            Phase2();
        }
        else if (canBeginPhase3)
        {
            Phase3();
        }
    }

    public void FirstDayCycle()
    {
        if(canBeginPhase1)
        {
            Phase1();
        }
        else if(canBeginPhase2)
        {
            Phase2();
        }
        else if(canBeginPhase3)
        {
            Phase3();
        }
    }

    public void Phase1()
    {
        //stop time
        Time.timeScale = 0;
    }

    //resetting the timer for phase2
    public void ResetPhase2Timer()
    {
        //hide enter phase 2 button
        changingPhases.phase3UIButton.SetActive(false);
        phase2TimeLeft = originalTimeLeft;
    }

    public void Phase2()
    {
        //DEBUG CHEAT CODE Q
        if (Input.GetKeyDown(KeyCode.Q))
        { phase2TimeLeft = 0; }
        //ONLY FOR DEBUGGING

        //if not paused, start time
        if (!pauseMenu.IsPaused)
        { Time.timeScale = 1; }
        else { Time.timeScale = 0; }

        //begin timer and set it to phase2 timer text
        //the to string f1 just limits the decimal places
        if (phase2TimeLeft > 0)
        {
            phase2TimerText.text = "" + phase2TimeLeft.ToString("f1") + " seconds";
            phase2TimeLeft -= Time.deltaTime;
        }

        //once it reaches a certain point, change the color
        if (phase2TimeLeft <= 40)
        { phase2TimerText.color = Color.red; }
        else //else set it to its original color
        { phase2TimerText.color = originalColor; }

        //if it reaches 0
        if (phase2TimeLeft <= 0)
        {
            phase2happiness = happinessMan.OverallHappiness;
            //stop time
            Time.timeScale = 0;
            //show phase 3 button
            changingPhases.phase3UIButton.SetActive(true);
        }
    }

    public void Phase3()
    {
        //start time
        Time.timeScale = 0;
    }


}
