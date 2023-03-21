using UnityEngine;

public class fly : MonoBehaviour
{
    [SerializeField] private float flyingTime = 0.5f;
    [SerializeField] private float fallspeed;

    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform up;
    [SerializeField] private Transform down;

    [SerializeField] private Transform left2;
    [SerializeField] private Transform right2;
    [SerializeField] private Transform up2;
    [SerializeField] private Transform down2;

    private int _score;

    private float _currentFlyingTime;
    public bool _flying;
    private float _sky = 4.2f;
    private float _floor = -2.6f;
    public bool _gameActive;
    void Start()
    {
        _gameActive = true;
    }

    void Update()
    {
        if (!_gameActive)
            return;
        if(transform.position.y < _floor)
            _gameActive=false;
        Pipe();
        Fall();
        Fly();
    }

    void Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_flying)
        {
            _flying = true;
            _currentFlyingTime = 0;
        }

        if (_flying)
        {
            transform.Translate(Vector3.up * Time.deltaTime * (fallspeed * 3));
            _currentFlyingTime += Time.deltaTime;
            if (_currentFlyingTime > flyingTime)
                _flying = false;
        }

    }

    void Fall()
    {
        transform.position += Vector3.down * Time.deltaTime;
        if(transform.position.y < _floor)
        {
            Debug.Log("вы проиграли ");
            Debug.Log($"Bird lifetime: {Mathf.RoundToInt(Time.timeSinceLevelLoad)} seconds.");
            _gameActive = false;
        }
    }

    void Pipe()
    {
        if(transform.position.x > left.position.x && transform.position.x < right.position.x)
        {
            if(transform.position.y > up.position.y || transform.position.y < down.position.y)
            {
                Debug.Log("вы проиграли "); 
                Debug.Log($"Bird lifetime: {Mathf.RoundToInt(Time.timeSinceLevelLoad)} seconds.");
                _gameActive = false;
            }
        }
        
        if(transform.position.x > left2.position.x && transform.position.x < right2.position.x)
        {
            if(transform.position.y > up2.position.y || transform.position.y < down2.position.y)
            {
                Debug.Log("вы проиграли ");
                Debug.Log($"Bird lifetime: {Mathf.RoundToInt(Time.timeSinceLevelLoad)} seconds.");
                _gameActive = false;
            }
        }

    }
    void Score()
     {
        if (transform.position.x > left.position.x && transform.position.x < right.position.x)
        {
            if (transform.position.y < up.position.y || transform.position.y > down.position.y)
            {
                _score++;
                Debug.Log($"счет вашей птицы {_score}");
            }
        }

        if (transform.position.x > left2.position.x && transform.position.x < right2.position.x)
        {
            if (transform.position.y < up2.position.y || transform.position.y > down2.position.y)
            {
                _score++;
                Debug.Log($"счет вашей птицы {_score}");
            }
        }
     }
}
