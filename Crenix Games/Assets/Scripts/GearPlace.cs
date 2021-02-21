using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GearPlace : MonoBehaviour, IDropHandler
{
    public bool hasGear;
    public DragAndDrop gear;

    public void OnDrop(PointerEventData eventData) // Açõs a serem feitas quando soltamos (drop) um objeto arrastado.
    {
        if (eventData.pointerDrag != null) // Se houver algo sendo solto:
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; // A engrenagem solta vai para a mesma posição de ancoramento que este objeto.
            hasGear = true; // Sinaliza que há uma engrenagem aqui.
            gear = eventData.pointerDrag.GetComponent<DragAndDrop>(); // Indica qual a engrenagem que está aqui.
            gear.gearPlace = GetComponent<GearPlace>(); // Indica para a engrenagem em qual local de engranagem ela está.
            gear.gameObject.GetComponent<Image>().sprite = gear.gearInPlace; // Muda o sprite da engrenagem.
            gear.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); // Aumenta o tamanho do sprite da engrenagem.
        }
        
    }
}
