using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int dayNum;
    public int demandNum;
    public float totalScore;
    public float likeability;

    private string nextSceneStr;
    private Image fadePanel;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        totalScore = 0.0f;
        demandNum = 0;
        fadePanel = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        if (_instance == null)
        {
            _instance = this;
        }
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }

    public void CheckDemandNum()
    {
        if(demandNum == 3)
        {
            LoadScene("Day2");
        }
        if(demandNum == 6) 
        {
            LoadScene("Day3");
        }
        if (demandNum == 9)
        {
            LoadScene("Ending");
        }
    }

    public void LoadScene(string sceneName) 
    {
        nextSceneStr = sceneName;
        StartCoroutine(FadeOutCoroutine());
        Invoke("LoadSceneAfter1s", 1.5f);
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    IEnumerator FadeOutCoroutine()
    {
        float alpha = 0;
        while(alpha < 1.0f)
        {
            alpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0,0,0, alpha);
        }
    }

    IEnumerator FadeInCoroutine()
    {
        float alpha = 1;
        while (alpha > 0f)
        {
            alpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, alpha);
        }
    }

    void LoadSceneAfter1s()
    {
        SceneManager.LoadScene(nextSceneStr);
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        float alpha = 1;
        while (alpha > 0f)
        {
            alpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, alpha);
        }
    }

    void LoadSceneAfter1s()
    {
        SceneManager.LoadScene(nextSceneStr);
        StartCoroutine(FadeInCoroutine());
    }

    //���� ���ϱ�
    public void AddScore(int count)
    {
        if(count == 1)
        {
            likeability = 3.0f;
            totalScore += likeability;
        }
        else if(count == 2)
        {
            likeability = 2.0f;
            totalScore += likeability;
        }
        else if(count == 3)
        {
            likeability = 1.0f;
            totalScore += likeability;
        }
    }

}
