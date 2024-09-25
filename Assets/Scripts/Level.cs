using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int numverOfBlocks;

    public void KillingBlocks()
    {
        numverOfBlocks--;
        if (numverOfBlocks == 0)
        {
            EndManager.Instance.WinGame();
        }
    }
}
