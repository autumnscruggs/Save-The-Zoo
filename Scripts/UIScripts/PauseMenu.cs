using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{

    public GameObject menuPanel;
    public GameObject title;
    public GameObject instructionsButton;
    public GameObject quitButton;

	[SerializeField] private AudioSource ClickSound;

    public bool IsPaused { get; set; }

	// Use this for initialization
	void Start () 
    {
        TogglePauseMenu(false);
        IsPaused = false;
	}


    //show the pause menu
    public void OnClickShowPauseMenu()
    {
		ClickSound.Play ();
        TogglePauseMenu(true);
        IsPaused = true;
    }

    //hide the pause menu
    public void OnClickHidePauseMenu()
    {
		ClickSound.Play ();
        TogglePauseMenu(false);
        IsPaused = false;
    }

    //show/hide pause menu
    void TogglePauseMenu(bool show)
    {
        if(show) 
        {
            menuPanel.SetActive(true);
            title.SetActive(true);
            instructionsButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }
        else
        {
            menuPanel.SetActive(false);
            title.SetActive(false);
            instructionsButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(false);
        }
        
    }
}
