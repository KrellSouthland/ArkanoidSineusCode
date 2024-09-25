using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopCoordinate;

    [SerializeField] private float maxBounceAngle = 60f;

    private void FixedUpdate()
    {
        if(GameState.Instance.gameStarted)
        Move();
    }

    private void Move ()
    {
        transform.Translate(Vector2.right *Input.GetAxis("Horizontal") * speed);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, stopCoordinate*(-1), stopCoordinate), transform.position.y);
    }

}
