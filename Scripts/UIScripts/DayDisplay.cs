using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DayDisplay : MonoBehaviour {

    [SerializeField]
    private Text dayDisplay;

	void Start ()
    {
        UpdateDayDisplayText();
    }

	void Update ()
    {
        UpdateDayDisplayText();
    }

    void UpdateDayDisplayText()
    {
        dayDisplay.text = NewDayManager.DayCount + " days worked" ;
    }
}
