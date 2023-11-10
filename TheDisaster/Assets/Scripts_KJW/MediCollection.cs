using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediCollection : MonoBehaviour
{
    public MediRecipe mediRecipe;

    private void Start()
    {
        mediRecipe = GetComponent<MediRecipe>();
        if (!PlayerPrefs.HasKey(mediRecipe.medisList[0].name))
        {
            CollectionReset();
        }
    }

    // 0�̸� �÷��� ���, 1�̸� �÷��� ����
    private void CollectionReset()
    {
        for(int i = 0; i<mediRecipe.medisList.Length; i++) 
        {
            PlayerPrefs.SetInt(mediRecipe.medisList[i].name, 0);
        }
    }
}
