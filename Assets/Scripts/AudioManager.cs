using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    private AudioSource AudioSource;
    private static AudioManager _instance;
    public static AudioManager Instance => _instance;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void ChangerAudio(AudioClip Audio)
    {
        AudioSource.clip = Audio;
    }

    

    #region Unity Event Functions


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);   
        }

        _instance = this;
    }

    #endregion
}
