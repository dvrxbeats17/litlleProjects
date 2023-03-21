using UnityEngine;

public class pipe : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float speedIncrease;
    [SerializeField] private fly birdScript;

    private Vector3 _startingPosition;
    private float _speed;
    void Start()
    {
        _speed = startSpeed;
        _startingPosition = transform.position;
    }

    void Update()
    {
        if (!birdScript._gameActive)
            return;
        if(transform.position.x < -12f)
        {
            _speed += speedIncrease;
            transform.position = _startingPosition;
        }
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }

}
