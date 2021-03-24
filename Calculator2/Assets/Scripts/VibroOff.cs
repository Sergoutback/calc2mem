using UnityEngine;
using UnityEngine.UI;

public class VibroOff : MonoBehaviour
{
    public Sprite enableSpriteVibro;
    public Sprite disableSpriteVibro;

    bool vibroEnabled = true;
    public bool VibroEnabled { get { return vibroEnabled; } set { SetVibro(value); } }

    Image imageVibro;
    // public Vibration vibrationIsVibration;
    public bool isVibration; 

    void Start()
    {
        imageVibro = GetComponent<Image>();
        // vibrationIsVibration = GetComponent<Vibration>();
    }

    void SetVibro(bool enabled)
    {
        if (enabled)
        {
            isVibration = true;
            // vibrationIsVibration.isVibration = true;
            imageVibro.sprite = enableSpriteVibro;
        }
        else
        {
            isVibration = false;
            // vibrationIsVibration.isVibration = false;
            imageVibro.sprite = disableSpriteVibro;
        }
        vibroEnabled = enabled;
    }

    public void SwitchVibro()
    {
        VibroEnabled = !VibroEnabled;
    }

    public void PlayVibrationStandart()
    {
        if(isVibration == true) Handheld.Vibrate();
    }
}