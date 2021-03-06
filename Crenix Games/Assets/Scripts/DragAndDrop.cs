﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Implementação das interfaces que permitem a mecânica de arrastar (drag):
public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GearPlace gearPlace; //Identifica em qual local a engrenagem sendo movida foi colocada.
    public Sprite gearOutOfPlace;
    public Sprite gearInPlace;

    [SerializeField]
    private Canvas _canvas; 

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Image _image;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData) // Ações a serem feitas ao iniciar o "arrastamento" do objeto.
    {
        _canvasGroup.blocksRaycasts = false; // Retira o bloqueio do raycast quando estamos arrastando o objeto. Isso permite que outro evento ocorra abaixo do objeto. No caso, permite que o método OnDrop(), na classe GearPlace, traga o objeto para o mesmo ponto de ancoramento do local de engrenagem.
        if (gearPlace != null) // Ações feitas caso a engrenagem esteja posicionada em um local de engrenagem.
        {
            // Ao clicarmos na engrenagem posicionada, a engrenagem recebe o tamanho e sprite iniciais (gearOutOfPlace) e o local de engrenagem entende que não há mais engrenagem ali e remove qualquer associação entre a engrenagem arrastada e o local de engrenagem:
            _image.sprite = gearOutOfPlace;
            transform.localScale = new Vector3(1, 1, 1);
            gearPlace.hasGear = false; 
            gearPlace.gear = null;
            gearPlace = null;
        };
    }

    void IDragHandler.OnDrag(PointerEventData eventData) // Ações a serem feitas quando o objeto é arrastado.
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor; // Faz a engrenagem seguir o cursor.
    }

    public void OnEndDrag(PointerEventData eventData) // Ações a serem feitas quando o objeto terminar de ser arrastado.
    {
        _canvasGroup.blocksRaycasts = true; // Ao soltarmos a engrenagem, ela volta a bloquear raycasts, permitindo ser selecionada novamente. Além disso, o bloqueio do raycast impede que duas engrenagens sejam colocadas ao mesmo tempo em um mesmo local de engrenagem.
    }

    public void OnPointerDown(PointerEventData eventData) // Ações a serem feitas ao clicar no objeto.
    {

    }

}
