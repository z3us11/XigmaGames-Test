using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AIOne : MonoBehaviour
{

    float speed = 100f;

    private void Start()
    {
        MoveToNewPos();
    }

    void MoveToNewPos()
    {
        Vector3 newPos = new Vector3(Random.Range(-450, 450), 5f, Random.Range(-450, 450));
        float distance = Vector3.Distance(newPos, transform.position);
        float time = distance / speed;
        transform.DOMove(newPos, time).OnComplete(() => MoveToNewPos());
    }
}
