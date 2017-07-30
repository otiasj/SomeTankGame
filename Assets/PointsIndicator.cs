using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsIndicator : MonoBehaviour {
    public GameObject titleText;
    public GameObject column1;
    public GameObject column2;

    public void setTitle(string text)
    {
        titleText.GetComponent<GUIText>().text = text;
    }

    public void setColumn1(string text)
    {
        column1.GetComponent<GUIText>().text = text;
    }

    public void setColumn2(string text)
    {
        column2.GetComponent<GUIText>().text = text;
    }


}
