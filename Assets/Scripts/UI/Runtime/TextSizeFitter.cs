using UnityEngine;

using TMPro;

namespace UI.Runtime
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [ExecuteInEditMode]
    public class TextSizeFitter : MonoBehaviour
    {
        [SerializeField] private int maxWidth = 300;
        private TextMeshProUGUI _text;
        private RectTransform _rectTransform;
        private int _lastCharCount;

        public void OnValidate()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            var currCharCount = _text.textInfo.characterCount;
            if (_lastCharCount != currCharCount)
            {
                SetSizeToFitCharacters(_text, _rectTransform, maxWidth);
                _lastCharCount = currCharCount;
            }
        }

        private static void SetSizeToFitCharacters(TMP_Text text, RectTransform textRectTransform, int maxWidth)
        {
            var preferredWidth = Mathf.Clamp(text.GetPreferredValues().x, 0, maxWidth);

            textRectTransform.sizeDelta = new Vector2(preferredWidth, textRectTransform.sizeDelta.y);
        }
    }
}