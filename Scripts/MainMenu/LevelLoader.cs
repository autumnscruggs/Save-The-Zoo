using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    [SerializeField]
    private GameObject loadingScreen;
    [SerializeField]
    private Image loadingBar;
    [SerializeField]
    private GameObject startButton;

    private float loadWaitSpeed = 1f;

    //the asyncoperation is just the variable to hold the load stuff
    private AsyncOperation async;

    void Start()
    {
        //hiding loading screen initialy
        loadingScreen.SetActive(false);
        //hide start button
        startButton.SetActive(false);
    }

    //load level on button click
    public void Load()
    {
        StartCoroutine("LoadLevel");
    }

    IEnumerator LoadLevel()
    {
        print("Level Loading");
        //show loading screen
        loadingScreen.SetActive(true); 

        //this is a unity function that will load the level asynchronously in the background
        //basically this allows you to load before you get to a level
        async = Application.LoadLevelAsync("GameplayScene");
        //this prevents the scene from being activated once it loads
        async.allowSceneActivation = false;

        //while the async isn't done
        while (!async.isDone)
        {
            //this manipulates the fill amount on the image
            //the fill amount is basically how much of the image is shown
            //and this async progress keeps track of the load
            //this times 100 allows the bar to fill completely
            loadingBar.fillAmount = async.progress / 0.9f;
            print("async: " + async.progress);

            if (loadingBar.fillAmount >= 0.9)
            {
                //show button once level loaded
                startButton.SetActive(true);
            }

            yield return new WaitForSeconds(loadWaitSpeed);
        }

    }


    public void StartGame()
    {
        //sets the scene to be active
        async.allowSceneActivation = true;
        NewDayManager.ResetAll = true;
    }
    
}
