using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AIThree : MonoBehaviour
{
    [SerializeField] Vector3[] wayPoints;
    public float speed;

    int currentWaypoint = 0;

    private void Start()
    {
        Patrol();
    }

    void Patrol()
    {
        float distance = Vector3.Distance(transform.position, wayPoints[currentWaypoint]);
        float time = distance / speed ;
        transform.DOMove(wayPoints[currentWaypoint], time ).OnComplete(()=>NextPoint());
    }

    public void NextPoint()
    {
        currentWaypoint = (currentWaypoint + 1) % wayPoints.Length;
        Patrol();
    }
}

