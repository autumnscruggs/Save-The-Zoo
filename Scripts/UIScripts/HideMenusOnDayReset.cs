using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HideMenusOnDayReset : MonoBehaviour {

    [SerializeField]
    private List<GameObject> animalMenus = new List<GameObject>();

    public List<GameObject> mapMenus = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (NewDayManager.FirstDayReset)
        {
            foreach (GameObject menu in mapMenus)
            {
                menu.SetActive(false);
            }

            foreach (GameObject menu in animalMenus)
            {
                menu.SetActive(false);
            }
        }

    }

}
