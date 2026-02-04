using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreTextMesh;
    [SerializeField] private Button retryButton;

    private void Awake()
    {
        retryButton.onClick.AddListener(() =>
        {
            GameManager.Instance.ReloadScene();
        });
    }

    private void Start()
    {
        Bird.Instance.OnHitObstacle += Bird_OnHitObstacle;
        Hide();
    }

    private void Bird_OnHitObstacle(object sender, System.EventArgs e)
    {
        finalScoreTextMesh.text = "FINAL SCORE: " + GameManager.Instance.GetCurrentScore();
        Show();
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
