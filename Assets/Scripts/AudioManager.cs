using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;

    public AudioMixerGroup soundEffectMixer;

    // Start is called before the first frame update
    public static AudioManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(! audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");//Crée un gameObject dans la scène pour jouer le sound voulue
        tempGO.transform.position = pos;// on Change sa position pour qu'il soit à l'endroit à l'endroit où un objet à crée ce son
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();// on rajoute un composent audio au gameObject
        audioSource.clip = clip;// Sound à jouer
        audioSource.outputAudioMixerGroup = soundEffectMixer;// Permet d'utiliser le paramètre sound présent 
        audioSource.Play();// on joue le son
        Destroy(tempGO, clip.length);// On détruit le game object après la lecture du son
        return audioSource;// car méthode audiosource
    }
}
