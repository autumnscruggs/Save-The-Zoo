using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//report class that holds the text of the report
//and the number of that report, which is basically the day the report is instantiated on
public class Report
{
    public int ReportNumber
    { get; set; }
    public string ReportText
    { get; set; }

    public Report(string _reportText, int _reportNumber)
    {
        ReportNumber = _reportNumber;
        ReportText = _reportText;
    }
}

public class ReportDisplayManager : MonoBehaviour
{

    public List<string> GoodReportsList = new List<string>();
    public List<string> BadReportsList = new List<string>();
    public List<string> ReallyBadReportsList = new List<string>();
    [HideInInspector]
    public List<Report> DisplayedReportsList = new List<Report>();

    private List<GameObject> SpawnedReports = new List<GameObject>();

    public GameObject reportPrefab;
    private GameObject reportSpawn;
    public Transform reportSpawnPoint;
    private Vector3 reportPosition;
    private Quaternion reportRotation;
    public GameObject reportList;

    private string report = null;
    private int displayedIndex = 0;

    private BossReportManager bossManager;

    [SerializeField]
    private string firstDayMessage = "Welcome to your job. We're counting on you.";

    [SerializeField]
    private Text latestReport;
    [SerializeField]
    private DayCycleManager dayCycle;

    void Start()
    {
        //getting boss manager reference
        bossManager = this.GetComponent<BossReportManager>();
        //show a new report
        NewReport();
    }

    void Update()
    {
        //if it's a new day, generate a new report
        if (NewDayManager.FirstDayReset)
        { NewReport(); }
    }

    void NewReport()
    {
        //fill the lists
        PopulateLists();
        //display the objectives
        DisplayReports();
    }

    void PopulateLists()
    {
        string report;

        //if the first day hasn't been completed, show the first day message
        if (!dayCycle.firstDayComplete)
        {
            report = firstDayMessage;
        }
        //else change report based on boss mood
        else if (bossManager.bossIsHappy)
        {
            report = GoodReportsList[Random.Range(0, GoodReportsList.Count)];
        }
        else if (bossManager.bossIsPissed)
        {
            report = ReallyBadReportsList[Random.Range(0, ReallyBadReportsList.Count)];
        }
        else
        {
            report = BadReportsList[Random.Range(0, BadReportsList.Count)];
        }

        //creating a new class of the report, containing the randomly generated report
        //and the index increment
        Report rpt = new Report(report, displayedIndex);

        //then add it to the display list
        DisplayedReportsList.Add(rpt);
        //then increment the index
        displayedIndex++;
    }

    void DisplayReports()
    {
        //the most recent report should be displayed in the latest report box
        latestReport.text = "\"" + DisplayedReportsList[displayedIndex - 1].ReportText + "\"";

        //for each child in the children of the report list
        //destroy it if it's a report block
        foreach (Transform child in reportList.transform)
        {
            if (child.name.StartsWith("ReportBlock"))
            {
                //Debug.Log("Destroying " + child.name);
                Destroy(child.gameObject);
            }
        }

        //then, for each report class in displayed reports
        //order the list by descending based on the report number, so the newest comes first
        foreach (Report rpt in DisplayedReportsList.OrderByDescending(o => o.ReportNumber).ToList())
        {
            //set the positions and rotations
            reportPosition = new Vector3(reportSpawnPoint.position.x, reportSpawnPoint.position.y, reportSpawnPoint.position.z);
            reportRotation = Quaternion.Euler(reportSpawnPoint.rotation.x, reportSpawnPoint.rotation.y, reportSpawnPoint.rotation.z);
            reportPosition.Set(reportPosition.x, reportPosition.y, reportPosition.z);

            //and then spawn those objectives
            reportSpawn = Instantiate(reportPrefab, reportPosition, reportRotation) as GameObject;
            reportSpawn.transform.SetParent(reportList.transform);
            reportSpawn.transform.localScale = Vector3.one;
           //setting the name for organization purposes
            reportSpawn.name = "ReportBlock" + rpt.ReportNumber.ToString();

            //and set the text to the problems to the report
            //also set the day text based on the day count
            reportSpawn.transform.FindChild("Report").GetComponent<Text>().text = "\"" + rpt.ReportText + "\""; 
            reportSpawn.transform.FindChild("DayNumber").GetComponent<Text>().text = "Report From Day " + rpt.ReportNumber;
        }
    }

}