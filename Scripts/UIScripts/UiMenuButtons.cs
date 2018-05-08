using UnityEngine;
using System.Collections;

public class UiMenuButtons : MonoBehaviour {


    private float loadWaitSpeed = 2f;

	[SerializeField] 
	private AudioSource ClickSound;

    public void QuitGame()
    {
		ClickSound.Play ();
        Application.LoadLevel("MainMenu");
    }

    IEnumerator LoadMainMenuLevel()
    {
        AsyncOperation async = Application.LoadLevelAsync("MainMenu");

        //while the async isn't done
        while (!async.isDone)
        {
            print("menu async: " + async.progress);

            yield return new WaitForSeconds(loadWaitSpeed);
        }

    }


}
