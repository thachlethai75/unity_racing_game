using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCar : MonoBehaviour
{
    public GameObject Car1;
    public GameObject Car2;
    public GameObject Car3;
    public GameObject Car4;
    public GameObject carSelectMenu;
    public GameObject maincamera;
    public GameObject camera1;
    public GameObject lapcountpanel;
    public GameObject minimapcam;
    public GameObject AIcars;
    public GameObject checkpointcheck;
    public GameObject pausesystem;
    
    void Awake()
    {
        Time.timeScale = 0;
    }

    public void car1Active()
    {
        Car1.SetActive(true);
        ActivateComponent();
       
    }

     public void car2Active()
    {
        Car2.SetActive(true);
        ActivateComponent();
       
    }

     public void car3Active()
    {
        Car3.SetActive(true);
        ActivateComponent();
       
    }

     public void car4Active()
    {
        Car4.SetActive(true);
        ActivateComponent();
       
    }


    public void ActivateComponent()
    {
        carSelectMenu.SetActive(false);
        maincamera.SetActive(true);
        AIcars.SetActive(true);
        checkpointcheck.SetActive(true);
        minimapcam.SetActive(true);
        pausesystem.SetActive(true);
        camera1.SetActive(false);
        lapcountpanel.SetActive(true);

    }
}
