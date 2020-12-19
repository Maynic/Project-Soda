using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

 
public class ButtonSelector : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //do your stuff when highlighted
        gameObject.GetComponent<Button>().Select();
    }
    public void OnSelect(BaseEventData eventData)
    {
        //do your stuff when selected
    }
}
  