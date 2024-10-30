using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Sprite[] backs, middles, middleBacks, fronts;//Фоновые текстуры
    public SpriteRenderer[] backsRenderer, middlesRenderer, middleBacksRenderer, frontsRenderer;//Отображение опр. спрайта

    private void Start()
    {
        RandomizeBackground();
    }

    public void RandomizeBackground()//Случайный выбор фона
    {
        ChooseGraphicForRenderers(backsRenderer, backs);
        ChooseGraphicForRenderers(middlesRenderer, middles);
        ChooseGraphicForRenderers(middleBacksRenderer, middleBacks);
        ChooseGraphicForRenderers(frontsRenderer, fronts);
    }

    private void ChooseGraphicForRenderers(SpriteRenderer[] spriteRenderers, Sprite[] sprites)// Обобщаем все спрайты и спрайт рендеры в общие переменные
    {
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}
