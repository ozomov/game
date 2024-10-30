using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int food, happiness, energy;//���, ����������, �������
    public int foodTickRate, happinessTickRate, energyTickRate;// ��� ���, ����������, �������
    public DateTime lastTimeFed, lastTimeHappy, lastTimeGainedEnegry;

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
        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.foodTickRate = 3;
        this.happinessTickRate = 2;
        this.energyTickRate = 1;
        PetUIController.instance.UpdateImages(food, happiness, energy);
    }
    private void Update()//����� ���-�� ���, ���������� � ������� ������ � �������
    {
        if (TimingManager.gameHourTimer < 0)
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
}