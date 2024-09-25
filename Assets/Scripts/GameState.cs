using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public bool gameStarted { get; private set; }
    public Level curLevel;


    private void Awake()
    {
        Instance = this;
    }

    public void ClickState(bool newState)
    {
        gameStarted= newState;
    }
}
