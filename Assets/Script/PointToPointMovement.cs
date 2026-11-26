using Unity.VisualScripting;
using UnityEngine;

public class PointToPointMovement : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private BoxCollider trigger;
    [SerializeField] private int moveDuration = 1;

    private Vector3 point1Pos;
    private Vector3 point2Pos;

    private float elapsedTime;

    void Start()
    {
        point1Pos = point1.position;
        point2Pos = point2.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered: " + other.name);
        if (other.CompareTag("Player"))
        {
            MoveToPoint();
            Debug.Log("player triggered");
        }
    }

    private void MoveToPoint()
    {
        elapsedTime += Time.deltaTime;

        float t = elapsedTime / moveDuration;

        transform.position = Vector3.Lerp(point1Pos, point2Pos, t);
    }
}
