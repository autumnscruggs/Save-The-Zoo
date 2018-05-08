using UnityEngine;
using System.Collections;

public class UpgradeButtons : MonoBehaviour 
{
	[SerializeField] 
	private AudioSource ClickSound;

    public GameObject penguFoodMenu;
    public GameObject penguHabMenu;
    public GameObject penguPopMenu;

    public GameObject panFoodMenu;
    public GameObject panHabMenu;
    public GameObject panPopMenu;

    public GameObject gorFoodMenu;
    public GameObject gorHabMenu;
    public GameObject gorPopMenu;

    public GameObject zebFoodMenu;
    public GameObject zebHabMenu;
    public GameObject zebPopMenu;

    public GameObject kangFoodMenu;
    public GameObject kangHabMenu;
    public GameObject kangPopMenu;

    // Use this for initialization
    void Start ()
    {
        CloseAllFoodMenus();
        CloseAllHabMenus();
        CloseAllPopMenus();
    }


    /*--------------BUTTON CLICK METHODS--------------*/


    //PENGUIN BUTTONS
    public void PenguFoodButton()
    {
		ClickSound.Play ();
        OpenPenguMenu(0);
    }

    public void PenguHabitatButton()
    {
		ClickSound.Play ();
        OpenPenguMenu(1);
    }
    
    public void PenguPopulationButton()
    {
		ClickSound.Play ();
        OpenPenguMenu(2);
    }

    //PANDA BUTTONS
    public void PandaFoodButton()
    {
		ClickSound.Play ();
        OpenPandaMenu(0);
    }

    public void PandaHabitatButton()
    {
		ClickSound.Play ();
        OpenPandaMenu(1);
    }

    public void PandaPopulationButton()
    {
		ClickSound.Play ();
        OpenPandaMenu(2);
    }

    //GORILLA BUTTONS
    public void GorillaFoodButton()
    {
		ClickSound.Play ();
        OpenGorillaMenu(0);
    }

    public void GorillaHabitatButton()
    {
		ClickSound.Play ();
        OpenGorillaMenu(1);
    }

    public void GorillaPopulationButton()
    {
		ClickSound.Play ();
        OpenGorillaMenu(2);
    }

    //ZEBRA BUTTONS
    public void ZebraFoodButton()
    {
		ClickSound.Play ();
        OpenZebraMenu(0);
    }

    public void ZebraHabitatButton()
    {
		ClickSound.Play ();
        OpenZebraMenu(1);
    }

    public void ZebraPopulationButton()
    {
		ClickSound.Play ();
        OpenZebraMenu(2);
    }

    //KANGAROO BUTTONS
    public void KangarooFoodButton()
    {
		ClickSound.Play ();
        OpenKangarooMenu(0);
    }

    public void KangarooHabitatButton()
    {
		ClickSound.Play ();
		ClickSound.Play ();
        OpenKangarooMenu(1);
    }

    public void KangarooPopulationButton()
    {
		ClickSound.Play ();
        OpenKangarooMenu(2);
    }


    //HIDING BUTTONS
    public void HideFoodMenus()
    {
		ClickSound.Play ();
        CloseAllFoodMenus();
    }

    public void HideHabitatMenus()
    {
		ClickSound.Play ();
        CloseAllHabMenus();
    }

    public void HidePopulationMenus()
    {
		ClickSound.Play ();
        CloseAllPopMenus();
    }



    /*---------HIDING/OPENING MENU METHODS--------------*/

    //hide all food menus
    void CloseAllFoodMenus()
    {
        penguFoodMenu.SetActive(false);
        panFoodMenu.SetActive(false);
        gorFoodMenu.SetActive(false);
        zebFoodMenu.SetActive(false);
        kangFoodMenu.SetActive(false);
    }

    //hide all habitat menus
    void CloseAllHabMenus()
    {
        penguHabMenu.SetActive(false);
        panHabMenu.SetActive(false);
        gorHabMenu.SetActive(false);
        zebHabMenu.SetActive(false);
        kangHabMenu.SetActive(false);
    }

    //hide all population menus
    void CloseAllPopMenus()
    {
        penguPopMenu.SetActive(false);
        panPopMenu.SetActive(false);
        gorPopMenu.SetActive(false);
        zebPopMenu.SetActive(false);
        kangPopMenu.SetActive(false);
    }

    //open certain menu depending on the number
    void OpenPenguMenu(int menuNumber)
    {
        switch(menuNumber)
        {
            case 0:
                penguFoodMenu.SetActive(true);
                break;
            case 1:
                penguHabMenu.SetActive(true);
                break;
            case 2:
                penguPopMenu.SetActive(true);
                break;
        }
    }

    //open certain menu depending on the number
    void OpenPandaMenu(int menuNumber)
    {
        switch (menuNumber)
        {
            case 0:
                panFoodMenu.SetActive(true);
                break;
            case 1:
                panHabMenu.SetActive(true);
                break;
            case 2:
                panPopMenu.SetActive(true);
                break;
        }
    }

    //open certain menu depending on the number
    void OpenGorillaMenu(int menuNumber)
    {
        switch (menuNumber)
        {
            case 0:
                gorFoodMenu.SetActive(true);
                break;
            case 1:
                gorHabMenu.SetActive(true);
                break;
            case 2:
                gorPopMenu.SetActive(true);
                break;
        }
    }

    //open certain menu depending on the number
    void OpenZebraMenu(int menuNumber)
    {
        switch (menuNumber)
        {
            case 0:
                zebFoodMenu.SetActive(true);
                break;
            case 1:
                zebHabMenu.SetActive(true);
                break;
            case 2:
                zebPopMenu.SetActive(true);
                break;
        }
    }

    //open certain menu depending on the number
    void OpenKangarooMenu(int menuNumber)
    {
        switch (menuNumber)
        {
            case 0:
                kangFoodMenu.SetActive(true);
                break;
            case 1:
                kangHabMenu.SetActive(true);
                break;
            case 2:
                kangPopMenu.SetActive(true);
                break;
        }
    }

}
