using UnityEngine;
using System.Collections;

public class NotificationMenu : MonoBehaviour {

    [SerializeField]
    private GameObject notificationMenu;
    [SerializeField]
    private PauseMenu pause;

	[SerializeField] 
	private AudioSource ClickSound;


	// Use this for initialization
	void Start ()
    {
        notificationMenu.SetActive(false);
	}
	

    public void OpenNotificationMenu()
    {
		ClickSound.Play ();
        notificationMenu.SetActive(true);
        pause.IsPaused = true;
    }

    public void CloseNotificationMenu()
    {
		ClickSound.Play ();
        notificationMenu.SetActive(false);
        pause.IsPaused = false;
    }

}
