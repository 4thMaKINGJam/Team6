using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediManager : MonoBehaviour
{
    private MediRecipe mediRecipe;
    public Medi makedMedi;
    public int[] selectedMaterial = new int[2];
    public Text[] selectedText;


    private void Start()
    {
        ResetMaterials();
        mediRecipe = GetComponent<MediRecipe>();
    }

    //����
    public void ResetMaterials()
    {
        // 99�� null ��� ���
        selectedMaterial[0] = 99;
        selectedMaterial[1] = 99;
        selectedText[0].text = "";
        selectedText[1].text = "";
    }

    //����
    public void Combination()
    {
        if(selectedMaterial[1] == 99) // ��� �� �ʿ�
        {
            Debug.Log("��� �� �ʿ�");
        }
        makedMedi = mediRecipe.makeMedi(selectedMaterial[0], selectedMaterial[1]);
        Debug.Log(makedMedi.name);
        ResetMaterials();
        // �÷��� ��� ���� 
        PlayerPrefs.SetInt(makedMedi.name, 1);
        //// for debug
        //for(int i = 0; i < mediRecipe.medisList.Length; i++)
        //{
        //    Debug.Log(PlayerPrefs.GetInt(mediRecipe.medisList[i].name));
        //}
        

        // ����� �ִϸ��̼� Start
        // �ش� �� �Ƿ� ��ũ��Ʈ�� �ѱ�
    }
}
