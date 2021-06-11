using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public enum SensitivityType
    {
        Slider,
        Typing
    }
    public SensitivityType sensitivityType;
    [Range(0.1f, 10f)]
    [SerializeField] float SensitivityBar = 0.1f;
    [SerializeField] float SensitivityFloat = 0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (InputManager.Instance.isTouching)
        {
            if (sensitivityType == SensitivityType.Typing)
                rb.velocity = new Vector3(InputManager.Instance.deltaDir.x * SensitivityFloat, 0f, 0f);
            if (sensitivityType == SensitivityType.Slider)
                rb.velocity = new Vector3(InputManager.Instance.deltaDir.x * SensitivityBar, 0f, 0f);
        }
    }
}
