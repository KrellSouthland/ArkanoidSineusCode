using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject[] LevelPrefabs;
    public GameObject spawnPlayer, currentLevel;
    public int LevelIndex;

    private void Awake()
    {
        Instance = this;
    }


    public void ChangeLevel()
    {
        LevelIndex++;
        if (LevelIndex >= LevelPrefabs.Length)
        {
            LevelIndex = 1;
        }
        Destroy(currentLevel);
        GameObject newLevel = Instantiate (LevelPrefabs[LevelIndex],spawnPlayer.transform);
        currentLevel = newLevel;
        GameState.Instance.curLevel = currentLevel.GetComponent<Level>();
    }
}
