using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProblemDisplay : MonoBehaviour {

    [SerializeField]
    private GameObject problemDeductionDisplay;
    public Text deductionDescription;
    [SerializeField]
    private AudioSource ClickSound;

    void Start ()
    {
        //hide problem display initially
        problemDeductionDisplay.SetActive(false);
    }
	
    public void ShowProblemDeductionDisplay(bool show)
    {
        problemDeductionDisplay.SetActive(show);
    }

    public void CloseButton()
    {
        ClickSound.Play();
        //hide the menu
        ShowProblemDeductionDisplay(false);
        //and reset the text
        deductionDescription.text = "";
    }

}
