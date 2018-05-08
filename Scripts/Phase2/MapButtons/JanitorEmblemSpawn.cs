using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JanitorEmblemSpawn : MonoBehaviour
{

    [SerializeField]
    private List<Transform> janitorSpawns = new List<Transform>();
    [SerializeField]
    private GameObject janitorEmblem;
    
    public bool JanitorProblem { get; set; }
    public bool JanitorSpawned { get; set; }

    void Start ()
    { janitorEmblem.SetActive(false); }
	
	void Update ()
    {
        //will probbaly make this an event later
        //but this will make a random spawn point
        //and spawn the janitor emblem if this bool is true
	    if(JanitorProblem && !JanitorSpawned)
        {
            janitorEmblem.SetActive(true);
            janitorEmblem.transform.position = janitorSpawns[GetRandomSpawnPoint()].position;
            JanitorProblem = true;
	    JanitorSpawned = true;	
        }
	}

    private int GetRandomSpawnPoint()
    {
        int random = Random.Range(0, janitorSpawns.Count);
        return random;
    }

    public void HideJanitor()
    {
	JanitorSpawned = false;	
        janitorEmblem.SetActive(false);
        JanitorProblem = false;
    }
}
