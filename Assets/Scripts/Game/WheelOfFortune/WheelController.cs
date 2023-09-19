using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.WheelOfFortune
{
    public class WheelController : MonoBehaviour
    {
        [SerializeField] private RectTransform wheel;
        [SerializeField] private RectTransform pin;
        [field:Min(2)][field:SerializeField] public int TotalNumber { get; private set; }=8;
        [SerializeField] private float spinSpeed;
        [SerializeField] private float minSpinTime;
        [SerializeField] private float maxSpinTime;
        [SerializeField] private float slowingSpinSpeed;
        [SerializeField] private float slowingSpinTime;
        [SerializeField] private TMP_Text selectedNumberText;
        private int targetNumber=1;
        private float targetAngle;
        private float anglePerNumber => 360f / TotalNumber;

        private SpinState spinState;
        public Action<int> OnWheelStopped;

        private void Update()
        {
            switch (spinState)
            {
                case SpinState.Stopped:
                    break;
                case SpinState.Spinning:
                    Spin(spinSpeed);
                    break;
                case SpinState.Slowing:
                    Spin(slowingSpinSpeed);
                    break;
                case SpinState.StopWhenTarget:
                    StopWhenReachedToTarget();
                    break;
                default:
                    break;
            }
        }

        private void OnEnable()
        {
            MoveToNumber(Random.Range(1,9));
        }

        public void MoveToNumber(int target)
        {
            SetSelectedText(target);
            SetTarget(target);
            StartSpin();
        }

        public void AvoidNumber(int avoidNumber)
        {
            SetSelectedText(avoidNumber);
            var number=0;
            do
            {
                number = Random.Range(1, TotalNumber + 1);
            } while (number == avoidNumber);

        
            SetTarget(number);    
            StartSpin();
        }

        private void SetSelectedText(int number)
        {
            selectedNumberText.SetText($"{number} Selected");
        }

        private void SetTarget(int number)
        {
            targetNumber = number;
            targetAngle = (targetNumber-1) * anglePerNumber + Random.Range(anglePerNumber*.2f, anglePerNumber-anglePerNumber*.2f);
        }

        private void StartSpin()
        {
            spinState = SpinState.Spinning;
            Invoke(nameof(StartSlowDownSpin),Random.Range(minSpinTime,maxSpinTime));
        }
    
        private void StartSlowDownSpin()
        {
            spinState = SpinState.Slowing;
            Invoke(nameof(StopSpin),slowingSpinTime);
        }
    
        private void StopSpin()
        {
            spinState = SpinState.StopWhenTarget;
        }
    
        private void StopWhenReachedToTarget()
        {
            if (CheckInTargetArea())
            {
                spinState = SpinState.Stopped;
                OnWheelStopped?.Invoke(targetNumber);
            }
            else
            {
                Spin(slowingSpinSpeed);
            }
        }

        private void Spin(float speed)
        {
            wheel.Rotate(Vector3.forward, speed * Time.deltaTime);
            pin.Rotate(Vector3.forward, speed * Time.deltaTime);
            if (pin.localRotation.eulerAngles.z > 5)
            {
                pin.localRotation=Quaternion.Euler(0, 0, 0);
            }
        }

        bool CheckInTargetArea()
        {
            return Mathf.Abs((wheel.localRotation.eulerAngles.z+360)%360- targetAngle) < anglePerNumber*.2f;
        }
    
    }

    enum SpinState
    {
        Stopped,
        Spinning,
        Slowing,
        StopWhenTarget
    }
}