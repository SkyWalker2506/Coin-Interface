using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelController : MonoBehaviour
{
    [SerializeField] private RectTransform wheel;
    [Min(2)][SerializeField] private int totalNumber = 8;
    private int targetNumber=1;
    private float anglePerNumber => 360f / totalNumber;
    private float spinSpeed;
    private float minSpinTime;
    private float maxSpinTime;
    private float slowingSpinSpeed;
    private float slowingSpinTime;
    
    private SpinState spinState;

    private void Update()
    {
        switch (spinState)
        {
            case SpinState.Stopped:
                break;
            case SpinState.Spinning:
                Spin();
                break;
            case SpinState.Slowing:
                SlowingSpin();
                break;
            case SpinState.StopWhenTarget:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Spin()
    {
        wheel.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }

    private void SlowingSpin()
    {
        wheel.Rotate(Vector3.forward, slowingSpinSpeed * Time.deltaTime);
    }

    private void StopWhenReachedToTarget()
    {
        // wheel.rotation.eulerAngles.z>
    }

    float GetMidAngle(int number)
    {
        return (number - .5f) * anglePerNumber;
    }

    public void AvoidNumber(int avoidNumber)
    {
        do
        {
            targetNumber = Random.Range(1, totalNumber + 1);
        } while (targetNumber == avoidNumber);

        StartSpin();
    }
    
    public void MoveToNumber(int target)
    {
        targetNumber = target;
        StartSpin();
    }

    private void StartSpin()
    {
        spinState = SpinState.Spinning;
        Invoke(nameof(StartSlowDownSpin),Random.Range(minSpinTime,maxSpinTime));
    }
    
    private void StartSlowDownSpin()
    {
        spinState = SpinState.Slowing;
        Invoke(nameof(StopSpin),1);
    }
    
    private void StopSpin()
    {
        spinState = SpinState.StopWhenTarget;
    }

    bool CheckInTargetArea()
    {
        return false;
    }
    
}


enum SpinState
{
    Stopped,
    Spinning,
    Slowing,
    StopWhenTarget
}