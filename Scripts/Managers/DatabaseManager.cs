using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    private Database database;
    public NeedsController needsController;
    private void Awake()
    {
        database = new Database();
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one DataBaseManager in the scene");
    }

    private void Update()
    {
        if (TimingManager.instance.gameHourTimer < 0)
        {
            Pet pet = new Pet
                (needsController.lastTimeFed.ToString(),
                needsController.lastTimeHappy.ToString(),
                needsController.lastTimeGainedEnegry.ToString(),
                needsController.food,
                needsController.happiness,
                needsController.energy);
            SavePet(pet);
        }

    }

    private void Start()
    {
        Pet pet = LoadPet();
        if (pet != null)
        {
            needsController.initialize
                (pet.food,
                pet.happiness,
                pet.energy,
                3,1,2,
                DateTime.Parse(pet.lastTimeFed),
                DateTime.Parse(pet.lastTimeHappy),
                DateTime.Parse(pet.lastTimeGainedEnegry)
                );
        }
    }

    public void SavePet(Pet pet)
    {
        database.SaveData("pet", pet);
    }

    public Pet LoadPet()
    {
        Pet returnValue = null;
        database.LoadData<Pet>("pet", (pet) =>
        {
            returnValue = pet;
        });
        return returnValue;
    }
}
