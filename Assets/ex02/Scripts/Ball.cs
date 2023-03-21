using UnityEngine;

namespace ex02
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Club club;
        [SerializeField] private Transform topCollision;
        [SerializeField] private Transform downCollision;
        [SerializeField] private Transform topHoleCollision;
        [SerializeField] private Transform downHoleCollision;
        [SerializeField] private float flyTime;
        private bool _isPunched;
        private float _speed;
        private float _currentFlyTime;
        private int _score;

        [HideInInspector] public bool isGameOver = false;

        void Start()
        {

        }

        void Update()
        {
            if (isGameOver)
            {
                Destroy(gameObject);
                return;
            }
            if (!_isPunched)
            {
                _currentFlyTime = 0f;
                return;
            }
            _currentFlyTime += Time.deltaTime;
            if (transform.position.y > topCollision.position.y || transform.position.y < downCollision.position.y)
                _speed *= -1;
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
            if (_currentFlyTime > flyTime)
            {
                club.transform.position = transform.position + club.offset;
                club.gameObject.SetActive(true);
                if (transform.position.y < topHoleCollision.position.y && transform.position.y > downHoleCollision.position.y)
                {
                    if (_score == 1)
                        Debug.Log($"вы победили за {_score} ход");
                    if (_score <= 4)
                        Debug.Log($"вы победили за {_score} хода");
                    if (_score >= 5) 
                        Debug.Log($"вы победили за {_score} ходов");
                    isGameOver = true;
                }
                _isPunched = false;
            }

        }

        public void Punch(float punchPower)
        {
            club.gameObject.SetActive(false);
            _score++;
            _isPunched = true;
            _speed = punchPower;
        }
    }

}
