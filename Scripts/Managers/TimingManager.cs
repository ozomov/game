using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public static float gameHourTimer;//������� �����
    public float hourLength;//��������� �����
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