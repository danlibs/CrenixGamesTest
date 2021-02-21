using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Implementação do botão reset:
public class ResetButton : MonoBehaviour
{
    private DragAndDrop[] _gearCheck;
    private Gear[] _gears;
    private GearPlace[] _gearPlaces;


    private void Start()
    {
        _gears = GameObject.FindObjectsOfType<Gear>(); // Busca as engrenagens para verificar sua posição inicial.
        _gearCheck = GameObject.FindObjectsOfType<DragAndDrop>(); // Busca as engrenagens para verificar a indicação, nelas, dos locais de engrenagem que foram colocadas. 
        _gearPlaces = GameObject.FindObjectsOfType<GearPlace>(); // Busca os locais de engrenagem.
    }

    // Método chamado ao apertar o botão reset:
    public void ResetGears()
    {
        foreach (GearPlace item in _gearPlaces) // Para os locais de engrenagem, coloca a indicação de presença de engrenagem como "false" e remove qualquer referência à engrenagem que estava ali.
        {
            item.hasGear = false;
            item.gear = null;
        }

        foreach (DragAndDrop item in _gearCheck) // Remove de todas as engrenagens a referência ao local de engrenagem em que estavam e muda seu sprite e seu tamanho para o inicial.
        {
            item.gearPlace = null;
            item.gameObject.GetComponent<Image>().sprite = item.gearOutOfPlace;
            item.transform.localScale = new Vector3(1, 1, 1);
        }

        foreach (Gear engrenagem in _gears) // Traz todas as engrenagens para sua posição de ancoramento inicial.
        {
            engrenagem.GetComponent<RectTransform>().anchoredPosition = engrenagem.initialPosition;
        }
    }

}
