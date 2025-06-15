
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


public class OptionsController : MonoBehaviour
{
    // reference to the audio mixer component
    public AudioMixer audioMixer;

    // reference to the volume slider
    public Slider masterVolumeSlider;

    // reference to the volume level label
    public TMP_Text masterVolumeLabel;



    // Start is called before the first frame update
    void Start()
    {
        // if the volume has already been saved
        if (PlayerPrefs.HasKey("Master Volume"))
        {
            // read the setting
            audioMixer.SetFloat("Master Volume", PlayerPrefs.GetFloat("Master Volume"));

            // and apply it
            masterVolumeSlider.value = PlayerPrefs.GetFloat("Master Volume");
        }

        // update the ui
        masterVolumeLabel.text = (masterVolumeSlider.value + 80).ToString();
    }


    public void SetMasterVol()
    {
        // update the ui
        masterVolumeLabel.text = (masterVolumeSlider.value + 80).ToString();

        // set the volume level
        audioMixer.SetFloat("Master Volume", masterVolumeSlider.value);

        // and save it
        PlayerPrefs.SetFloat("Master Volume", masterVolumeSlider.value);
    }


} // end if class
