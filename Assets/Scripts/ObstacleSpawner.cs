using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Obstacle obstacle;

    private float spawnTime = 2f;
    private float elapsedTime = 0f;

    private void Start()
    {
        Bird.Instance.OnHitObstacle += Bird_OnHitObstacle;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnTime)
        {
            elapsedTime = 0f;
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        float linearVelocityX = -3f;
        Obstacle spawnedObstacle = Instantiate(obstacle,
                                   new Vector3(transform.position.x, Random.Range(-1.5f, 1.5f), transform.position.z),
                                   Quaternion.identity);
        spawnedObstacle.SetMovementVelocityX(linearVelocityX);

    }

    private void Bird_OnHitObstacle(object sender, System.EventArgs e)
    {
        gameObject.SetActive(false);
    }

}
