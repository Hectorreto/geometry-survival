using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicTracks; // Arreglo de pistas de música
    private AudioSource audioSource;
    private int currentTrackIndex = 0;
    private float timeSinceLastTrackChange = 0f;
    public float trackChangeInterval = 180f; // Cambio de pista cada 3 minutos

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextTrack();
    }

    private void Update()
    {
        // Controla el tiempo desde el último cambio de pista
        timeSinceLastTrackChange += Time.deltaTime;

        // Cambia de pista si ha pasado el intervalo especificado
        if (timeSinceLastTrackChange >= trackChangeInterval)
            PlayNextTrack();
    }

    private void PlayNextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
        audioSource.clip = musicTracks[currentTrackIndex];
        audioSource.Play();

        // Reinicia el contador de tiempo
        timeSinceLastTrackChange = 0f;
    }
}


