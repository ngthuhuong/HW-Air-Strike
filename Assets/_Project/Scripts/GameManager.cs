using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class GameManager : Singleton<GameManager>, MMEventListener<EEnemyDie>
{
    [Header("Game Components")]
    [SerializeField] private PlayerController player;
    public PlayerController Player
    {
        get => player;
        set => player = value;
    }

    [SerializeField] private EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner
    {
        get => enemySpawner;
        set => enemySpawner = value;
    }

    public GameObject enemyProjectileContainer;
    public Transform centerPoint;

    [Header("Level Details")]
    [SerializeField] private List<LevelData> allLevels;

    [Header("Flags")]
    [SerializeField] private bool isLevelComplete = false;
    public bool IsLevelComplete
    {
        get => isLevelComplete;
        set => isLevelComplete = value;
    }

    private int remainingEnemies;

    private void Start()
    {
        StartCoroutine(SpawnAllLevels());
    }

    private void OnEnable()
    {
        this.MMEventStartListening<EEnemyDie>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<EEnemyDie>();
    }

    public void SpawnCurrentLevel()
    {
        if (DataManager.Instance.CurrentLevelId >= allLevels.Count)
        {
            Debug.LogError("Current level ID exceeds the number of available levels.");
            return;
        }
        LevelData currentLevelData = allLevels[DataManager.Instance.CurrentLevelId];
        remainingEnemies = currentLevelData.enemySpawns.Count;
        StartCoroutine(SpawnEnemies(currentLevelData));
    }

    public void OnEnemySpawned()
    {
        remainingEnemies++;
    }

    public void OnEnemyDefeated()
    {
        remainingEnemies--;

        if (remainingEnemies <= 0)
        {
            isLevelComplete = true;
        }
    }

    private IEnumerator SpawnAllLevels()
    {
        for (int i = 0; i < allLevels.Count; i++)
        {
            DataManager.Instance.CurrentLevelId = i;
            SpawnCurrentLevel();

            yield return new WaitUntil(() => isLevelComplete);

            isLevelComplete = false;
        }

        Debug.Log("All levels completed!");
    }

    private IEnumerator SpawnEnemies(LevelData levelData)
    {
        foreach (var spawnData in levelData.enemySpawns)
        {
            yield return new WaitForSeconds(spawnData.spawnTime);
            Instantiate(spawnData.enemyPrefab, spawnData.spawnPosition, Quaternion.identity);
        }
    }

    public void OnMMEvent(EEnemyDie eventType)
    {
        OnEnemyDefeated();
    }
}