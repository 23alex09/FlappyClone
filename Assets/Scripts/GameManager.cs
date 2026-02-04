using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Bird.Instance.OnHitSafeZone += Bird_OnHitSafeZone;
    }

    private void Bird_OnHitSafeZone(object sender, System.EventArgs e)
    {
        score++;
    }

    public int GetCurrentScore()
    {
        return score;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
