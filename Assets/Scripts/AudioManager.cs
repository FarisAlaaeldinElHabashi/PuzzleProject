using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource buzzSource;
    public AudioSource successSource;

    void Awake() => Instance = this;

    public void Play(string sound)
    {
        switch (sound)
        {
            case "Buzz":
                buzzSource?.Play();
                break;
            case "Success":
                successSource?.Play();
                break;
        }
    }
}
