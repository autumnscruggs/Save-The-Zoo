using UnityEngine;
using System.Collections;

public class InstructionsMenu : MonoBehaviour {

    [SerializeField]
    private GameObject instructionsMenu;
    [SerializeField]
    private GameObject intro;
    [SerializeField]
    private GameObject phase1;
    [SerializeField]
    private GameObject phase2;
    [SerializeField]
    private GameObject phase3;
    [SerializeField] 
	private AudioSource ClickSound;

	void Start ()
    {
        instructionsMenu.SetActive(false);
        intro.SetActive(true);
	}
	
    public void OpenInstructions()
    {
		ClickSound.Play ();
        instructionsMenu.SetActive(true);
    }

    public void CloseInstructions()
    {
		ClickSound.Play ();
        instructionsMenu.SetActive(false);
    }

    public void IntroButton()
    {
        InstructionScreens("intro");
    }

    public void Phase1Button()
    {
        InstructionScreens("phase1");
    }

    public void Phase2Button()
    {
        InstructionScreens("phase2");
    }

    public void Phase3Button()
    {
        InstructionScreens("phase3");
    }

    void InstructionScreens(string screen)
    {
        switch(screen)
        {
            case "intro":
                intro.SetActive(true);
                phase1.SetActive(false);
                phase2.SetActive(false);
                phase3.SetActive(false);
                break;
            case "phase1":
                intro.SetActive(false);
                phase1.SetActive(true);
                phase2.SetActive(false);
                phase3.SetActive(false);
                break;
            case "phase2":
                intro.SetActive(false);
                phase1.SetActive(false);
                phase2.SetActive(true);
                phase3.SetActive(false);
                break;
            case "phase3":
                intro.SetActive(false);
                phase1.SetActive(false);
                phase2.SetActive(false);
                phase3.SetActive(true);
                break;
        }
    }

}
