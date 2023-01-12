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

    public bool canShoot = true;

    bool startedShooting = false;
    LaunchArcRenderer _arc;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(canShoot)
            Shooting();
    }

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPos = Input.mousePosition;
            startedShooting = true;
        }
        if (Input.GetMouseButton(0))
        {
            mouseEndPos = Input.mousePosition;
            dir = mouseStartPos - mouseEndPos;
            force = dir * power * Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0))
        {
            startedShooting = false;
            _rb.velocity = force * Time.deltaTime;
            Debug.Log(_rb.velocity.magnitude);
            if (_rb.velocity.magnitude > 15f)
            {
                canShoot = false;
                Invoke(nameof(ResetPos), 3f);
            }
        }
    }

    public void ResetPos()
    {
        canShoot = true;
        _rb.velocity = Vector2.zero;
        transform.position = new Vector3(Random.Range(-8, -3), -3.5f, 0);
    }

}
