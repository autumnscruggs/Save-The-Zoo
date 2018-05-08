using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwapInterfaceMenus : MonoBehaviour {

    [SerializeField]
    private GameObject employeeMenu;
    [SerializeField]
    private GameObject animalMenu;

    [SerializeField]
    private GameObject button;
    [SerializeField]
    private Color employeeButtonColor;
    [SerializeField]
    private Color animalButtonColor;

    private const int AnimalMenu = 0;
    private const int EmployeeMenu = 1;

    private bool showAnimalMenu = false;

	void Start ()
    {
        MenuSwap(AnimalMenu);
    }
	
    public void ButtonClickMenuSwap()
    {
        showAnimalMenu = !showAnimalMenu;

        if(showAnimalMenu)
        {   MenuSwap(AnimalMenu); }
        else
        { MenuSwap(EmployeeMenu); }
    }

    void MenuSwap(int menu)
    {
        if (menu == AnimalMenu)
        {
            button.GetComponent<Image>().color = employeeButtonColor;
            button.transform.FindChild("Text").GetComponent<Text>().text = "Employees";
            animalMenu.SetActive(true);
            employeeMenu.SetActive(false);
        }
        else
        {
            button.GetComponent<Image>().color = animalButtonColor;
            button.transform.FindChild("Text").GetComponent<Text>().text = "Animals";
            animalMenu.SetActive(false);
            employeeMenu.SetActive(true);
        }
    }
}
