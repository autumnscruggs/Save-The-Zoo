using UnityEngine;
using System.Collections;

public class AnimalMenus : MonoBehaviour {

    public GameObject penguinMenu;
    public GameObject pandaMenu;
    public GameObject gorillaMenu;
    public GameObject zebraMenu;
    public GameObject kangarooMenu;

    // Use this for initialization
    void Start()
    {
        TogglePenguinMenu(false);
        TogglePandaMenu(false);
        ToggleGorillaMenu(false);
        ToggleZebraMenu(false);
        ToggleKangarooMenu(false);
    }


   
    //show/hide menu
    public void TogglePenguinMenu(bool show)
    {
        if (show)
        {
            penguinMenu.SetActive(true);
        }
        else
        {
            penguinMenu.SetActive(false);
        }

    }

    //show/hide  menu
    public void TogglePandaMenu(bool show)
    {
        if (show)
        {
            pandaMenu.SetActive(true);
        }
        else
        {
            pandaMenu.SetActive(false);
        }

    }

    //show/hide  menu
    public void ToggleGorillaMenu(bool show)
    {
        if (show)
        {
            gorillaMenu.SetActive(true);
        }
        else
        {
            gorillaMenu.SetActive(false);
        }

    }


    //show/hide  menu
    public void ToggleZebraMenu(bool show)
    {
        if (show)
        {
            zebraMenu.SetActive(true);
        }
        else
        {
            zebraMenu.SetActive(false);
        }

    }


    //show/hide  menu
    public void ToggleKangarooMenu(bool show)
    {
        if (show)
        {
            kangarooMenu.SetActive(true);
        }
        else
        {
            kangarooMenu.SetActive(false);
        }

    }

}
