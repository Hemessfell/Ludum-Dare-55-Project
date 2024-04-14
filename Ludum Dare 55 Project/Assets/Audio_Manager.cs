
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [Header(" -------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    [Header(" -------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip music;
    public AudioClip wagon;
   

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
       
    }


}

   
