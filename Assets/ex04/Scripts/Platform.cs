using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private KeyCode platformUp;
    [SerializeField] private KeyCode platformDown;
    [SerializeField] private Transform border1;
    [SerializeField] private Transform border2;
    [SerializeField] private float speed;

    void Update()
    {
        Controller();
    }

    void Controller()
    {
        if (Input.GetKey(platformUp) && transform.position.y < border1.position.y)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if (Input.GetKey(platformDown) && transform.position.y > border2.position.y)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

    }

}
