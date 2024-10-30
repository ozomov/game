using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public Animator petAnimator;//Анимации
    private void Awake()
    {

    }

    public void Happy()// Переключение на анимацию счастья
    {
        petAnimator.SetTrigger("Happy");
    }

    public void Hungry()// Переключение на анимацию голода
    {
        petAnimator.SetTrigger("Hungry");
    }

    public void Sad()// Переключение на анимацию грусти
    {
        petAnimator.SetTrigger("Sad");
    }

    public void Tired()// Переключение на анимацию усталости
    {
        petAnimator.SetTrigger("Tired");
    }

    public void Eat()// Переключение на анимацию еды
    {
        petAnimator.SetTrigger("Eat");
    }

}
