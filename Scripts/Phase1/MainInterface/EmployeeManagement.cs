using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class EmployeeManagement : MonoBehaviour {

    #region Menus
    public GameObject zookeeperUpgradeMenu;
    public GameObject vetUpgradeMenu;
    public GameObject janitorUpgradeMenu;
    public GameObject visitorUpgradeMenu;
    #endregion

    public int zookeepers = 1;
    public int vets = 1;
    public int janitors = 1;
    public int managers = 1;

    private int maxWorkerNumber = 3;

    [HideInInspector]
    public float zookeeperCooldownTime = 5f;
    [HideInInspector]
    public float vetsCooldownTime = 5f;
    [HideInInspector]
    public float janitorCooldownTime = 5f;
    [HideInInspector]
    public float managerCooldownTime = 5f;

    [SerializeField]
    private List<string> WorkerNames = new List<string>();
    private List<string> NamesInUse = new List<string>();

    [SerializeField]
    private List<GameObject> workerSlots = new List<GameObject>();

    #region Worker Slot Indexes
    //Worker[0-2] = Zookeeper
    //Worker[3-5] = Vet
    //Worker[6-8] = Janitor
    //Worker[9-11] = Visitor Managers
    #endregion

    [SerializeField]
    private List<GameObject> hireButtons = new List<GameObject>();
    [SerializeField]
    private List<GameObject> efficiencyButton = new List<GameObject>();

    public delegate void UpdateWorkerUIEvent();
    public event UpdateWorkerUIEvent UpdateWorkerUI;

    // Use this for initialization
    void Start()
    {
        HideAllUpgradeMenus();
        AssignWorkerNames();
    }

    //show/hide menu
    void ToggleMenu(GameObject menu, bool show)
    {
        if (show)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }

    }

    public void ShowUpgradeMenu(string workerType)
    {
        switch (workerType)
        {
            case "zookeeper":
                ToggleMenu(zookeeperUpgradeMenu, true);
                break;
            case "vet":
                ToggleMenu(vetUpgradeMenu, true);
                break;
            case "janitor":
                ToggleMenu(janitorUpgradeMenu, true);
                break;
            case "visitor":
                ToggleMenu(visitorUpgradeMenu, true);
                break;
        }

        UpdateWorkerUI();
    }

    public void HideAllUpgradeMenus()
    {
        ToggleMenu(zookeeperUpgradeMenu, false);
        ToggleMenu(vetUpgradeMenu, false);
        ToggleMenu(janitorUpgradeMenu, false);
        ToggleMenu(visitorUpgradeMenu, false);
    }

    void AddWorker(ref int workerNumber)
    {
        workerNumber++;
        if(workerNumber > (maxWorkerNumber - 1))
        {
            if (hireButtons.Contains (EventSystem.current.currentSelectedGameObject))
            {
                EventSystem.current.currentSelectedGameObject.SetActive(false);
            }
        }
    }

    public void HireWorkerButton(string workerType)
    {
        switch (workerType)
        {
            case "zookeeper":
                AddWorker(ref zookeepers);
                break;
            case "vet":
                AddWorker(ref vets);
                break;
            case "janitor":
                AddWorker(ref janitors);
                break;
            case "visitor":
                AddWorker(ref managers);
                break;
        }

        UpdateWorkerUI();
    }

    void WorkerUI()
    {
        #region ZookeeperUI
        switch (zookeepers)
        {
            case 0:
                workerSlots[0].SetActive(false);
                workerSlots[1].SetActive(false);
                workerSlots[2].SetActive(false);
                break;
            case 1:
                workerSlots[0].SetActive(true);
                workerSlots[1].SetActive(false);
                workerSlots[2].SetActive(false);
                break;
            case 2:
                workerSlots[0].SetActive(true);
                workerSlots[1].SetActive(true);
                workerSlots[2].SetActive(false);
                break;
            case 3:
                workerSlots[0].SetActive(true);
                workerSlots[1].SetActive(true);
                workerSlots[2].SetActive(true);
                break;
        }
        #endregion
        #region ZooVetUI
        switch (vets)
        {
            case 0:
                workerSlots[3].SetActive(false);
                workerSlots[4].SetActive(false);
                workerSlots[5].SetActive(false);
                break;
            case 1:
                workerSlots[3].SetActive(true);
                workerSlots[4].SetActive(false);
                workerSlots[5].SetActive(false);
                break;
            case 2:
                workerSlots[3].SetActive(true);
                workerSlots[4].SetActive(true);
                workerSlots[5].SetActive(false);
                break;
            case 3:
                workerSlots[3].SetActive(true);
                workerSlots[4].SetActive(true);
                workerSlots[5].SetActive(true);
                break;
        }
        #endregion
        #region JanitorUI
        switch (janitors)
        {
            case 0:
                workerSlots[6].SetActive(false);
                workerSlots[7].SetActive(false);
                workerSlots[8].SetActive(false);
                break;
            case 1:
                workerSlots[6].SetActive(true);
                workerSlots[7].SetActive(false);
                workerSlots[8].SetActive(false);
                break;
            case 2:
                workerSlots[6].SetActive(true);
                workerSlots[7].SetActive(true);
                workerSlots[8].SetActive(false);
                break;
            case 3:
                workerSlots[6].SetActive(true);
                workerSlots[7].SetActive(true);
                workerSlots[8].SetActive(true);
                break;
        }
        #endregion
        #region VisitorServiceUI
        switch (managers)
        {
            case 0:
                workerSlots[9].SetActive(false);
                workerSlots[10].SetActive(false);
                workerSlots[11].SetActive(false);
                break;
            case 1:
                workerSlots[9].SetActive(true);
                workerSlots[10].SetActive(false);
                workerSlots[11].SetActive(false);
                break;
            case 2:
                workerSlots[9].SetActive(true);
                workerSlots[10].SetActive(true);
                workerSlots[11].SetActive(false);
                break;
            case 3:
                workerSlots[9].SetActive(true);
                workerSlots[10].SetActive(true);
                workerSlots[11].SetActive(true);
                break;
        }
        #endregion
    }


    #region Event Subscription
    void OnEnable()
    {
        UpdateWorkerUI += WorkerUI;
    }

    void OnDisable()
    {
        UpdateWorkerUI -= WorkerUI;
    }
    #endregion

    void GetRandomWorkerNames()
    {
        for (int x = 0; x < workerSlots.Count; x++)
        {
            /*while (true)
            {
                int index = Random.Range(0, WorkerNames.Count);
                if (!NamesInUse.Contains(WorkerNames[index]))
                {
                    NamesInUse.Add(WorkerNames[index]);
                    break;
                }
            }*/
            int index = Random.Range(0, WorkerNames.Count);
            if (!NamesInUse.Contains(WorkerNames[index]))
            {
                NamesInUse.Add(WorkerNames[index]);
            }
        }
    }

    void AssignWorkerNames()
    {
        GetRandomWorkerNames();

        int index = 0;
        foreach (GameObject slot in workerSlots)
        {
            slot.transform.FindChild("Name").GetComponent<Text>().text = NamesInUse[index];
            index++;
        }
    }
}
