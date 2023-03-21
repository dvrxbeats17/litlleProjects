using TMPro;
using UnityEngine;

public class GoalCollidor : MonoBehaviour
{
    [SerializeField] BallPhysics ball;
    [SerializeField] private TMP_Text score;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball._P1score++;
        ball.transform.position = Vector3.zero;
        ball._horizontalDir = ball.RandomDir();
        ball._verticalDir = ball.RandomDir();
        score.text = ($"{ball._P1score}:{ball._P2score}");
    }
}
