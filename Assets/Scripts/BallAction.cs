using UnityEngine;

public class BallAction : MonoBehaviour
{
    public static BallAction Instance;
    [SerializeField] private float kick;
    [SerializeField] private Vector2 direction;
    [SerializeField] private Transform spawnPosition;

    public Rigidbody2D rb { get; private set; }
    private bool gameStarted, ballMoving;

    public Vector2 checkLine;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartMove();
        }

    }

    public void StartMove()
    {
        if (GameState.Instance.gameStarted&&!ballMoving)
        {
            transform.SetParent(null);
            checkLine = gameObject.transform.position;
            rb.AddForce(direction.normalized * kick);
            ballMoving = true;
        }
    }

    public void StopMove()
    {
        transform.SetParent(spawnPosition);
        gameObject.transform.position = spawnPosition.position;
        rb.velocity = Vector2.zero * 0;
        ballMoving=false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.sounds[2]);
            HealthCare.Instance.DecreaseHP();
            StopMove();
        }
        else
        {
            Vector2 colhit = gameObject.transform.position;
            SoundManager.Instance.PlaySound(SoundManager.Instance.sounds[0]);
           if (collision.gameObject.GetComponent<BlockManipulator>())
            {
                collision.gameObject.GetComponent<BlockManipulator>().OnHit();
            }
            if (colhit.x == checkLine.x)
            {
                rb.velocity = new Vector2(direction.normalized.x, direction.normalized.y * GetModifier(checkLine.y, colhit.y)) * rb.velocity.magnitude;
            }
            if (colhit.y == checkLine.y)
            {
                rb.velocity = new Vector2(direction.normalized.x * GetModifier(checkLine.x, colhit.x), direction.normalized.y) * rb.velocity.magnitude;
            }
            checkLine = colhit;
        }
    }

    private float GetModifier(float start, float finish)
    {
        return (finish - start >= 0 ? -1f : 1f);
    }
}
