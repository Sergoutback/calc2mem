using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CalculatorUI
{

    public class ButtonSounds : MonoBehaviour
    {
        public AudioSource myFx;
        public AudioClip clickFx;

        public void ClickSound()
        {
            myFx.PlayOneShot(clickFx);
        }
    }
}
