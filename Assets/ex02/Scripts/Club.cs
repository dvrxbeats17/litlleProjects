using UnityEngine;
using ex02;

public class Club : MonoBehaviour
{
    [SerializeField] private Ball ballScript;
    [SerializeField] private float maxPunchPower;
    [SerializeField] private float maxPowerTime;
    private float _currentPower;
    private Vector3 _starterPosition;
    public Vector3 offset;

    void Start()
    {
        _starterPosition = transform.position;
        offset = transform.position - ballScript.transform.position;
    }

    void Update()
    {
        if (ballScript.isGameOver)
        {
            Destroy(gameObject);
            return;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            _currentPower = Mathf.Clamp(_currentPower + (maxPunchPower * Time.deltaTime / maxPowerTime), 0, maxPunchPower);
            //Debug.Log(_currentPower);
            transform.position = (ballScript.transform.position + offset) + Vector3.down * (_currentPower / 3);
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ballScript.Punch(_currentPower);
            transform.position = _starterPosition;
            _currentPower = 0;
        }
    }
}
