using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private RawImage background;


    private void Start()
    {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
    }

    private void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(.2f, 0f) * Time.deltaTime, background.uvRect.size);
    }

    private void GameManager_OnGameOver(object sender, System.EventArgs e)
    {
        enabled = false;
    }
}
