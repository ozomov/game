using System;

[Serializable]
public class Pet
{
    public string lastTimeFed, lastTimeHappy, lastTimeGainedEnegry;
    public int food, happiness, energy;

    public Pet(string lastTimeFed, string lastTimeHappy, string lastTimeGainedEnegry, int food, int happiness, int energy)
    {
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeGainedEnegry = lastTimeGainedEnegry;
        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
    }
}
