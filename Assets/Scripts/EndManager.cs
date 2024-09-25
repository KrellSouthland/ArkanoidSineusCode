using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public static EndManager Instance;

    [SerializeField] private TextMeshProUGUI winCount, LoseCount;
    [SerializeField] private GameObject win, lose;

    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void InitializeMenu(GameObject menu, TextMeshProUGUI counter)
    {
        menu.SetActive(true);
        counter.text = PointCounter.Instance.counter.ToString();
    }

    public void WinGame()
    {
        BallAction.Instance.StopMove();
        SoundManager.Instance.PlaySound(SoundManager.Instance.sounds[1]);
        InitializeMenu(win, winCount);
    }

    public void LoseGame()
    {
        BallAction.Instance.StopMove();
        InitializeMenu(lose, LoseCount);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SetNextLevel()
    {
        LevelManager.Instance.ChangeLevel();
        win.SetActive(false);
    }
}
