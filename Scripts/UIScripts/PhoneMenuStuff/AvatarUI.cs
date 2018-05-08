using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class AvatarUI : MonoBehaviour 
{
    public float DelayTimer = 1f;

    [SerializeField]
    private GameObject ScrolledUI;

    [SerializeField]
    private Animator ScrollingAnimationControl;

    public bool PhoneisSelected;
    public bool EmployeeSelected;

	public bool ClickedAgain = false;

    public List<Sprite> EmployeeSprites = new List<Sprite>();
    #region EmployeeSprites Indexes
    //EMPLOYEE SPRITE INDEXES
    //[0] = Zookeeper
    //[1] = Vet
    //[2] = Janitor
    //[3] = VS Manager
    #endregion

    public Image spriteHolder;

    private bool employeeSpawned = false;

    private float animationTimer = 0f;
    private bool buttonDisabled = false;

    #region Glowing Stuff
    [SerializeField]
    private List<GameObject> glowingOutlines = new List<GameObject>();
    [SerializeField]
    private Color zooKeeperColor;
    [SerializeField]
    private Color zooVetColor;
    [SerializeField]
    private Color janitorColor;
    [SerializeField]
    private Color visitorColor;

    private const int KeeperAndVet = 0;
    private const int CleaningService = 1;
    private const int VisitorService = 2;
    #endregion

    void Start()
    {
        HideAllGlows();
        spriteHolder.enabled = false;
    }

    void Update()
    {

        if (animationTimer > 0)
        {
            AnimationTimer();
            buttonDisabled = true;
            //do nothing
        }
        else
        {
            buttonDisabled = false;
        }
        ScrollingAnimationControl.SetBool("PhoneisSelected", PhoneisSelected);
        ScrollingAnimationControl.SetBool("EmployeeSelected", EmployeeSelected);
    }

    void AnimationTimer()
    {
        animationTimer -= Time.deltaTime;
    }

	 void  OpenScrollMenu() 
    {
        PhoneisSelected = true;
	}
	

     void CloseScrollMenu()
    {
        //PhoneisSelected = false;
		EmployeeSelected = true;

    }

    public void ButtonClick()
    {
        if(buttonDisabled)
        {
            ActivateGlow(EventSystem.current.currentSelectedGameObject, false);
            //do nothing
        }
        else
        {
            ActivateGlow(EventSystem.current.currentSelectedGameObject, true);

            if (!PhoneisSelected)
            {
				employeeSpawned = false;
                OpenScrollMenu();
                if (!employeeSpawned)
                {
                    StartCoroutine("DelaySpriteSpawn");
                }

            }
			else if (PhoneisSelected && !EmployeeSelected)
			{

				employeeSpawned = false;
				if (!employeeSpawned)
				{
					StartCoroutine("DelaySpriteSpawn");
					PhoneisSelected = false;

				}

			}
			else if (PhoneisSelected && EmployeeSelected)
            {
                employeeSpawned = false;
                spriteHolder.enabled = false;
                CloseScrollMenu();
            }

            animationTimer = DelayTimer;
        }
        

        
    }

    void HideAllGlows()
    {
        foreach (GameObject glow in glowingOutlines)
        {
            glow.SetActive(false);
        }
    }

    void ActivateGlow(GameObject button, bool show)
    {
            switch (button.name)
            {
                case "ZooKeeperButton":
                    ShowGlow(KeeperAndVet, show);
                    for (int x = 0; x < 5; x++)
                    {
                        glowingOutlines[x].GetComponent<SpriteRenderer>().color = zooKeeperColor;
                    }
                    break;

                case "ZooVetButton":
                    ShowGlow(KeeperAndVet, show);
                    for (int x = 0; x < 5; x++)
                    {
                        glowingOutlines[x].GetComponent<SpriteRenderer>().color = zooVetColor;
                    }
                    break;

                case "CleaningButton":
                    ShowGlow(CleaningService, show);
                    glowingOutlines[6].GetComponent<SpriteRenderer>().color = janitorColor;
                break;

                case "VisitorServicesButton":
                    ShowGlow(VisitorService, show);
                    glowingOutlines[5].GetComponent<SpriteRenderer>().color = visitorColor;
                    break;

            }
    }

    void ShowGlow(int number, bool show)
    {
        switch(number)
        {
            case KeeperAndVet:
                for (int x = 0; x < 5; x++)
                  {
                    glowingOutlines[x].SetActive(show);
                 }
                   glowingOutlines[5].SetActive(!show);
                   glowingOutlines[6].SetActive(!show);
                break;
        case CleaningService:
                for (int x = 0; x < 5; x++)
                {
                    glowingOutlines[x].SetActive(!show);
                }
                glowingOutlines[5].SetActive(!show);
                glowingOutlines[6].SetActive(show);
                break;
        case VisitorService:
            for (int x = 0; x < 5; x++)
             {
                glowingOutlines[x].SetActive(!show);
            }
                glowingOutlines[5].SetActive(show);
                glowingOutlines[6].SetActive(!show);
               break;

        }
    }

    void SpawnEmployee(GameObject button)
    {
        switch(button.name)
        {
            case "ZooKeeperButton":
            spriteHolder.sprite = EmployeeSprites[0];
            break;

            case "ZooVetButton":
            spriteHolder.sprite = EmployeeSprites[1];
            break;

            case "CleaningButton":
            spriteHolder.sprite = EmployeeSprites[2];
            break;

            case "VisitorServicesButton":
            spriteHolder.sprite = EmployeeSprites[3];
            break;

        }
    }

    IEnumerator DelaySpriteSpawn()
    {

        yield return new WaitForSeconds(DelayTimer);
        employeeSpawned = true;
        SpawnEmployee(EventSystem.current.currentSelectedGameObject);
       spriteHolder.enabled = true;
    }
}
