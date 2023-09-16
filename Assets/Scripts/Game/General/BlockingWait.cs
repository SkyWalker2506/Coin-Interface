using System;
using UnityEngine;
using UnityEngine.UI;

public class BlockingWait : MonoBehaviour
{
    [SerializeField]
    Slider sliderRef;
    [SerializeField] private float waitTime;
    private float remainingTime;
    [SerializeField]
    GameObject finishedPopup;
    public Action OnBlockingDone;
    private void OnEnable()
    {
        Debug.Log("BlockingWait:OnEnable");
        remainingTime = waitTime;
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            sliderRef.value = remainingTime / waitTime;
            remainingTime -= Time.deltaTime;
            if (remainingTime<=0)
            {
                remainingTime = 0;
                finishedPopup.SetActive(true);
            }
        }
    }

    public void CloseBlockingScreen()
    {
        finishedPopup.SetActive(false);
        gameObject.SetActive(false);
        OnBlockingDone?.Invoke();
        Debug.Log("BlockingWait:CloseBlockingScreen");
    }
}
