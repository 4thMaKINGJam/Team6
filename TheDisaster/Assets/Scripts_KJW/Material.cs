using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public MediManager mediManager;

    private void Start()
    {
        mediManager = GameObject.Find("MediManager").GetComponent<MediManager>();
    }

    public void ClickMaterialButton()
    {
        // �Ŵ��� ��� �迭 �ι�°�� �������� ����
            // �ؽ�Ʈ ������Ʈ
            // �Ŵ����� ��� �迭�� �߰� (ù��° �������� �ι�°)
    }


}
