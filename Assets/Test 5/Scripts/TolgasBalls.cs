using System.Collections;
using UnityEngine;

public class TolgasBalls : MonoBehaviour
{
    [SerializeField] private Vector2[] points = new Vector2[2];

    [SerializeField] private float time = 2f;
    
    private float elapsedTime;

    private int current = 0;

    private Transform _transform;
    private Coroutine ballMovement;

    private Vector3 startPos;
    private Vector3 targetPoint;

    public KeyCode toggleKey = KeyCode.Space;
    private bool isPlaying = true;

    private void Start()
    {
        SetStartParameters();
        ballMovement = StartCoroutine(MoveTheBallCoroutine());
    }
    private void SetStartParameters()
    {
        _transform = transform;

        startPos = _transform.position;

        current = 1;

        targetPoint = points[1];
    }
    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isPlaying = !isPlaying;
            
            if (isPlaying)
            {
                StopCoroutine(ballMovement);
            }
            else
                ballMovement = StartCoroutine(MoveTheBallCoroutine());
        }
    }

    private IEnumerator MoveTheBallCoroutine()
    {
        WaitForEndOfFrame frameDelay = new WaitForEndOfFrame();
        while (isPlaying)
        {
            yield return frameDelay;
            elapsedTime += Time.deltaTime;
            _transform.position = Vector3.Lerp(startPos , targetPoint , elapsedTime / time);

            if(elapsedTime >= time)
            {
                current++;
                if(current >= points.Length)
                {
                    current = 0;
                }
                targetPoint = points[current];
                startPos = _transform.position;
                elapsedTime = 0f;
            }
        }
    }
}
