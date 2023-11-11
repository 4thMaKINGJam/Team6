using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediCollection : MonoBehaviour
{
    public MediRecipe mediRecipe;
    private GameObject[] medis = new GameObject[21];

    private void Start()
    {
        mediRecipe = GetComponent<MediRecipe>();
        if (!PlayerPrefs.HasKey(mediRecipe.medisList[0].name))
        {
            CollectionReset();
        }
        else ShowMediCollection();
    }

    // 0�̸� �÷��� ���, 1�̸� �÷��� ����
    private void CollectionReset()
    {
        for(int i = 0; i<mediRecipe.medisList.Length; i++) 
        {
            PlayerPrefs.SetInt(mediRecipe.medisList[i].name, 0);
        }
    }

    private void ShowMediCollection()
    {
        // �ڽ� ������Ʈ ��� ����
        for(int i = 0; i<mediRecipe.medisList.Length; i++)
        {
            medis[i] = transform.GetChild(i).gameObject;
        }
        // sprite ����
        for(int i=0; i<mediRecipe.medisList.Length; i++)
        {
            if (PlayerPrefs.GetInt(mediRecipe.medisList[i].name) == 1) // ������
                medis[i].GetComponent<MediForCollection>().Show();
        }

    }
}
