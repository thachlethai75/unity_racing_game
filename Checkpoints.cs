using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Checkpoints : MonoBehaviour
{
    [HideInInspector]
    public GameObject car;
    [HideInInspector]
    public GameObject AIcar1;

    public GameObject lapcountMenu;
    [HideInInspector]
    public int AIcarslap = 0;
    public int lapcount;
    public GameObject winMsg;
    public GameObject lossMsg;
    [HideInInspector]
    public int lap = 0;
    [HideInInspector]
    public int checkpoint = -1;
    int checkpointCount;
    int nextCheckpoint = 0;
    Dictionary<int, bool> visited = new Dictionary<int, bool>();
    public Text lapText;
    [HideInInspector]
    public bool missed = false;
    public GameObject PrevCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player");
        AIcar1 = GameObject.FindGameObjectWithTag("AIcar1");
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        checkpointCount = checkpoints.Length;

        foreach(GameObject chpoint in checkpoints)
        {
            if (chpoint.name == "0")
            {
                PrevCheckpoint = chpoint;
                break;
            }
        }

        foreach(GameObject cp in checkpoints)
        {
            visited.Add(Int32.Parse(cp.name), false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            int checkpointCurrent = int.Parse(other.gameObject.name);
            if (checkpointCurrent == nextCheckpoint)
            {
                PrevCheckpoint = other.gameObject;
                visited[checkpointCurrent] = true;
                checkpoint = checkpointCurrent;
                if (checkpoint == 0 && gameObject.tag == "Player")
                {
                    lap++;
                    lapText.text = "Lap:" + lap + "/" + lapcount;
                }
                else if (checkpoint == 0 && gameObject.tag == "AIcar1")
                {
                    AIcarslap++;
                }

                nextCheckpoint++;
                if(nextCheckpoint >= checkpointCount)
                {
                    var keys = new List<int>(visited.Keys);
                    foreach(int key in keys)
                    {
                        visited[key] = false;
                    }
                    nextCheckpoint = 0;
                }
            }
            else if (checkpointCurrent != nextCheckpoint && visited[checkpointCurrent] == false)
            {
                missed = true;
            }
        }

        if (other.gameObject.tag == "Finish")
        {
            if (lap == (lapcount +1) && gameObject.tag == "Player")
            {
                winMsg.SetActive(true);
                lapText.text = "you win";
                stopcars();
                Time.timeScale = 0;
            }
            else if (AIcarslap == (lapcount +1) && gameObject.tag == "AIcar1")
            {
                lapText.text = "you loss";
                lossMsg.SetActive(true);
                stopcars();
                Time.timeScale = 0;
            }
        }
    }
    public void stopcars()
    {
        car.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 0;
        car.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 0;

        AIcar1.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 0;
        AIcar1.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 0;

        car.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_Topspeed = 0;
        car.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_ReverseTorque = 0;

        AIcar1.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_Topspeed = 0;
        AIcar1.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_ReverseTorque = 0;
    }

    public void lap1()
    {
        lapscount(1);
        Time.timeScale = 1;
        lapcountMenu.SetActive(false);
    }
      public void lap2()
    {
        lapscount(2);
        Time.timeScale = 1;
        lapcountMenu.SetActive(false);
    }
      public void lap3()
    {
        lapscount(3);
        Time.timeScale = 1;
        lapcountMenu.SetActive(false);
    }

    public int lapscount( int lap)
    {
        lapcount = lap;
        return lapcount;
    }
}
