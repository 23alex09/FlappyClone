using UnityEngine;

public class DestroyPosition : MonoBehaviour
{
    public static DestroyPosition Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
