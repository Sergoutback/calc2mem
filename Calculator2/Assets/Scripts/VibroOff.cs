using UnityEngine;
using UnityEngine.UI;

public class VibroOff : MonoBehaviour
{
    public Sprite enableSpriteVibro;
    public Sprite disableSpriteVibro;

    public bool vibroEnabled = true;
    public bool VibroEnabled { get { return vibroEnabled; } set { SetVibro(value); } }

    Image imageVibro;
    public int forVibro;
    
    void Start()
    {
        imageVibro = GetComponent<Image>();  
        Vibration.Init();                    
    }

    public void SetVibro(bool enabled)
    {
        if (enabled)
        {   
            forVibro = 1;                            
            imageVibro.sprite = enableSpriteVibro;           
        }
        else
        {  
            forVibro = 2;    
            Vibration.Cancel();                       
            imageVibro.sprite = disableSpriteVibro;
        }
        vibroEnabled = enabled;
    }

    public void SwitchVibro()
    {
        VibroEnabled = !VibroEnabled;
    }
}