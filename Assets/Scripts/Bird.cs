using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    public static Bird Instance { get; private set; }

    public event EventHandler OnHitObstacle;

    private Rigidbody2D birdRigidbody;

    private void Awake()
    {
        Instance = this;
        birdRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            birdRigidbody.linearVelocityY = 10f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<SafeZone>())
        {
            Debug.Log("+1");
            return;
        }
        if (collision.gameObject.GetComponentInChildren<Pipe>())
        {
            Debug.Log("Muelto");
            OnHitObstacle?.Invoke(this, EventArgs.Empty);
            enabled = false;
            return;
        }
    }

}
