using UnityEngine;
using System.Collections;

public class FactButtons : MonoBehaviour 
{
	[SerializeField] 
	private AudioSource ClickSound;

    public GameObject penguFactMenu;
    public GameObject panFactMenu;
    public GameObject gorFactMenu;
    public GameObject zebFactMenu;
    public GameObject kangFactMenu;

    void Start()
    {
        //set all menus to false
        HideMenus();
    }

    /*-----------------FACT BUTTONS---------------*/
    public void PenguinFactButton()
    {
		ClickSound.Play ();
        penguFactMenu.SetActive(true);
    }

    public void PandaFactButton()
    {
		ClickSound.Play ();
        panFactMenu.SetActive(true);
    }

    public void GorillaFactButton()
    {
		ClickSound.Play ();
        gorFactMenu.SetActive(true);
    }

    public void ZebraFactButton()
    {
		ClickSound.Play ();
        zebFactMenu.SetActive(true);
    }

    public void KangarooFactButton()
    {
		ClickSound.Play ();
        kangFactMenu.SetActive(true);
    }

    //hides all menus
    public void HideFactsButton()
    {
		ClickSound.Play ();
        HideMenus();
    }

    //sets all menus to false
    void HideMenus()
    {
        penguFactMenu.SetActive(false);
        panFactMenu.SetActive(false);
        gorFactMenu.SetActive(false);
        zebFactMenu.SetActive(false);
        kangFactMenu.SetActive(false);
    }

}
