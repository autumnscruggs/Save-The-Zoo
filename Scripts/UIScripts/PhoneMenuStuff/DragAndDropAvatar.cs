using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DragAndDropAvatar : MonoBehaviour {

    [SerializeField]
    private AvatarUI avatarUI;
    [SerializeField]
    private Image spriteHolder;
    [SerializeField]
    private CooldownUIManager cooldownManager;
    private Image thisImage;

    [HideInInspector]
    public bool canDrag = false;

    [HideInInspector]
    public bool checkProblemSolving = false;
    [HideInInspector]
    public string problemType = "";

    void Start()
    {
        thisImage = this.GetComponent<Image>();
        ShowThisImage(false);
    }

    void Update()
    {
        DragImage();
    }

    void DragImage()
    {
        if (canDrag)
        {
            this.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else
        {
            this.transform.position = spriteHolder.transform.position;
        }
    }

    public void OnClickThisImage()
    {
        #region Activate Problem Solver
        if (thisImage.sprite == avatarUI.EmployeeSprites[0])
        {
            checkProblemSolving = true;
        }
        else if (thisImage.sprite == avatarUI.EmployeeSprites[1])
        {
            checkProblemSolving = true;
        }
        else if (thisImage.sprite == avatarUI.EmployeeSprites[2])
        {
            checkProblemSolving = true;
        }
        else
        {
            checkProblemSolving = true;
        }
        #endregion

        canDrag = false;
        ShowThisImage(false);
        StartEmployeeCooldown();
       
    }

    public void ShowThisImage(bool show)
    {
        this.gameObject.SetActive(show);
    }

    public void ChangeSprite(Sprite sprite)
    {
        thisImage.sprite = sprite;
        #region Changing Problem Type Based on Sprite
        if (thisImage.sprite == avatarUI.EmployeeSprites[0])
        {
            problemType = "zookeeper";
        }
        else if (thisImage.sprite == avatarUI.EmployeeSprites[1])
        {
            problemType = "vet";
        }
        else if (thisImage.sprite == avatarUI.EmployeeSprites[2])
        {
            problemType = "janitor";
        }
        else
        {
            problemType = "manager";
        }
        #endregion
    }

    void StartEmployeeCooldown()
    {
        if(thisImage.sprite == avatarUI.EmployeeSprites[0])
        {
            cooldownManager.zookeeperImages[0].cooldownTimerStart = true;
        }
        else if (thisImage.sprite == avatarUI.EmployeeSprites[1])
        {
            cooldownManager.vetImages[0].cooldownTimerStart = true;
        }
        else if (thisImage.sprite == avatarUI.EmployeeSprites[2])
        {
            cooldownManager.janitorImages[0].cooldownTimerStart = true;
        }
        else
        {
            cooldownManager.managerImages[0].cooldownTimerStart = true;
        }
    }

}
