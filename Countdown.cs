using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public GameObject Carcontrol;
    public GameObject CountdownUI;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountStar());
    }

    IEnumerator CountStar()
    {
        yield return new WaitForSeconds(0.5f);
        CountdownUI.GetComponent<Text>().text = "3";
        yield return new WaitForSeconds(1.0f);
        CountdownUI.GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1.0f);
        CountdownUI.GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1.0f);
        CountdownUI.GetComponent<Text>().text = "GO";
        yield return new WaitForSeconds(1.0f);
        CountdownUI.SetActive(false);
        Carcontrol.SetActive(false);
    }
}
