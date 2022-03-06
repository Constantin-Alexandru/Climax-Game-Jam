using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button serverBtn;
    [SerializeField] Button proxyBtn;
    [SerializeField] TextMeshProUGUI serverBtnText;
    [SerializeField] TextMeshProUGUI proxyBtnText;

    private void Start()
    {
        LevelHandler.onCountChange += LevelHandler_onCountChange;
    }

    private void LevelHandler_onCountChange(object sender, LevelHandler.OnCountChangeArgs e)
    {
        if(e.id == 1)
        {
            serverBtnText.text = e.count.ToString();

            if(e.count == 0)
            {
                serverBtn.interactable = false;
            }
            else
            {
                serverBtn.interactable=true;
            }
        }
        else if(e.id == 2)
        {
            proxyBtnText.text = e.count.ToString();
            
            if (e.count == 0)
            {
                proxyBtn.interactable = false;
            }
            else
            {
                proxyBtn.interactable = true;
            }
        }
    }

    private void OnDestroy()
    {
        LevelHandler.onCountChange -= LevelHandler_onCountChange;
    }
}
