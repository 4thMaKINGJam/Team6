using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDayText : MonoBehaviour
{
    private Text text;
    public string nextScene;

    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(TextAnimation(nextScene));
    }

    IEnumerator TextAnimation(string nextScene)
    {
        text.text = "���� ��";
        yield return new WaitForSeconds(1f);
        text.text = "���� ��.";
        yield return new WaitForSeconds(1f);
        text.text = "���� ��..";
        yield return new WaitForSeconds(1f);
        text.text = "���� ��...";
        yield return new WaitForSeconds(1f);
        GameManager.Instance.LoadScene(nextScene);
    }
}
