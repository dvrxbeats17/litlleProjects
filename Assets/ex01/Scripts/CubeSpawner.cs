
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes;
    [SerializeField] private float minSpawn;
    [SerializeField] private float maxSpawn;
    private float _endY = -5f;
    private float _time;
    private GameObject _currentCube;
    private GameObject _lastCube;
    void Start()
    {
        _time = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad < _time)
            return;
        _currentCube = cubes[Random.Range(0, cubes.Length)];
        if (_currentCube == _lastCube)
            return;
        _lastCube = _currentCube;
        Instantiate(_currentCube);
        _time = Time.timeSinceLevelLoad + Random.Range(minSpawn, maxSpawn);
    }
}
