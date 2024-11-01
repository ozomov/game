using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int food, happiness, energy;//���, ����������, �������
    public int foodTickRate, happinessTickRate, energyTickRate;// ��� ���, ����������, �������
    public DateTime lastTimeFed, lastTimeHappy, lastTimeGainedEnegry;//������
    private void Awake()
    {
        initialize(100, 100, 100, 3, 1, 2);
    }

    public void initialize(int food, int happiness, int energy, int foodTickRate, int happinessTickRate, int energyTickRate)
    {
        lastTimeFed = DateTime.Now;
        lastTimeHappy = DateTime.Now;
        lastTimeGainedEnegry = DateTime.Now;
        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;
        PetUIController.instance.UpdateImages(food, happiness, energy);
    }

    public void initialize
        (int food, int happiness, int energy,
        int foodTickRate, int happinessTickRate, int energyTickRate,
        DateTime lastTimeFed, DateTime lastTimeHappy, DateTime lastTimeGainedEnegry)
    {
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeGainedEnegry = lastTimeGainedEnegry;
        this.food = food - foodTickRate * TickAmountSinceLastTimeToCurrentTime(lastTimeFed, TimingManager.instance.hourLength);
        this.happiness = happiness - happinessTickRate * TickAmountSinceLastTimeToCurrentTime(lastTimeHappy, TimingManager.instance.hourLength);
        this.energy = energy - energyTickRate * TickAmountSinceLastTimeToCurrentTime(lastTimeGainedEnegry, TimingManager.instance.hourLength);
        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;
        if (this.food < 0) this.food = 0;
        if (this.happiness < 0) this.happiness = 0;
        if (this.energy < 0) this.energy = 0;
        PetUIController.instance.UpdateImages(this.food, this.happiness, this.energy);
    }
    private void Update()//����� ���-�� ���, ���������� � ������� ������ � �������
    {
        if (TimingManager.instance.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeEnegry(-energyTickRate);
            PetUIController.instance.UpdateImages(food, happiness, energy);
        }
    }

    public void ChangeFood(int amount)// ���� ���������, �� + ���. ���� ��� ����� < 0, �� ������ � ���� ��� ����� > 100, �� ��� = 100, ����� �� ����� �� �������
    {
        food += amount;
        if (amount > 0)
        {
            lastTimeFed = DateTime.Now;
        }
        if (food < 0)
        {
            PetManger.instance.Die();
        }
        else if (food > 100) food = 100;

    }
    public void ChangeHappiness(int amount)// ���� ������� ����������, �� ����������+. ���� ���������� ����� < 0, �� ������ � ���� ���������� ����� > 100, �� ���������� = 100, ����� �� ����� �� �������
    {
        happiness += amount;
        if (amount > 0)
        {
            lastTimeHappy = DateTime.Now;
        }
        if (happiness < 0)
        {
            PetManger.instance.Die();
        }
        else if (happiness > 100) happiness = 100;
    }
    public void ChangeEnegry(int amount)// ���� ������� �������, �� �������+. ���� ������� ����� < 0, �� ������ � ���� ������� ����� > 100, �� ������� = 100, ����� �� ����� �� �������
    {
        energy += amount;
        if (amount > 0)
        {
            lastTimeGainedEnegry = DateTime.Now;
        }
        if (energy < 0)
        {
            PetManger.instance.Die();
        }
        else if (energy > 100) energy = 100;
    }

    public int TickAmountSinceLastTimeToCurrentTime(DateTime lastTime, float tickRateInSeconds)//��������� ����� ��������� ��� ������� ���� � ���� �� ������ ��� ���������� � ������� ����������� 
    {
        DateTime currentDateTime = DateTime.Now;
        int dayOfYearDifference = currentDateTime.DayOfYear - lastTime.DayOfYear;
        if (currentDateTime.Year > lastTime.Year || dayOfYearDifference > 7) return 1500;// ���� ������� ������ � ������� ���������� ��������� = ������

        int dayDifferenceSecondsAmount = dayOfYearDifference * 86400;
        if (dayOfYearDifference > 0) return Mathf.RoundToInt(dayDifferenceSecondsAmount / tickRateInSeconds);

        int hourDifferenceSecondsAmount = (currentDateTime.Hour - lastTime.Hour) * 3600;
        if (hourDifferenceSecondsAmount > 0) return Mathf.RoundToInt(hourDifferenceSecondsAmount / tickRateInSeconds);

        int minuteDifferenceSecondsAmount = (currentDateTime.Minute - lastTime.Minute) * 60;
        if (minuteDifferenceSecondsAmount > 0) return Mathf.RoundToInt(minuteDifferenceSecondsAmount / tickRateInSeconds);

        int secondsDifferenceAmount = currentDateTime.Second - lastTime.Second;
        return Mathf.RoundToInt(secondsDifferenceAmount / tickRateInSeconds);

    }
} 
