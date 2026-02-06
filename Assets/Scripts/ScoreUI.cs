using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextMesh;

    private void Awake()
    {
        scoreTextMesh.text = "00";
    }

    private void Update()
    {
        UpdateScoreTextMesh();
    }

    private void UpdateScoreTextMesh()
    {
        scoreTextMesh.text = GameManager.Instance.GetCurrentScore().ToString();
    }
}
