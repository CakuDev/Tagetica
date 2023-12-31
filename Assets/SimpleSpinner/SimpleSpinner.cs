using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleSpinner
{
    [RequireComponent(typeof(Image))]
    public class SimpleSpinner : MonoBehaviour
    {
        [Header("Rotation")]
        public bool Rotation = true;
        [Range(-10, 10), Tooltip("Value in Hz (revolutions per second).")]
        public float RotationSpeed = 1;
        public AnimationCurve RotationAnimationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        [Header("Rainbow")]
        public bool Rainbow = true;
        [Range(-10, 10), Tooltip("Value in Hz (revolutions per second).")]
        public float RainbowSpeed = 0.5f;
        [Range(0, 1)]
        public float RainbowSaturation = 1f;
        public AnimationCurve RainbowAnimationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        [Header("Options")]
        public bool RandomPeriod = true;
        
        private Image _image;
        private float _period;
        private float time;

        public void Init()
        {
            time = 0f;
            _period = 0;
            Rotation = true;
        }

        public void ResetRotation()
        {
            transform.localEulerAngles = Vector3.zero;
        }

        public void Stop()
        {
            Rotation = false;
        }

        public void Start()
        {
            time = 0;
            _image = GetComponent<Image>();
            _period = RandomPeriod ? Random.Range(0f, 1f) : 0;
        }

        public void Update()
        {
            if (Rotation)
            {
                time += Time.deltaTime;
                transform.localEulerAngles = new Vector3(0, 0, -360 * RotationAnimationCurve.Evaluate((RotationSpeed * time + _period) % 1));
            }

            if (Rainbow)
            {
                _image.color = Color.HSVToRGB(RainbowAnimationCurve.Evaluate((RainbowSpeed * Time.time + _period) % 1), RainbowSaturation, 1);
            }
        }

        // value format: 5s
        public void ChangeTotalTime(string value)
        {
            RotationSpeed = 1/float.Parse(value.Split("s")[0]);
        }
    }
}