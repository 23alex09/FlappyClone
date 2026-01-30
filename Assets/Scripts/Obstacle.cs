using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Transform destroyPosition;
    private Rigidbody2D obstacleRigidbody;

    private void Awake()
    {
        obstacleRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Bird.Instance.OnHitObstacle += Bird_OnHitObstacle;
        destroyPosition = DestroyPosition.Instance.transform;
    }

    private void Update()
    {
        if (transform.position.x <= destroyPosition.position.x)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

    private void Bird_OnHitObstacle(object sender, System.EventArgs e)
    {
        SetMovementVelocityX(0f);
    }

    public void SetMovementVelocityX(float linearVelocityX)
    {
        obstacleRigidbody.linearVelocityX = linearVelocityX;
    }


}
