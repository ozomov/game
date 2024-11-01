using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Sprite[] backs, middles, middleBacks, fronts;//������� ��������
    public SpriteRenderer[] backsRenderer, middlesRenderer, middleBacksRenderer, frontsRenderer;//����������� ���. �������

    private void Start()
    {
        RandomizeBackground();
    }

    public void RandomizeBackground()//��������� ����� ����
    {
        ChooseGraphicForRenderers(backsRenderer, backs);
        ChooseGraphicForRenderers(middlesRenderer, middles);
        ChooseGraphicForRenderers(middleBacksRenderer, middleBacks);
        ChooseGraphicForRenderers(frontsRenderer, fronts);
    }

    private void ChooseGraphicForRenderers(SpriteRenderer[] spriteRenderers, Sprite[] sprites)// �������� ��� ������� � ������ ������� � ����� ����������
    {
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}
