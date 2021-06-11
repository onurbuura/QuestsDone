using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Vector2[] points = new Vector2[2];

    [SerializeField] private float time = 2f;

    private int current = 0;

    private Transform _transform;

    private Coroutine ballMovement;

    [SerializeField] bool isMoving = true;

    Vector3 startPos;
    float progress = 0f;

    private void Start()
    {
        _transform = transform;
        startPos = _transform.position;
        ballMovement = StartCoroutine(MoveTheBallCoroutine());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = !isMoving;

        }
        if (isMoving == true && ballMovement == null)
        {
            ballMovement = StartCoroutine(MoveTheBallCoroutine());
        }


    }

    private IEnumerator MoveTheBallCoroutine()
    {
        while (isMoving)
        {
            yield return null;

            progress += Time.deltaTime / time;
            _transform.position = Vector3.Lerp(startPos, points[current], progress);

            if (Vector3.Distance(_transform.position, points[current]) <= 0.05f)
            {
                current = Mathf.Abs(current - (points.Length - 1));
                startPos = _transform.position;
                progress = 0f;
            }
        }
        ballMovement = null;
    }
}
