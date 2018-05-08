using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//notification class that holds the text of the notification
//and the number of that notification, which is basically the day the notification is instantiated on
public class Notification
{
    public string NotificationText
    { get; set; }
    public int NotificationNum
    { get; set; }
    public string Animal
    { get; set; }
    public string Happiness
    { get; set; }
    public string AddorSubtract
    { get; set; }

    public Notification(string notificationText, int notificationNumber, string animal, string happiness, string addOrSub)
    {
        NotificationText = notificationText;
        NotificationNum = notificationNumber;
        Animal = animal;
        Happiness = happiness;
        AddorSubtract = addOrSub;
    }
}

public class NotificationsDisplay : MonoBehaviour
{

    public List<string> NotificationsList = new List<string>();
    
    public List<Notification> DisplayedNotificationsList = new List<Notification>();

    private List<GameObject> Spawnednotifications = new List<GameObject>();

    public GameObject notificationPrefab;
    private GameObject notificationSpawn;
    public Transform notificationSpawnPoint;
    private Vector3 notificationPosition;
    private Quaternion notificationRotation;
    public GameObject notificationList;

    [SerializeField]
    private Text latestNotification;

    private string notification = null;
    private int displayedIndex = 0;

    [SerializeField]
    private DayCycleManager dayCycle;


    private string latestNotiAnimal;
    private string latestNotiHappyType;
    private string latestNotiAddorSub;

    public void NewNotification(string animal, string happinessType, string addOrSub)
    {
        //fill the lists
        PopulateLists(animal, happinessType, addOrSub);
        //display the objectives
        Displaynotifications();
    }

    void PopulateLists(string animal, string happinessType, string addOrSub)
    {
        string notification;

        notification = NotificationsList[Random.Range(0, NotificationsList.Count)];

        //creating a new class of the notification, containing the randomly generated notification
        //and the index increment
        Notification noti = new Notification(notification, displayedIndex, animal, happinessType, addOrSub);

        //then add it to the display list
        DisplayedNotificationsList.Add(noti);
        //then increment the index
        displayedIndex++;
    }

    void Displaynotifications()
    {
        //for each child in the children of the notification list
        //destroy it if it's a notification block
        foreach (Transform child in notificationList.transform)
        {
            if (child.name.StartsWith("notificationBlock"))
            {
                //Debug.Log("Destroying " + child.name);
                Destroy(child.gameObject);
            }
        }

        //then, for each notification class in displayed notifications
        //order the list by descending based on the notification number, so the newest comes first
        foreach (Notification noti in DisplayedNotificationsList.OrderByDescending(o => o.NotificationNum).ToList())
        {
            //set the positions and rotations
            notificationPosition = new Vector3(notificationSpawnPoint.position.x, notificationSpawnPoint.position.y, notificationSpawnPoint.position.z);
            notificationRotation = Quaternion.Euler(notificationSpawnPoint.rotation.x, notificationSpawnPoint.rotation.y, notificationSpawnPoint.rotation.z);
            notificationPosition.Set(notificationPosition.x, notificationPosition.y, notificationPosition.z);

            //and then spawn those objectives
            notificationSpawn = Instantiate(notificationPrefab, notificationPosition, notificationRotation) as GameObject;
            notificationSpawn.transform.SetParent(notificationList.transform);
            notificationSpawn.transform.localScale = Vector3.one;
            //setting the name for organization purposes
            notificationSpawn.name = "notificationBlock" + noti.NotificationNum.ToString();

            //and set the text to the problems to the notification
            //also set the day text based on the day count
            notificationSpawn.transform.FindChild("Notification").GetComponent<Text>().text = "" + noti.NotificationText +
                "" + noti.AddorSubtract +  " 5% to the " + noti.Animal + " " + noti.Happiness + " happiness level.";
            notificationSpawn.transform.FindChild("Number").GetComponent<Text>().text = "Notification # " + noti.NotificationNum;

            latestNotiAnimal = noti.Animal;
            latestNotiHappyType = noti.Happiness;
            latestNotiAddorSub = noti.AddorSubtract;
        }

        //the most recent notification should be displayed in the latest notification box
        latestNotification.text = latestNotiAddorSub + " 5% to the " + latestNotiAnimal + " " + latestNotiHappyType + " happiness level.";

    }

}
