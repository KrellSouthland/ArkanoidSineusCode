using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public static PointCounter Instance;
    [SerializeField] private TextMeshProUGUI counterText;

    public int counter { get; private set; }

    private void Awake()
    {
        Instance= this;
    }

    public void AddCount()
    {
        counter++;
        counterText.text = counter.ToString();
    }

    public void NulifyCounter()
    {
        counter = 0;
        counterText.text = counter.ToString();
    }
}
