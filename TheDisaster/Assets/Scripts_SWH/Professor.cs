using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Professor : MonoBehaviour
{
    public GameObject demand;
    public GameObject answer1;
    public GameObject answer2;

    // Start is called before the first frame update
    void Start()
    {
        NewProfessor();
    }

    //���ο� �Ƿ� �ޱ�
    public void NewProfessor()
    {
        GameManager.Instance.demandNum++;
        if(GameManager.Instance.demandNum > 3)
        {
            Debug.Log("���� �Ϸ� �Ƿ� ��!");
        }
        StartCoroutine("ShowDemandText");
        demand.GetComponent<Demands>().NewDemand();
    }

    //ó���� ��ǳ�� ����
    IEnumerator ShowDemandText()
    {
        yield return new WaitForSeconds(1.0f);
        demand.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        answer1.SetActive(true);
        answer2.SetActive(true);
    }

    //�䱸 ���� ���� �� ��ǳ�� ����(��ư)
    public void InactiveDemandUI()
    {
        //�Ƿ� ����
        if(answer2.GetComponentInChildren<Text>().text == "�װ� �� ����� �� �����ϴ� ������")
        {
            NewProfessor();
            demand.SetActive(false);
        }

        //demand.SetActive(false);
        answer1.SetActive(false);
        answer2.SetActive(false);
    }

    //�� ���� ��ư Ŭ�� �� ���� ��(��ư)
    public void CompareMedi()
    {
        StartCoroutine("SubmitMedi");
    }

    IEnumerator SubmitMedi()
    {
        MediManager mediManager = GameObject.Find("MediManager").GetComponent<MediManager>();
        Demands demandMedi = GameObject.Find("Demand").GetComponent<Demands>();

        if (mediManager.makedMedi.name == demandMedi.mediNum.ToString())
        {
            Debug.Log("���� ����!");
            GameManager.Instance.AddScore(demandMedi.demandCount);
            StopCoroutine("ShowDemandText");
            
            InactiveDemandUI();
            mediManager.makingAni.SetActive(false);
            demandMedi.demandText.text = "�� ����~";

            yield return new WaitForSeconds(2.0f);
            demand.SetActive(false);

            Invoke("NewProfessor", 2.0f);
        }
        else
        {
            Debug.Log("���� ����!");
            StopCoroutine("ShowDemandText");

            InactiveDemandUI();
            mediManager.makingAni.SetActive(false);
            demandMedi.demandText.text = "�̰� ����! �峭��?";

            yield return new WaitForSeconds(2.0f);
            demand.SetActive(false);
            Invoke("NewProfessor", 2.0f);
        }
    }
}
