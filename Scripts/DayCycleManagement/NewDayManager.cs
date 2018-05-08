using UnityEngine;
using System.Collections;

public class NewDayManager : MonoBehaviour {

    public static bool ResetAll = false;

    public static int DayCount = 0;

    public static bool FirstDayReset = false;
    public static bool SecondDayReset = false;
    public static bool ThirdDayReset = false;


    void Update()
    {
        if (FirstDayReset)
        { ResetAll = false; }

        if (ResetAll)
        {
            DayCount = 0;
            FirstDayReset = false;
            SecondDayReset = false;
            ThirdDayReset = false;
        }
    }
}
