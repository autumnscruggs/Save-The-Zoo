using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour 
	{

    [SerializeField]
    private GameObject creditsMenu;

    [SerializeField]
    private ImageCycle imageCycle;

    private LevelLoader levelLoader;
    private bool levelLoadedOnce = true;

	[SerializeField] private AudioSource ClickSound;

    void Start ()
    {
        //getting level loader reference
        levelLoader = this.GetComponent<LevelLoader>();
        //hide menus initially
        creditsMenu.SetActive(false);
	}
	

    //navigating between menus via these buttons

    public void CreditsButton()
    {
		ClickSound.Play ();
        creditsMenu.SetActive(true);
    }


    public void CreditsReturnButton()
    {
		ClickSound.Play ();
        creditsMenu.SetActive(false);
    }

    //start loading screen on button press
    public void PlayButton()
    {
		ClickSound.Play ();
        levelLoader.Load();
    }

    //exit application on button press
    public void QuitButton()
    {
		ClickSound.Play ();
        Application.Quit();
    }
}
