using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    public static Bird Instance { get; private set; }

    public event EventHandler OnHitObstacle;
    public event EventHandler OnHitSafeZone;
    public event EventHandler OnJump;

    private Rigidbody2D birdRigidbody;

    private void Awake()
    {
        Instance = this;
        birdRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameInput.Instance.IsJumpActionPressedThisFrame())
        {
            birdRigidbody.linearVelocityY = 10f;
            OnJump?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<SafeZone>())
        {
            OnHitSafeZone?.Invoke(this, EventArgs.Empty);
            return;
        }
        if (collision.gameObject.GetComponentInChildren<Pipe>())
        {
            OnHitObstacle?.Invoke(this, EventArgs.Empty);
            enabled = false;
            return;
        }
    }

}
