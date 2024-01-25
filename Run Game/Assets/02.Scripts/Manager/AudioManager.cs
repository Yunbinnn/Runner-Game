using UnityEngine;
using UnityEngine.SceneManagement;

public enum SoundScene
{
    Title,
    Game,
}

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] SoundScene soundScene;
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;   
    }

    public void EffectSound(AudioClip audioClip)
    {
        effectSource.PlayOneShot(audioClip);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        soundScene = (SoundScene)scene.buildIndex;

        scenerySource.clip = Resources.Load<AudioClip>(soundScene.ToString() + " Sound");

        scenerySource.loop = true;

        scenerySource.Play();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}