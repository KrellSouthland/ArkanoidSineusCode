using System;
using UnityEngine;

public class BlockManipulator : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;

    private SpriteRenderer sr;

    public Color[] hpSprites;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = hpSprites[hp];
    }

    private void DecreazeHp()
    {
        hp--;
        if (hp>=0)
        {
            sr.color = hpSprites[hp];
        }
        else
        {
            PointCounter.Instance.AddCount();
            GameState.Instance.curLevel.KillingBlocks();
            Destroy(gameObject);
        }    

    }

    public void OnHit()
    {
        DecreazeHp();
    }
}
