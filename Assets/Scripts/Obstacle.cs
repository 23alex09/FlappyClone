using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Transform destroyPosition;
    private Rigidbody2D obstacleRigidbody;
    private float linearVelocityX = -3f;

    private void Awake()
    {
        obstacleRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Bird.Instance.OnHitObstacle += Bird_OnHitObstacle;
        destroyPosition = DestroyPosition.Instance.transform;
        SetMovementVelocityX();
    }

    private void Update()
    {
        if (transform.position.x <= destroyPosition.position.x)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
            Bird.Instance.OnHitObstacle -= Bird_OnHitObstacle;
        }
    }

    private void Bird_OnHitObstacle(object sender, System.EventArgs e)
    {
        obstacleRigidbody.linearVelocityX = 0f;
    }

    public void SetMovementVelocityX()
    {
        obstacleRigidbody.linearVelocityX = linearVelocityX;
    }


}
