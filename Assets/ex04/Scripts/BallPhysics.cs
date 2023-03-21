using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private Rigidbody2D PongBall;

    [HideInInspector] public float _verticalDir;
    [HideInInspector] public float _horizontalDir;
    [HideInInspector] public Vector3 _direction;
    [HideInInspector] public int _P1score;
    [HideInInspector] public int _P2score;
    void Start()
    {
        _verticalDir = RandomDir();
        _horizontalDir = RandomDir();
        _direction = new Vector3(_horizontalDir, _verticalDir);
        PongBall = GetComponent<Rigidbody2D>();
        PongBall.velocity = new Vector2(_horizontalDir + 5, _verticalDir + 5);
    }

    void Update()
    {

    }
    public float RandomDir()
    {
        return Random.Range(0, 2) * 2 - 1;
    }
}
