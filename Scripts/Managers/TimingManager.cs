using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public float gameHourTimer;//������� �����
    public float hourLength;//��������� �����

    public static TimingManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one TimingManager in the scene");
    }
    public void Update()//���� ������� ����� <= 0, �� ������� ������� ����� = ���������� �������, ����� ������� ����� ����������� �� ���� ������
    {
        if (gameHourTimer <= 0)
        {
            gameHourTimer = hourLength;
        }
        else
        {
            gameHourTimer -= Time.deltaTime;
        }
    }
}
