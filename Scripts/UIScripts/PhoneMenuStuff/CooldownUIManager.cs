using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CooldownUIManager : MonoBehaviour 
{
    public Color grayedOut;
    public Color timerInProgress;
    public Color timerNotInProgress;

    public List<EmployeeCooldownUI> zookeeperImages = new List<EmployeeCooldownUI>();
    public List<EmployeeCooldownUI> vetImages = new List<EmployeeCooldownUI>();
    public List<EmployeeCooldownUI> janitorImages = new List<EmployeeCooldownUI>();
    public List<EmployeeCooldownUI> managerImages = new List<EmployeeCooldownUI>();

}
