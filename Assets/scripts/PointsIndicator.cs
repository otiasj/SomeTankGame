using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsIndicator : MonoBehaviour {
    public GameObject titleText;
    public GameObject column1;
    public GameObject column2;
    public GameObject column3;

    public void setTitle(string text)
    {
        titleText.GetComponent<Text>().text = text;
    }

    public void setColumn1(string text)
    {
        column1.GetComponent<Text>().text = text;
    }

    public void setColumn2(string text)
    {
        column2.GetComponent<Text>().text = text;
    }

    public void setColumn3(string text)
    {
        column3.GetComponent<Text>().text = text;
    }
}
