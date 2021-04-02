using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
// using System.Index;
using System;
public class Calculator : MonoBehaviour
{   
    public Text TextDisp;
    public Text TextDispM1;
    public Text TextDispM2;
    public string press_buttons;
    public double equal;
    public string zero;
    public string text;
    public string disp1;
    public string textdel;
    public string textdelM1;
    public string textdelM2;
    public int lenght;
    public int lenghtM1;
    public int lenghtM2;
    public double m1;
    public double m2;
    public string dispm0;
    public string dispm1;
    public string dispm2;
    public object TextDisplay { get; private set; }
    public object TextDisplayM1 { get; private set; }
    public object TextDisplayM2 { get; private set; }
    public object TextDisplay_Market { get; private set; }
    public VibroOff forVibroOff;

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
        int forVibroOff =  vibroOff.vibrr;   
        Debug.Log(forVibroOff);     

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
        // if ((TextDisp.text.IndexOf(".") == -1) && (TextDisp.text.IndexOf("∞") == -1))
            TextDisp.text += ".";
    }
    
    public void On_Click_C()
    {
        TextDisp.text =("0").ToString();
    }

    public void On_Click_AC()
    {
        TextDisp.text =("0").ToString();
        TextDispM1.text =("0").ToString();
        TextDispM2.text =("0").ToString();
    }
    public void On_Click_Equal()
    {        
        DataTable dt = new DataTable();
        double equal = Convert.ToDouble(dt.Compute(TextDisp.text, ""));
        TextDisp.text = equal.ToString();             
    }

    public void On_Click_Plus_Minus()
    {
        if (TextDisp.text[0] == '-')
            TextDisp.text = (TextDisp.text.Remove(0, 1)).ToString();
        else
            TextDisp.text = ("-" + TextDisp.text).ToString();
    }
    public void On_Click_Del()
    {        
        int lenght = TextDisp.text.Length - 1;
        string textdel = TextDisp.text;
        if (lenght <1)
            {   
                TextDisp.text =("0").ToString();
            }
        else
                TextDisp.text =("").ToString();

        for (int i = 0; i < lenght; i++)
            {
                TextDisp.text = TextDisp.text + textdel[i];
            }        
    }

    public void On_Click_M1Del()
    {        
        int lenghtM1 = TextDispM1.text.Length - 1;
        string textdelM1 = TextDispM1.text;
        if (lenghtM1 <1)
            {   
                TextDispM1.text =("0").ToString();
            }
        else
                TextDispM1.text =("").ToString();

        for (int i = 0; i < lenghtM1; i++)
            {
                TextDispM1.text = TextDispM1.text + textdelM1[i];
            }        
    }

    public void On_Click_M2Del()
    {        
        int lenghtM2 = TextDispM2.text.Length - 1;
        string textdelM2 = TextDispM2.text;
        if (lenghtM2 <1)
            {   
                TextDispM2.text =("0").ToString();
            }
        else
                TextDispM2.text =("").ToString();

        for (int i = 0; i < lenghtM2; i++)
            {
                TextDispM2.text = TextDispM2.text + textdelM2[i];
            }        
    }

    public void On_Click_Percent()
    {
        // if (TextDisp.text.Contains ("%"))        
        // {
            // TextDisp.text = TextDisp.text.Remove(-1, 1);

            //указали длину массива
            int [] TextDispArr = new int [(TextDisp.text).Length]; 
            Debug.Log((TextDisp.text).Length);
            //создали и инициализировали массив 
            // преобразовали string to array
            // произвели операции с последними двумя членами масива
            // создали новый массив с новыми значениями
            // преобразовали массив в строку
            double valueBeforePersent = Convert.ToDouble(TextDispArr[TextDispArr.Length - 2]) * 0.01 * Convert.ToDouble(TextDispArr[TextDispArr.Length - 1]);  
            Debug.Log(valueBeforePersent);
            TextDisp.text = TextDisp.text.Remove((TextDispArr[TextDispArr.Length - 1]), 1);
            // string first = TextDispArr.GetValue((TextDispArr - 2);
            // string varArr =textDispArr.ToCharArray([(TextDisp.text).Length]-2, 2);


            // double [] varTextDispArr = new double[2]{(textDispArr[textDispArr.Length-2 ]), (textDispArr[textDispArr.Length-1])};
            // Debug.Log(varTextDispArr);

            // TextDispArr.SetValue( "one", 1 );
            // Console.WriteLine( "[1]:   {0}", textDispArr.GetValue( ^1 ) );     

            // double beforePersent = Convert.ToDouble(textDispArr[textDispArr.Length - 2]) * 0.01 * Convert.ToDouble(textDispArr[textDispArr.Length - 1]);   
            // TextDisp.text = TextDisp.text +  beforePersent; 
        // }
        
        // int number = int.Parse(project.Variables["number"].Value);
        // int persent = int.Parse(project.Variables["persent"].Value);
        // return number/100*persent;
        
        // TextDisp.text = (double.Parse(TextBox1.Text) * double.Parse(TextBox2.Text) / 100 * double.Parse(TextBox3.Text)).ToString();

        //TextDisp.text = Convert.ToDouble(TextDisp.text);
    }

     //M1plus button
    public void On_Click_MemoryPlus()
    {   
        double m1 = Convert.ToDouble(TextDispM1.text) + Convert.ToDouble(TextDisp.text);
        string dispm1 = m1.ToString();
        TextDispM1.text = dispm1;

        return;
    }
 //M1minus button
    public void On_Click_MemoryMinus()
    {   
        double m1 = Convert.ToDouble(TextDispM1.text) - Convert.ToDouble(TextDisp.text);
        string dispm1 = m1.ToString();
        TextDispM1.text = dispm1;
        
        return;
    }
    //MR1 button
    public void On_Click_MemoryReturn()
    {   
        TextDisp.text += TextDispM1.text;
        
        return;
    }
    //MClear1 button
    public void On_Click_MemoryClear()
    {   
        TextDispM1.text =("0").ToString();
        
        return;
    }

         //M2plus button
    public void On_Click_Memory2Plus()
    {   
        double m2 = Convert.ToDouble(TextDispM2.text) + Convert.ToDouble(TextDisp.text);
        string dispm2 = m2.ToString();
        TextDispM2.text = dispm2;

        return;
    }
    //M2minus button
    public void On_Click_Memory2Minus()
    {   
        double m2 = Convert.ToDouble(TextDispM2.text) - Convert.ToDouble(TextDisp.text);
        string dispm2 = m2.ToString();
        TextDispM2.text = dispm2;
        
        return;
    }
    //MR2 button
    public void On_Click_Memory2Return()
    {   
        TextDisp.text += TextDispM2.text;
        
        return;
    }
    //MClear2 button
    public void On_Click_Memory2Clear()
    {   
        TextDispM2.text =("0").ToString();
        
        return;
    }
}
