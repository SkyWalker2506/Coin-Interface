using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockingWait : MonoBehaviour
{
    [SerializeField]
    Slider sliderRef;

    [SerializeField]
    GameObject finishedPopup;

    private void OnEnable()
    {
        finishedPopup.SetActive(true);
        Debug.Log("BlockingWait:OnEnable");
    }

    public void CloseBlockingScreen()
    {
        finishedPopup.SetActive(false);
        gameObject.SetActive(false);
        Debug.Log("BlockingWait:CloseBlockingScreen");
    }
}
