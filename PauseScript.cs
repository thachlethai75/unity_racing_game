using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject car;
    [HideInInspector]
    public GameObject AIcar1;
    public GameObject pauseMenu;
    int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player");
        AIcar1 = GameObject.FindGameObjectWithTag("AIcar1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (x == 0)
            {
                car.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 0;
                car.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 0;

                AIcar1.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 0;
                AIcar1.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 0;

                Time.timeScale = 0;
                x = 1;
                pauseMenu.SetActive(true);
            }
            else if (x == 1)
            {
                resume();
            }
        }
    }

    public void resume()
    {
        car.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 1;
        car.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 5;

        AIcar1.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 1;
        AIcar1.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 5;

        Time.timeScale = 1;
        x = 0;
        pauseMenu.SetActive(false);

    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
