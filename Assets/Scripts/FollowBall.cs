using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    [SerializeField] private Transform ball;
    private float height = 0;

    private void Start()
    {
        height = transform.position.y;
    }
    private void Update()
    {
        transform.position = new Vector3(ball.position.x, height, ball.position.z);
    }
}
