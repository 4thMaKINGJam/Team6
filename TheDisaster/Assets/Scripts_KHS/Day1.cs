using UnityEngine;
using UnityEngine.SceneManagement;

public class Day1 : MonoBehaviour
{
    public void SkipToDay1Scene()
    {
        // "Day1"�̶�� ������ �Ѿ�ϴ�.
        GameManager.Instance.FadeOut();
        SceneManager.LoadScene("Day1");
    }
}
