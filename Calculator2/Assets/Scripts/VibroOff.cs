using UnityEngine;
using UnityEngine.UI;

public class VibroOff : MonoBehaviour
{
    public Sprite enableSpriteVibro;
    public Sprite disableSpriteVibro;

    public bool vibroEnabled = true;
    public bool VibroEnabled { get { return vibroEnabled; } set { SetVibro(value); } }

    Image imageVibro;
    public bool forVibro;
    
    void Start()
    {
        imageVibro = GetComponent<Image>();                        
    }

    public void SetVibro(bool enabled)
    {
        if (enabled)
        {   
            forVibro = true;                            
            imageVibro.sprite = enableSpriteVibro;           
        }
        else
        {  
            forVibro = false;                                      
            imageVibro.sprite = disableSpriteVibro;
        }
        vibroEnabled = enabled;        
    }

    public void SwitchVibro()
    {
        VibroEnabled = !VibroEnabled;
    }
}