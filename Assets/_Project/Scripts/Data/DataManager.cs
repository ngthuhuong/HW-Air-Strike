using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;


public class DataManager : Singleton<DataManager>, MMEventListener<EEarnScore>, MMEventListener<EGameOver>,MMEventListener<EEnemyDie>
{
    [SerializeField] private int highScore;
    
    public int HighScore
    {
        get => highScore;
        set
        {
            highScore = value;
            MMEventManager.TriggerEvent(new EDataChanged());    
        }
    }
    
    [SerializeField] private int currentScore;

    public int CurrentScore
    {
        get => currentScore;
        set
        {
            currentScore = value;
            MMEventManager.TriggerEvent(new EDataChanged());    
        }
    }

    [Header("Leveling")] 
    [SerializeField] private int currentLevelId;
    public int CurrentLevelId
    {
        get => currentLevelId;
        set
        {
            currentLevelId = value;
            MMEventManager.TriggerEvent(new EDataChanged());    
        }
    }
    
    
    #region MonoBehaviour

    private void OnEnable()
    {
        this.MMEventStartListening<EEarnScore>();
        this.MMEventStartListening<EGameOver>();
        this.MMEventStartListening<EEnemyDie>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<EEarnScore>();
        this.MMEventStopListening<EGameOver>();
        this.MMEventStopListening<EEnemyDie>();
    }

    #endregion

    #region Events Listen

    public void OnMMEvent(EEarnScore eventType)
    {
        Debug.Log($"DataManager receive event {eventType}");
        CurrentScore += 1;
    }

    public void OnMMEvent(EGameOver eventType)
    {
        // Cap nhat lai high score
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (HighScore < CurrentScore)
        {
            PlayerPrefs.SetInt("HighScore", CurrentScore);
            PlayerPrefs.Save();
            HighScore = CurrentScore;
        }
    }

    #endregion

    public void OnMMEvent(EEnemyDie eventType)
    {
        CurrentScore += 1;
        
    }
}
