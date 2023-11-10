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
    public int likeability;


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
            FadeOut();
            SceneManager.LoadScene("Day2");
        }
        if(demandNum == 6) 
        {
            FadeOut();
            SceneManager.LoadScene("Day3");
        }
        if (demandNum == 9)
        {
            SceneManager.LoadScene("Ending");
        }
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
}
