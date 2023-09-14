using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    BlockingWait blockingWaitPopup;

    public void Action_SpendOneCoin()
    {
        Debug.Log("MainMenu:Action_SpendOneCoin");
    }

    public void Action_GetExtraCoin()
    {
        Debug.Log("MainMenu:Action_GetExtraCoin");
        blockingWaitPopup.gameObject.SetActive(true);
    }

    public void Action_ClaimFreeCoin()
    {
        Debug.Log("MainMenu:Action_ClaimFreeCoin");
    }
}
