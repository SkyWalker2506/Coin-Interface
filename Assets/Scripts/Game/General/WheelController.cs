using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelController : MonoBehaviour
{
    [SerializeField] private RectTransform wheel;
    [SerializeField] private RectTransform pin;
    [Min(2)][SerializeField] private int totalNumber = 8;
    [SerializeField] private float spinSpeed;
    [SerializeField] private float minSpinTime;
    [SerializeField] private float maxSpinTime;
    [SerializeField] private float slowingSpinSpeed;
    [SerializeField] private float slowingSpinTime;
    private int targetNumber=1;
    private float targetAngle;

    private float anglePerNumber => 360f / totalNumber;
  
    
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
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnEnable()
    {
        MoveToNumber(Random.Range(1,9));
    }

    public void MoveToNumber(int target)
    {
        SetTarget(target);
        StartSpin();
    }

    public void AvoidNumber(int avoidNumber)
    {
        var number=0;
        do
        {
            number = Random.Range(1, totalNumber + 1);
        } while (number == avoidNumber);

        
        SetTarget(number);    
        StartSpin();
    }
    
    private void SetTarget(int number)
    {
        targetNumber = number;
        targetAngle = targetNumber * anglePerNumber + Random.Range(5, anglePerNumber-5);
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
        return Mathf.Abs(wheel.localRotation.eulerAngles.z- targetAngle)<10;
    }
    
}


enum SpinState
{
    Stopped,
    Spinning,
    Slowing,
    StopWhenTarget
}