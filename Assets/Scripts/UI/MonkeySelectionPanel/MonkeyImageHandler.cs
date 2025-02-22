using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
    {
        private Image monkeyImage;
        private MonkeyCellController owner;
        private Sprite spriteToSet;
        private RectTransform rectTransform;
        private Vector3 originalPosition;
        private Vector3 originalAnchorPosition;

        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
        }      

        private void Awake()
        {
            monkeyImage = GetComponent<Image>();
            monkeyImage.sprite = spriteToSet;
            rectTransform = GetComponent<RectTransform>();
            originalAnchorPosition = rectTransform.anchoredPosition;
            originalPosition = rectTransform.position;


        }

       
        public void OnEndDrag(PointerEventData eventData)
        {
            ResetMokey();
            owner.MonkeyDroppedAt(eventData.position);
        }

        void ResetMokey()
        {
            rectTransform.anchoredPosition = originalAnchorPosition;
            rectTransform.position = originalPosition;
            GetComponent<LayoutElement>().enabled = false;
            GetComponent<LayoutElement>().enabled = true;
            monkeyImage.color = new Color(1, 1, 1, 1);

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            monkeyImage.color = new Color(1, 1, 1, 0.5f);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform,  // Reference to the parent UI element
                eventData.position,                     // Mouse position
                eventData.pressEventCamera,             // Camera that rendered the UI
                out localPoint                          // Converted local position
            );

            rectTransform.anchoredPosition = localPoint;
            owner.MonkeyDraggedAt(rectTransform.position);
        }
    }
}