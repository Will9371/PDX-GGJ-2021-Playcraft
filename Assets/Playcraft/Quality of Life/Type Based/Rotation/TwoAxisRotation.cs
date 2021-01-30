using UnityEngine;

namespace Playcraft
{
    public class TwoAxisRotation : MonoBehaviour
    {
        #pragma warning disable 0649
        [SerializeField] bool invertX;
        [SerializeField] bool invertY = true;
        [SerializeField] bool clampX;
        [Tooltip("Combine with xRange (-90,90) to maintain consistent UI when upside down")]
        [SerializeField] bool flipXWhenOutOfRange;
        [Tooltip("Set to -90, 90 for full range of motion")]
        [SerializeField] Vector2 xRange;
        [SerializeField] bool clampY;
        [SerializeField] Vector2 yRange;
        [SerializeField] Transform self;
        #pragma warning restore 0649
        
        float x, y;
        
        bool xOutOfRange => x < xRange.x || x > xRange.y;
        bool _invertX => flipXWhenOutOfRange && xOutOfRange ? !invertX : invertX;
        
        void Awake() { if (!self) self = transform; }

        public void Rotate(Vector2 value)
        {
            x += value.y * (invertY ? -1f : 1f);
            y += value.x * (_invertX ? -1f : 1f);
            
            if (clampX) x = RangeMath.ApplyMinMax(x, xRange);
            if (clampY) y = RangeMath.ApplyMinMax(y, yRange);
            
            self.eulerAngles = new Vector3(x, y, 0);
        }
    }
}
