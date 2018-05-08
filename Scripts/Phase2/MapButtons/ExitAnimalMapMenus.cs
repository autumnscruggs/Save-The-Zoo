using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExitAnimalMapMenus : MonoBehaviour 
{
	[SerializeField] 
	private AudioSource ClickSound;


    [SerializeField]
    private List<GameObject> animalMapMenus = new List<GameObject>();


    //set all the menus in the list false on button press
    public void ExitButton()
    {
        foreach (GameObject menu in animalMapMenus)
        {
			ClickSound.Play ();
            menu.SetActive(false);
        }
    }
    

}
