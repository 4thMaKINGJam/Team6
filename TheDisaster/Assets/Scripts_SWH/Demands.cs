using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demands : MonoBehaviour
{
    public Text demandText;
    public Text answer1Text;
    public Text answer2Text;
    public DemandsText[] medi;
    public int mediNum;     //�� ��ȣ(0~20)
    public int demandCount; //�䱸���� �ؽ�Ʈ �ε���
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void NewDemand()
    {
        demandText.text = "�ڳ�, �� �� �ϳ��� �������";
        answer1Text.text = "��.. ��..";
        answer2Text.text = "�װ� ����� �� �����ϴ� ������";
        demandCount = 0;
        mediNum = Random.Range(0, medi.Length);
        //demandText.text = medi[mediNum].demands[demandCount];
    }
    public void PrintDemands()
    {
        //Debug.Log(medi[mediNum].demands.Length);
        if(demandCount > medi[mediNum].demands.Length - 1)
        {
            demandText.text = medi[mediNum].demands[^1];
            demandCount--;
        }
        else
        {
            demandText.text = medi[mediNum].demands[demandCount];
        }
        demandCount++;
        answer1Text.text = "��?";
        answer2Text.text = "�� �����մϴ� ������!";
    }
}

[System.Serializable]
public class DemandsText
{   
    public string[] demands;
}
