using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossReportManager : MonoBehaviour {
    
    private bool happyBoss = true;
    private bool reallyUnhappyBoss = false;
    [SerializeField]
    private Text moodText;
    [SerializeField]
    private Color pleasedMoodColor;
    [SerializeField]
    private Color unhappyMoodColor;
    [SerializeField]
    private Color pissedMoodColor;
    [SerializeField]
    private HappinessManager happyManager;

    private int happyBossHappyLevel = 60;
    private int pissedBossHappyLevel = 25;

    [HideInInspector]
    public float bossBonusAmount = 2;

    [HideInInspector]
    public bool bossIsHappy;
    [HideInInspector]
    public bool bossIsUnhappy;
    [HideInInspector]
    public bool bossIsPissed;

    [HideInInspector]
    public string bossMood;

    void Start()
    {
        //pleased by default
        moodText.text = "Pleased";
        //setting mood bools
        bossIsHappy = true;
    }

    void Update ()
    {
        if (NewDayManager.DayCount > 0)
        {
            bossIsHappy = happyBoss && !reallyUnhappyBoss;
            bossIsUnhappy = !happyBoss && !reallyUnhappyBoss;
            bossIsPissed = !happyBoss && reallyUnhappyBoss;
        }

        DecideHappiness();
        UpdateMoodText();
    }
    

    void UpdateMoodText()
    {
        if(bossIsHappy)
        {
            bossMood = "Pleased";
            moodText.text = bossMood;
            moodText.color = pleasedMoodColor;
        }
        else if(bossIsUnhappy)
        {
            bossMood = "Unhappy";
            moodText.text = bossMood;
            moodText.color = unhappyMoodColor;
        }
        else
        {
            bossMood = "Pissed";
            moodText.text = bossMood;
            moodText.color = pissedMoodColor;
        }
    }

    void DecideHappiness()
    {
        if (happyManager.OverallHappiness >= happyBossHappyLevel)
        {
            happyBoss = true;
        }
        else if (happyManager.OverallHappiness <= pissedBossHappyLevel)
        {
            happyBoss = false;
            reallyUnhappyBoss = true;
        }
        else
        {
            happyBoss = false;
            reallyUnhappyBoss = false;
        }
    }
}
