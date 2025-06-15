
using UnityEngine;
using UnityEngine.Audio;


public class AudioController : MonoBehaviour
{
    // reference to the audio mixer component
    public AudioMixer audioMixer;



    // Start is called before the first frame update
    void Start()
    {
        // if the volume level has been saved
        if (PlayerPrefs.HasKey("Master Volume"))
        {
            // read the volume level
            audioMixer.SetFloat("Master Volume", PlayerPrefs.GetFloat("Master Volume"));
        }
    }


} // end of class
