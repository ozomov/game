using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public float gameHourTimer;//Текущее время
    public float hourLength;//Начальное время

    public static TimingManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one TimingManager in the scene");
    }
    public void Update()//Если текущее время <= 0, то текущее игровое время = начальному времени, иначе текущее время уменьшается на тайм дельта
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
