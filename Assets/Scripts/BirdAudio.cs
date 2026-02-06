using UnityEngine;

public class BirdAudio : MonoBehaviour
{
    [SerializeField] private AudioSource jumpAudioSource;

    private Bird bird;

    private void Awake()
    {
        bird = GetComponent<Bird>();
    }

    private void Start()
    {
        bird.OnJump += Bird_OnJump;
        jumpAudioSource.Pause();
    }

    private void Bird_OnJump(object sender, System.EventArgs e)
    {
        jumpAudioSource.Play();
    }
}
