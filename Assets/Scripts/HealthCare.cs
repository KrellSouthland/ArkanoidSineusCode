using UnityEngine;

public class HealthCare : MonoBehaviour
{
    public static HealthCare Instance;
    [SerializeField] private int hp;
    [SerializeField] private Heart[] hearts;

    private int health;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        health = hp;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].ResumeHealth();
        }

    }


    public void DecreaseHP()
    {
        hearts[health].Kill();
        health--;
        if (health < 0)
        {
            EndManager.Instance.LoseGame();
        }
    }
}
