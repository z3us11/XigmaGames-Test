using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AIFour : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3[] wayPoints;
    public float speed;

    int currentWaypoint = 0;
    bool isPatrolling;

    Tween move;
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 100f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            move.Kill();
            isPatrolling = false;
        }
        else
        {
            if(!isPatrolling)
            {
                NextPoint();
                isPatrolling = true;
            }
        }
    }

    void Patrol()
    {
        float distance = Vector3.Distance(transform.position, wayPoints[currentWaypoint]);
        float time = distance / speed;
        move = transform.DOMove(wayPoints[currentWaypoint], time).OnComplete(() => NextPoint());
    }

    void NextPoint()
    {
        currentWaypoint = (currentWaypoint + 1) % wayPoints.Length;
        Patrol();
    }
}
