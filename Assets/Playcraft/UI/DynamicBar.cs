using UnityEngine;

namespace Playcraft
{
    public class DynamicBar : MonoBehaviour
    {
        enum FillType { Horizontal, Vertical }

        #pragma warning disable 0649
        [SerializeField] RectTransform rect;
        [SerializeField] Vector2 maxSize;
        [SerializeField] FillType fillType;
        #pragma warning restore 0649
        
        public void SetFill(float fill)
        {
            var x = maxSize.x;
            var y = maxSize.y;
            
            switch (fillType)
            {
                case FillType.Horizontal:
                    x = maxSize.x * fill;
                    break;
                case FillType.Vertical:
                    y = maxSize.y * fill;
                    break;
            }
        
            rect.sizeDelta = new Vector2(x, y);        
        }
    }
}
