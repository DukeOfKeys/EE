using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Friends : MonoBehaviour
{
    [SerializeField] public static string bff = null;

    void FixedUpdate()
    {
        if (bff == "Hero")
        {
            Dialog();
        }
    }
    
    private void Dialog()
    {
        Debug.Log("����������, ����������!!! � ���� ������� ������� � ������������� ���� ����������� � ������� ����������!!!!!!");
    }
}
