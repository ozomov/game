using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManger : MonoBehaviour
{
    public NeedsController NeedsController;
    public static PetManger instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetManager in the scene");
    }
public void Die()// Смерть
    {

    }
}
