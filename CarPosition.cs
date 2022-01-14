using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarPosition : MonoBehaviour
{
    public GameObject PositionText;
    public int pos = 2;
    bool x = true;
    bool y = true;
    bool z = true;
    bool p = false;
    bool q = false;
    bool r = false;
    

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "posup1" && pos > 1 && x == true)
        {
            pos = pos - 1;
            PositionText.GetComponent<Text>().text = "position:" + pos + "/2";
            x = false;
            p = true;
        }
        else if (other.tag == "posDown1" && p == true)
        {
            pos = pos + 1;
            PositionText.GetComponent<Text>().text = "position:" + pos + "/2";
            p = false;
            x = true;
        }
    }
    
}
