using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Criado apenas para localizar a posição inicial das engrenagens.
public class Gear : MonoBehaviour
{
    public Vector2 initialPosition;

    private void Awake()
    {
        initialPosition = this.GetComponent<RectTransform>().anchoredPosition;
    }
}
