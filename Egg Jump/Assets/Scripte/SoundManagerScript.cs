using UnityEngine.Audio;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    private static AudioClip jumpSound,fallSound, landingSound;
    static AudioSource audioSource;
    private AllSounds sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = FindObjectOfType<AllSounds>();
        jumpSound = sound.jumpSound;
        fallSound = sound.fallSound;
        landingSound = sound.landingSound;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "fall":
                audioSource.PlayOneShot(fallSound);
                break;
            case "landing":
                audioSource.PlayOneShot(fallSound);
                break;
        }
    }
}
