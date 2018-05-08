using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EmployeeCooldownUI : MonoBehaviour
{
    public enum EmployeeType { ZOOKEEPER, VET, JANITOR, MANAGER }
    public EmployeeType currentEmployeeType;

    private Image employeeImage;
    private Image timerBar;

    private float cooldownTime;
    private float originalTime;
    [HideInInspector]
    public bool cooldownTimerStart = false;

    [SerializeField]
    private EmployeeManagement employeeManagement;
    [SerializeField]
    private CooldownUIManager cooldownManager;

	// Use this for initialization
	void Start () 
    {
        timerBar = this.transform.FindChild("TimerBar").GetComponent<Image>();
        employeeImage = this.transform.FindChild("EmployeeImage").GetComponent<Image>();
        timerBar.color = cooldownManager.timerNotInProgress;
        DecideEmployeeCooldown();
	}
	
	// Update is called once per frame
	void Update () 
    {
        EmployeeCooldown();
	}

    void DecideEmployeeCooldown()
    {
        switch (currentEmployeeType)
        {
            case EmployeeType.ZOOKEEPER:
                cooldownTime = employeeManagement.zookeeperCooldownTime;
                break;
            case EmployeeType.VET:
                cooldownTime = employeeManagement.vetsCooldownTime;
                break;
            case EmployeeType.JANITOR:
                cooldownTime = employeeManagement.janitorCooldownTime;
                break;
            case EmployeeType.MANAGER:
                cooldownTime = employeeManagement.managerCooldownTime;
                break;
        }

        originalTime = cooldownTime;
    }

    void EmployeeCooldown()
    {
        if (cooldownTimerStart)
        {
            cooldownTime -= Time.deltaTime;
            timerBar.color = cooldownManager.timerInProgress;
            employeeImage.color = cooldownManager.grayedOut;
            timerBar.fillAmount = (cooldownTime / originalTime);
            if (cooldownTime <= 0)
            {  cooldownTimerStart = false;  }
        }
        else
        {
            cooldownTime = originalTime;
            employeeImage.color = Color.white;
            timerBar.fillAmount = 1;
            timerBar.color = cooldownManager.timerNotInProgress;
        }
        

    }
}
 