using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Runtime
{
    public class KeepItemsOnView : MonoBehaviour
    {
        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private int topPadding = 25;
        
        private RectTransform _viewport;
        private RectTransform _content;
        private GameObject _lastCurrentSelected;

        private void Awake()
        {
            if (scrollRect == null)
            {
                Debug.LogError($"{name}: {nameof(scrollRect)} is null!");
                return;
            }

            _viewport = scrollRect.viewport;
            _content = scrollRect.content;
        }

        private void OnEnable()
        {
            eventSystem ??= EventSystem.current;
            if (eventSystem == null)
            {
                Debug.LogError($"{name}: {nameof(eventSystem)} is null!" +
                               $"\nDisabling component");
                return;
            }

            _lastCurrentSelected = eventSystem.currentSelectedGameObject;
        }

        private void Update()
        {
            var current = eventSystem.currentSelectedGameObject;
            if (current == null || current == _lastCurrentSelected)
                return;
            _lastCurrentSelected = current;
            var selectedRect = _lastCurrentSelected.GetComponent<RectTransform>();
            if (!IsInView(_viewport, selectedRect.position))
            {
                SnapTo(scrollRect.transform, _content, selectedRect, topPadding);
            }
        }

        private static bool IsInView(RectTransform viewport, Vector2 position)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(viewport, position);
        }

        private static void SnapTo(Transform scrollRectTransform,
                                   RectTransform content,
                                   RectTransform target,
                                   int topPadding)
        {
            Canvas.ForceUpdateCanvases();

            var anchoredPosition = content.anchoredPosition;
            anchoredPosition.y =
                (
                    scrollRectTransform.InverseTransformPoint(content.position) -
                    scrollRectTransform.InverseTransformPoint(target.position)
                ).y
                - target.sizeDelta.y / 2
                - topPadding;
            content.anchoredPosition = anchoredPosition;
            
        }
    }
}