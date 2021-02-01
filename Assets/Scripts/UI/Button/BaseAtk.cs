using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseAtk : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   public bool isHitting;

   public virtual void OnPointerDown(PointerEventData eventData)
   {
       isHitting = true;
   }

   public void OnPointerUp(PointerEventData eventData)
   {
       isHitting = false;
   }
}
