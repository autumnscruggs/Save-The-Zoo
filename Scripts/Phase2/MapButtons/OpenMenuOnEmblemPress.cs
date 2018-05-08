using UnityEngine;
using System.Collections;


public class OpenMenuOnEmblemPress : MonoBehaviour
{
    [SerializeField]
    private AudioSource ClickSound;

    private Collider2D collider;

    private HideMenusOnDayReset hideMenu;

    private ChangingPhases changePhases;

    [SerializeField]
    private Phase2ButtonChecker phase2Checker;

    [SerializeField]
    private DragAndDropAvatar dragNDrop;

    private bool firstTime = true;

    void Start()
    {
        //ref to thingies
        hideMenu = GameObject.Find("GameMaster").GetComponent<HideMenusOnDayReset>();
        changePhases = GameObject.Find("GameMaster").GetComponent<ChangingPhases>();
        collider = this.GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        if (firstTime)
        {
            SolveProblem(dragNDrop.problemType, this.gameObject.name);
            dragNDrop.checkProblemSolving = false;
            firstTime = false;
        }
        else if (dragNDrop.checkProblemSolving)
        {
            SolveProblem(dragNDrop.problemType, this.gameObject.name);
            dragNDrop.checkProblemSolving = false;
        }
    }

    void SolveProblem(string problemType, string buttonName)
    {
        switch (buttonName)
        {
            case "PenguMenuButton":
                #region Penguin Problem Solving
                switch (problemType)
                {
                    case "zookeeper":
                        phase2Checker.PenguKeeperButton();
                        break;
                    case "vet":
                        phase2Checker.PenguVetButton();
                        break;
                    case "janitor":
                        print("It's trying to do a penguin janitor thing");
                        break;
                    case "manager":
                        print("It's trying to do a penguin manager thing");
                        break;
                }
                #endregion
                break;
            case "PandaMenuButton":
                #region Panda Problem Solving
                switch (problemType)
                {
                    case "zookeeper":
                        phase2Checker.PandaKeeperButton();
                        break;
                    case "vet":
                        phase2Checker.PandaVetButton();
                        break;
                    case "janitor":
                        print("It's trying to do a panda janitor thing");
                        break;
                    case "manager":
                        print("It's trying to do a panda manager thing");
                        break;
                }
                #endregion
                break;
            case "GorillaMenuButton":
                #region Gorilla Problem Solving
                switch (problemType)
                {
                    case "zookeeper":
                        phase2Checker.GorillaKeeperButton();
                        break;
                    case "vet":
                        phase2Checker.GorillaVetButton();
                        break;
                    case "janitor":
                        print("It's trying to do a gorilla janitor thing");
                        break;
                    case "manager":
                        print("It's trying to do a gorilla manager thing");
                        break;
                }
                #endregion
                break;
            case "ZebraMenuButton":
                #region Zebra Problem Solving
                switch (problemType)
                {
                    case "zookeeper":
                        phase2Checker.ZebraKeeperButton();
                        break;
                    case "vet":
                        phase2Checker.ZebraVetButton();
                        break;
                    case "janitor":
                        print("It's trying to do a zebra janitor thing");
                        break;
                    case "manager":
                        print("It's trying to do a zebra manager thing");
                        break;
                }
                #endregion
                break;
            case "KangMenuButton":
                #region Kangaroo Problem Solving
                switch (problemType)
                {
                    case "zookeeper":
                        phase2Checker.KangarooKeeperButton();
                        break;
                    case "vet":
                        phase2Checker.KangarooVetButton();
                        break;
                    case "janitor":
                        print("It's trying to do a kang janitor thing");
                        break;
                    case "manager":
                        print("It's trying to do a kang manager thing");
                        break;
                }
                #endregion
                break;
            case "CleaningServicesEmblem":
                #region Janitor Problem Solving
                switch (problemType)
                {
                    case "zookeeper":
                        print("It's trying to do a zookeeper janitor thing");
                        break;
                    case "vet":
                        print("It's trying to do a vet janitor thing");
                        break;
                    case "janitor":
                        phase2Checker.GeneralCuratorButton();
                        break;
                    case "manager":
                        print("It's trying to do a manager janitor thing");
                        break;
                }
                #endregion
                break;
            case "VisitorServicesEmblem":
                #region VS Manager Problem Solving
                switch (problemType)
                {
                    case "zookeeper":
                        print("It's trying to do a zookeeper manager thing");
                        break;
                    case "vet":
                        print("It's trying to do a vet manager thing");
                        break;
                    case "janitor":
                        print("It's trying to do a janitor manager thing");
                        break;
                    case "manager":
                        phase2Checker.GeneralServicesButton();
                        break;
                }
                #endregion
                break;

        }
    }

    void TurnOffCollider()
    {
        //if at any point this bool is false, turn off colliders
        if(!changePhases.collidersOn)
        {
            collider.enabled = false;
        }
        //if any map menus are active, turn off collider
        else if (hideMenu.mapMenus[0].activeInHierarchy)
        {
            collider.enabled = false;
        }
        else if (hideMenu.mapMenus[1].activeInHierarchy)
        {
            collider.enabled = false;
        }
        else if (hideMenu.mapMenus[2].activeInHierarchy)
        {
            collider.enabled = false;
        }
        else if (hideMenu.mapMenus[3].activeInHierarchy)
        {
            collider.enabled = false;
        }
        else if (hideMenu.mapMenus[4].activeInHierarchy)
        {
            collider.enabled = false;
        }
        else if (hideMenu.mapMenus[5].activeInHierarchy)
        {
            collider.enabled = false;
        }
        else
        {
            collider.enabled = true;
        }
    }
}