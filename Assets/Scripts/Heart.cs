using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] private Sprite health, death;

    [SerializeField] private Image heartImage;

    private void Start()
    {
        heartImage = gameObject.GetComponent<Image>();
    }

    public void ResumeHealth()
    {
        heartImage.sprite = health;
    }

    public void Kill()
    {
        heartImage.sprite = death;
    }
}
