using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnPauseGame;
    public event EventHandler OnUnpauseGame;
    public event EventHandler OnGameOver;

    private int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnPuaseButtonPressed += GameInput_OnPauseButtonPressed;
        Bird.Instance.OnHitSafeZone += Bird_OnHitSafeZone;
        Bird.Instance.OnHitObstacle += Bird_OnHitObstacle;
    }

    private void GameInput_OnPauseButtonPressed(object sender, System.EventArgs e)
    {
        PauseUnpauseGame();
    }

    private void Bird_OnHitSafeZone(object sender, System.EventArgs e)
    {
        score++;
    }

    private void Bird_OnHitObstacle(object sender, System.EventArgs e)
    {
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    public int GetCurrentScore()
    {
        return score;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseUnpauseGame()
    {
        if (Time.timeScale == 1f)
        {
            PauseGame();
        }
        else
        {
            UnpauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        OnPauseGame?.Invoke(this, EventArgs.Empty);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        OnUnpauseGame?.Invoke(this, EventArgs.Empty);
    }
}
