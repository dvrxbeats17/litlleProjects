using UnityEngine;

public class Ballon : MonoBehaviour
{
    [SerializeField] private float inflateValue;
    [SerializeField] private float fadeValue;
    [SerializeField] private float baloonMaxSize;
    [SerializeField] private float baloonMinSize;
    [SerializeField] private float MaxLungs;
    private float _lungs;
    private bool _flag; 
    void Start()
    {
        _lungs = MaxLungs;
    }

    void Update()
    {
        if (_flag)
            return;
        LungsRecovery();
        Inflate();
        Fade();
        GameOver();
    }

    void Inflate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _lungs > inflateValue)
        {
            Debug.Log("You pressed Space button");
            transform.localScale += Vector3.one * inflateValue;
            _lungs -= inflateValue;
        }
    }

    void Fade()
    {
        transform.localScale -= Vector3.one * fadeValue * Time.deltaTime;
    }

    void LungsRecovery()
    {
        if(_lungs < MaxLungs)
        {
            _lungs += Time.deltaTime * (fadeValue + 0.2f);
            Debug.Log(Mathf.RoundToInt(_lungs));
        }
    }

    void GameOver()
    {
        if(transform.localScale.x > baloonMaxSize)
        {
            Debug.Log($"Balloon lifetime: {Mathf.RoundToInt(Time.timeSinceLevelLoad)} seconds.");
            Destroy(gameObject);
        }

        if(transform.localScale.x < baloonMinSize)
        {
            _flag = true;
            Debug.Log($"Balloon lifetime: {Mathf.RoundToInt(Time.timeSinceLevelLoad)} seconds.");
        }

    }

}
