using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscripts : MonoBehaviour
{
    GameObject Player;
    public GameObject missedcheckpointText;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Checkpoints>().missed == true)
        {
            StartCoroutine(showmissedcheckpointtext());
            Player.GetComponent<Checkpoints>().missed = false;
        }
    }

    IEnumerator showmissedcheckpointtext()
    {
        missedcheckpointText.SetActive(true);
        yield return new WaitForSeconds(10);
        missedcheckpointText.SetActive(false);
    }
}
