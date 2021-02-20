using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Controle dos slots onde as engrenagens iniciam.
public class GearSlots : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) // Caso movamos uma engrenagem para perto do slot, ele puxa-a para sua posição de ancoramento.
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
