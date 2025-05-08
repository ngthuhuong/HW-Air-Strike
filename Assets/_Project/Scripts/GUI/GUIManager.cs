using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class GUIManager : MonoBehaviour,MMEventListener<EDataChanged>, MMEventListener<EGameOver>
{
    [Header("GUIs")]
    [SerializeField] public GameOverGUI guiGameOver;
    [SerializeField] public GUIHUD guiHUD;
    void OnEnable()
    {
        this.MMEventStartListening<EGameOver>();
        this.MMEventStartListening<EDataChanged>();
    }

    void OnDisable()
    {
        this.MMEventStopListening<EGameOver>();
        this.MMEventStopListening<EDataChanged>();
    }
    public void OnMMEvent(EDataChanged eventType)
    {
        
    }

    public void OnMMEvent(EGameOver eventType)
    {
        guiGameOver.Show();
        Time.timeScale = 0;
    }
}
