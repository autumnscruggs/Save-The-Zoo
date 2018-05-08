using UnityEngine;
using System.Collections;

public class AnimalMenuButtons : MonoBehaviour 
{

	[SerializeField] 
	private AudioSource ClickSound;


    public AnimalMenus animalMenus;

    /*-----------------PHASE 1 BUTTONS---------------*/
    public void MainPenguinButton()
    {
		ClickSound.Play ();
        animalMenus.TogglePenguinMenu(true);
    }

    public void MainPandaButton()
    {
		ClickSound.Play ();
        animalMenus.TogglePandaMenu(true);
    }

    public void MainGorillaButton()
    {
		ClickSound.Play ();
        animalMenus.ToggleGorillaMenu(true);
    }

    public void MainZebraButton()
    {
		ClickSound.Play ();
        animalMenus.ToggleZebraMenu(true);
    }

    public void MainKangarooButton()
    {
		ClickSound.Play ();
        animalMenus.ToggleKangarooMenu(true);
    }

    public void BackButtons()
    {
		ClickSound.Play ();
        animalMenus.TogglePenguinMenu(false);
        animalMenus.TogglePandaMenu(false);
        animalMenus.ToggleGorillaMenu(false);
        animalMenus.ToggleZebraMenu(false);
        animalMenus.ToggleKangarooMenu(false);
    }

}
