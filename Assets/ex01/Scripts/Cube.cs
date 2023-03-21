
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private KeyCode keyCode;

    private float _speed;
    private float _endY = -5f;
    private float _startY = -1f;
    public int _combo = 0;
    void Start()
    {
        _speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        Click();
        DeleteCube();
    }

    void Click()
    {
        if (Input.GetKeyDown(keyCode) && transform.position.y > _endY && transform.position.y < _startY)
        {
            _combo++;
            if (transform.position.y - _endY <= 0.9f)
            {
                Debug.Log("GOOD");
                _combo = 0;
            }
            else if (transform.position.y - _endY <= 2f)
            {
                Debug.Log("PERFECT");
            }
            else if (transform.position.y - _endY <= 2.5f)
            {
                Debug.Log("GREAT");
            }
            else if (transform.position.y - _endY <= 3f)
            {
                Debug.Log("BAD");
                _combo = 0;
            }
            else
            {
                Debug.Log("MISS");
                _combo = 0;
            }
            Debug.Log($"COMBO: {_combo}");
            Destroy(gameObject);
        }
    }

    void DeleteCube()
    {
        if (transform.position.y < _endY)
        {
            Debug.Log("MISS");
            Destroy(gameObject);
        }
    }

}
