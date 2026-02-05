using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        continueButton.onClick.AddListener(() =>
        {
            GameManager.Instance.UnpauseGame();
        });
    }

    private void Start()
    {
        Time.timeScale = 1f;
        Hide();

        GameManager.Instance.OnPauseGame += GameManager_OnPauseGame;
        GameManager.Instance.OnUnpauseGame += GameManager_OnUnpauseGame;
    }

    private void GameManager_OnPauseGame(object sender, System.EventArgs e)
    {
        Show();
    }

    private void GameManager_OnUnpauseGame(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }


}
