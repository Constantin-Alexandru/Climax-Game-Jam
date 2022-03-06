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
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] TextMeshProUGUI connectionsText;

    [Space]

    [SerializeField] Canvas inGame;
    [SerializeField] Canvas winState;

    private void Awake()
    {
        LevelHandler.onCountChange += LevelHandler_onCountChange;
        GameManager.onRunResponse += GameManager_onRunResponse;
        GameManager.onNewLevel += GameManager_onNewLevel;
    }

    private void GameManager_onNewLevel(object sender, System.EventArgs e)
    {
        inGame.gameObject.SetActive(true);
        winState.gameObject.SetActive(false);
    }

    private void GameManager_onRunResponse(object sender, GameManager.OnRunResponseArgs e)
    {
        messageText.text = e.message;

        if(e.message == "CORRECT!")
        {
            inGame.gameObject.SetActive(false);
            winState.gameObject.SetActive(true);
        }
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
        GameManager.onRunResponse -= GameManager_onRunResponse;
    }
}
