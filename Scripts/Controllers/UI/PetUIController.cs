using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image foodImage, happinessImage, energyImage;
    public static PetUIController instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetUIController in the scene");
    }
    public void UpdateImages(int food, int happiness, int energy)
    {
        foodImage.fillAmount = (float) food / 100;
        happinessImage.fillAmount = (float) happiness / 100;
        energyImage.fillAmount = (float) energy / 100;
    }
}
