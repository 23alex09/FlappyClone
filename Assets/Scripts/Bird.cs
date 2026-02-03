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
        // If no instance exists, become the instance.
        if (Instance == null)
        {
            Instance = this;
            // If you want the Bird to persist across scenes, uncomment:
            // DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            // Another instance already exists — avoid duplicate singletons.
            Debug.LogWarning($"Duplicate {nameof(Bird)} detected on '{gameObject.name}'. Destroying duplicate.");
            Destroy(gameObject);
            return;
        }
    }

    void OnDestroy()
    {
        // Clear the static reference when the instance is destroyed so it can be recreated later.
        if (Instance == this)
            Instance = null;
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
