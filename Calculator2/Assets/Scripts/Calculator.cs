using UnityEngine;
using UnityEngine.UI;
using System.Data;
// using System.Index;
using System;
using System.Text.RegularExpressions;

namespace CalculatorUI
{
    public class Calculator : MonoBehaviour
    {
        [SerializeField] private Text TextDisp;
        [SerializeField] private Text TextDispM1;
        [SerializeField] private Text TextDispM2;
        [SerializeField] private Text TextDispPercent;
        [SerializeField] private string press_buttons;
        private double lenght;
        private string newPersentFirstNumber;

        public void Start()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            On_Click_AC();
        }

        public void CorrectNumber()
        {
            //ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
            if (TextDisp.text[0] == '0' && TextDisp.text.IndexOf(".") != 1)
            {
                TextDisp.text = TextDisp.text.Remove(0, 1) + press_buttons;
            }
            //аналогично предыдущему, только для отрицательного числа
            else if (TextDisp.text[0] == '-')
            {
                if (TextDisp.text[1] == '0' && TextDisp.text.IndexOf(".") != 2)
                {
                    TextDisp.text = TextDisp.text.Remove(1, 1) + press_buttons;
                }
                else
                {
                    TextDisp.text += press_buttons;
                }
            }
            else
            {
                TextDisp.text += press_buttons;
            }
        }


        public void On_Click_button()
        {
            CorrectNumber();
        }

        public void Vibro()
        {
            VibroOff vibroOff = gameObject.GetComponent<VibroOff>();
            // взять переменную  из скрипта VibroOff
            int forVibroOff = vibroOff.vibrr;
            // Debug.Log(forVibroOff);     

            if (forVibroOff == 1)
            {
                Vibration.Init();
                Vibration.Vibrate(30);
                Debug.Log("VibrWork");
            }
            else
            {
                Debug.Log("NoVibr");
            }
        }

        public void On_Click_Point()
        {
            // из-за этой херни не ставится вторая запятая. надо подумать, как переделать
            TextDisp.text += ".";
        }

        public void On_Click_C()
        {
            TextDisp.text = "0";
            TextDispPercent.text = "0";
        }

        public void On_Click_AC()
        {
            TextDisp.text = "0";
            TextDispM1.text = "0";
            TextDispM2.text = "0";
            TextDispPercent.text = "0";
        }

        public void On_Click_Equal()
        {
            if (TextDisp.text.Contains("%"))
            {
                newPersentFirstNumber = TextDispPercent.text;
                string oldTextDispText = TextDisp.text;

                Regex myRegPersent = new Regex(@"^(\d+\.?\d*)(\+|\-|\/|\*){1}(\d+\.?\d*)(\%?)$");
                string[] newArrayPersent = myRegPersent.Split(oldTextDispText);
                string persentFirstNumber = Convert.ToString(newArrayPersent[1]);
                string persentArifmChar = Convert.ToString(newArrayPersent[2]);

                TextDisp.text = persentFirstNumber + persentArifmChar + newPersentFirstNumber;

                DataTable dt = new DataTable();
                double equal = Convert.ToDouble(dt.Compute(TextDisp.text, ""));
                TextDisp.text = equal.ToString();
                TextDispPercent.text = "0";
            }
            else
            {
                DataTable dt = new DataTable();
                double equal = Convert.ToDouble(dt.Compute(TextDisp.text, ""));
                TextDisp.text = equal.ToString();
            }
        }

        public void On_Click_Plus_Minus()
        {
            if (TextDisp.text[0] == '-')
                TextDisp.text = TextDisp.text.Remove(0, 1);
            else
                TextDisp.text = ("-" + TextDisp.text);
        }

        public void On_Click_Del()
        {
            double lenght = TextDisp.text.Length - 1;
            string textdel = TextDisp.text;
            if (lenght < 1)
            {
                TextDisp.text = "0";
            }
            else
                TextDisp.text = "";

            for (int i = 0; i < lenght; i++)
            {
                TextDisp.text = TextDisp.text + textdel[i];
            }
        }

        public void On_Click_M1Del()
        {
            double lenghtM1 = TextDispM1.text.Length - 1;
            string textdelM1 = TextDispM1.text;
            if (lenghtM1 < 1)
            {
                TextDispM1.text = "0";
                ;
            }
            else
                TextDispM1.text = "";

            for (int i = 0; i < lenghtM1; i++)
            {
                TextDispM1.text = TextDispM1.text + textdelM1[i];
            }
        }

        public void On_Click_M2Del()
        {
            double lenghtM2 = TextDispM2.text.Length - 1;
            string textdelM2 = TextDispM2.text;
            if (lenghtM2 < 1)
            {
                TextDispM2.text = "0";
            }
            else
                TextDispM2.text = "";

            for (int i = 0; i < lenghtM2; i++)
            {
                TextDispM2.text = TextDispM2.text + textdelM2[i];
            }
        }

        public void On_Click_Percent()
        {
            string percentInArray = TextDisp.text;

            Regex myReg = new Regex(@"^(\d+\.?\d*)(\+|\-|\/|\*){1}(\d+\.?\d*)(\%?)$");
            string[] newArray = myReg.Split(percentInArray); // массив имен      
            string persentFirstNumber = Convert.ToString(newArray[1]);
            string persentArifmChar = Convert.ToString(newArray[2]);
            string persentSecondNumber = Convert.ToString(newArray[3]);
            double solution = Convert.ToDouble(persentFirstNumber) * Convert.ToDouble(persentSecondNumber) / 100;
            TextDispPercent.text = Convert.ToString(solution);
        }


        //M1plus button
        public void On_Click_MemoryPlus()
        {
            double m1 = Convert.ToDouble(TextDispM1.text) + Convert.ToDouble(TextDisp.text);
            string dispm1 = m1.ToString();
            TextDispM1.text = dispm1;
        }

        //M1minus button
        public void On_Click_MemoryMinus()
        {
            double m1 = Convert.ToDouble(TextDispM1.text) - Convert.ToDouble(TextDisp.text);
            string dispm1 = m1.ToString();
            TextDispM1.text = dispm1;
        }

        //MR1 button
        public void On_Click_MemoryReturn()
        {
            if (TextDisp.text[0] == '0' && (lenght < 1))
                TextDisp.text = TextDispM1.text + (TextDisp.text).Remove(0, 1);
            else
                TextDisp.text += TextDispM1.text;
        }

        //MClear1 button
        public void On_Click_MemoryClear()
        {
            TextDispM1.text = "0";
        }

        //M2plus button
        public void On_Click_Memory2Plus()
        {
            double m2 = Convert.ToDouble(TextDispM2.text) + Convert.ToDouble(TextDisp.text);
            string dispm2 = m2.ToString();
            TextDispM2.text = dispm2;
        }

        //M2minus button
        public void On_Click_Memory2Minus()
        {
            double m2 = Convert.ToDouble(TextDispM2.text) - Convert.ToDouble(TextDisp.text);
            string dispm2 = m2.ToString();
            TextDispM2.text = dispm2;
        }

        //MR2 button
        public void On_Click_Memory2Return()
        {
            if (TextDisp.text[0] == '0' && (lenght < 1))
                TextDisp.text = TextDispM2.text + (TextDisp.text).Remove(0, 1);
            else
                TextDisp.text += TextDispM2.text;
        }

        //MClear2 button
        public void On_Click_Memory2Clear()
        {
            TextDispM2.text = "0";
        }
    }
}