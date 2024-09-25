using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip[] sounds;

    private AudioSource source;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        source = GetComponent<AudioSource>();
    }
    
    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
