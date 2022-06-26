using UnityEngine;
using UnityEngine.UI;

namespace CalculatorUI
{
    public class VibroOff : MonoBehaviour
    {
        public Sprite enableSpriteVibro;
        public Sprite disableSpriteVibro;

        public bool vibroEnabled = true;
        public bool VibroEnabled { get { return vibroEnabled; } set { SetVibro(value); } }

        Image imageVibro;
        public int vibrr;

        void Start()
        {
            imageVibro = GetComponent<Image>();
            DefaultVibrr();
            // Vibration.Init();                           
        }

        public void DefaultVibrr()
        {
            if (vibrr == 0)
                vibrr = 1;
        }


        public void SetVibro(bool enabled)
        {
            if (vibroEnabled = enabled)
            {
                vibrr = 1;
                Debug.Log("WORKVibrVibroOffscript");
                imageVibro.sprite = enableSpriteVibro;
            }
            else
            {
                vibrr = 2;
                Debug.Log("NOVibrVibroOffscript");
                imageVibro.sprite = disableSpriteVibro;
            }
            // vibroEnabled = enabled;           
        }

        public void SwitchVibro()
        {
            VibroEnabled = !VibroEnabled;
        }
    }
}