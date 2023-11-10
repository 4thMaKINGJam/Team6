using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Demands : MonoBehaviour
{
    public Text demandText;
    public DemandText[] demands;
    public int demandNum;
    public int demandCount;

    // Start is called before the first frame update
    void Start()
    {
        demandCount = 0;
        demandNum = Random.Range(0, demands.Length);
        demandText.text = demands[demandNum].demandText[demandCount];
    }

    public void ShowDemandText()
    {
        demandCount++;
        Debug.Log(demands[demandNum].demandText.Length);
        if(demandCount > demands[demandNum].demandText.Length)
        {
            demandText.text = demands[demandNum].demandText[^1];
        }
        else
        {
            demandText.text = demands[demandNum].demandText[demandCount];
        }
    }
}

[System.Serializable]
public class DemandText
{
    public string[] demandText;
}
