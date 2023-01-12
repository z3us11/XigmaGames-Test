using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITwo : MonoBehaviour
{
    [SerializeField] float speed = 75f;
    [SerializeField] Transform player;

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 50f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

}
