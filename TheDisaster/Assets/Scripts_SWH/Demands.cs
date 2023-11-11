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
    public bool isSecond;
    //public List<int> mediNumList;
    public int demandCount; //�䱸���� �ؽ�Ʈ �ε���

    public string[] demandMsg;
    public string[] successMsg;
    public string[] fail1Msg;
    public string[] fail2Msg;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void NewDemand()
    {
        demandCount = 0;
        isSecond = false;

        //�Ƿ� �� ��ȣ
        for(int i=0; i<medi.Length; i++)
        {
            mediNum = Random.Range(0, medi.Length);
            int index = GameManager.Instance.demandsList.FindLastIndex(x => x == mediNum);

            //���ο� �Ƿ��� ���
            if (index == -1)
            {
                break;
            }
            //���� �Ƿ� �� ���� �Ƿ��� ���
            else if (index != -1)
            {
                if (GameManager.Instance.isSucess[index] == false)
                {
                    isSecond = true;
                    break;
                }
            }
        }

        //���� �Ƿ�
        if (isSecond)
        {
            GameManager.Instance.demandsList.Add(mediNum);
            demandText.text = "�̹��� �� �� �ְ���?";
        }
        //���� �Ƿ� �ƴ�
        else
        {
            GameManager.Instance.demandsList.Add(mediNum);

            //�Ƿ� �ؽ�Ʈ
            int i = Random.Range(0, demandMsg.Length);
            demandText.text = demandMsg[i];
        }
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
    }
}

[System.Serializable]
public class DemandsText
{
    public string[] demands;
}
