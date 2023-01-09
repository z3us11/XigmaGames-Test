using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallShooting : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector3 mouseStartPos;
    Vector3 mouseEndPos;
    Vector3 dir;
    Vector3 force;

    [SerializeField] float power = 50f;

    bool startedShooting = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPos = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            startedShooting = false;
            mouseEndPos = Input.mousePosition;
            dir = mouseStartPos - mouseEndPos;
            force = dir * power * Time.deltaTime;
            _rb.AddForce(force);
        }
    }

}
