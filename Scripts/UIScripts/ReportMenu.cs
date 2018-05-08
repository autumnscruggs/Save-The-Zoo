using UnityEngine;
using System.Collections;

public class ReportMenu : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject title;
    public GameObject closeButton;

    private PauseMenu pauseMenu;

	[SerializeField] private AudioSource ClickSound;

    // Use this for initialization
    void Start()
    {
        pauseMenu = this.GetComponent<PauseMenu>();
        ToggleReportMenu(false);
    }

    //show the pause menu
    public void OnClickShowReportMenu()
    {
		ClickSound.Play ();
        ToggleReportMenu(true);
        pauseMenu.IsPaused = true;
    }

    //hide the pause menu
    public void OnClickHideReportMenu()
    {
		ClickSound.Play ();
        ToggleReportMenu(false);
        pauseMenu.IsPaused = false;
    }

    //show/hide pause menu
    void ToggleReportMenu(bool show)
    {
        if (show)
        {
            menuPanel.SetActive(true);
        }
        else
        {
            menuPanel.SetActive(false);
        }

    }
}
