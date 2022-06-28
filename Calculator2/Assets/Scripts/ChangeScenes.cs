using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CalculatorUI
{
    public class ChangeScenes : MonoBehaviour
    {
        public void ChangeFromCalcToHistory()
        {
            SceneManager.LoadScene(2);
        }
        public void ChangeFromCalcToConverter()
        {
            SceneManager.LoadScene(1);
        }
        public void ChangeToCalc()
        {
            SceneManager.LoadScene(0);
        }
    }
}