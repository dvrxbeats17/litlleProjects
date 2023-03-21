using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float startSpeed;
    [SerializeField] private float topCollision;
    [SerializeField] private float bottomCollision;
    [SerializeField] public float GatesPos;
    [SerializeField] private Transform[] leftCollision;
    [SerializeField] private Transform[] rightCollision;
    [SerializeField] private bool gameActive;
    public int _validScore;

    [HideInInspector] public bool isGameOver = false;

    [HideInInspector] public int _P1score;
    [HideInInspector] public int _P2score;
    private Vector3 _startingPos;
    private float _verticalDir;
    private float _horizontalDir;
    private Vector3 _direction;


    //    Написать Pong используя физику.Мяч должен быть Rigidbody2D.Платформы должны также двигаться
    //    с помощью клавиш WS и стрелочек вверх и вниз.На старте мы будем давать ускорение на объект
    //    мяча в случайном направлении. Он должен отскакивать от платформ и при попадании в ворота
    //    одного из игроков должен срабатывать триггер, который меняет нужный ему счет.
    //    Результат отправить в виде unitypackage через export ассетов.


    [SerializeField] private TMP_Text P1Score;
    [SerializeField] private TMP_Text P2Score;
    private int starterScore1 = 0;
    private int starterScore2 = 0;

    void Start()
    {
        startSpeed = speed;
        _startingPos = transform.position;
        _verticalDir = RandomDir();
        _horizontalDir = RandomDir();
        _direction = new Vector3(_horizontalDir, _verticalDir);
    }

    void Update()
    {
        if (isGameOver)
            return;
        if (_P1score >= _validScore)
        {
            isGameOver = true;
        }
        if (_P2score >= _validScore)
        {
            isGameOver = true;
        }
        Borders();
        MoveOFTheBall();
        Goal();
        Restart();
    }


    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || _P1score == _validScore || _P2score == _validScore)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
    float RandomDir()
    {
        return Random.Range(0, 2) * 2 - 1;
    }

    
    void Borders()
    {
        if (transform.position.y < bottomCollision || transform.position.y > topCollision)
        {
            _direction.y *= -1;
            speed += 0.3f;
        }
    }

     void Goal()
     {
        if (transform.position.x < -GatesPos)
        {
            starterScore2 += 1;
            P2Score.text = starterScore2.ToString();
            _direction.x = RandomDir();
            _direction.y = RandomDir();
            transform.position = _startingPos;
            speed = startSpeed;
        }
        if (transform.position.x > GatesPos)
        {
            starterScore1 += 1;
            P1Score.text = starterScore1.ToString();
            _direction.x = RandomDir();
            _direction.y = RandomDir();
            transform.position = _startingPos;
            speed = startSpeed;
        }
        else
        {
            if(_direction.x < 0)
            {
                if(transform.position.y < leftCollision[0].position.y && transform.position.y > leftCollision[1].position.y)
                {
                    if(transform.position.x < leftCollision[0].position.x)
                    {
                        _direction.x *= -1;
                        _direction.y = RandomDir();
                    }
                }
            }
            
            if(_direction.x > 0)
            {
                if(transform.position.y < rightCollision[0].position.y && transform.position.y > rightCollision[1].position.y)
                {
                    if(transform.position.x > rightCollision[0].position.x)
                    {
                        _direction.x *= -1;
                        _direction.y = RandomDir();
                    }
                }
            }
        }

     }

    void MoveOFTheBall()
    {
        transform.Translate(_direction * Time.deltaTime * speed);
    }
}
