using UnityEngine;
using UnityEngine.UI;

public class VibroOff : MonoBehaviour
{
    public Sprite enableSpriteVibro;
    public Sprite disableSpriteVibro;

    public bool vibroEnabled = true;
    public bool VibroEnabled { get { return vibroEnabled; } set { SetVibro(value); } }

    Image imageVibro;  
    
    void Start()
    {
        imageVibro = GetComponent<Image>();     
        Vibration.Init();                           
    }

    public void SetVibro(bool enabled)
    {
        if (enabled)
        {  
            Vibration.Vibrate(50);       
            Debug.Log("VibrWorkVibroOffscript" );                         
            imageVibro.sprite = enableSpriteVibro;           
        }
        else
        {         
            Vibration.Cancel();     
            Debug.Log("NoVibrVibroOffscript" );                                       
            imageVibro.sprite = disableSpriteVibro;
        }
        vibroEnabled = enabled;        
    }

    public void SwitchVibro()
    {
        VibroEnabled = !VibroEnabled;
    }
}