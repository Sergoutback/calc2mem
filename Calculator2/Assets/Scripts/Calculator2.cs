using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System;

public class Calculator2 : MonoBehaviour
{   
    public Text TextDisp;
    public Text TextDispM1;
    public Text TextDispM2;
    public string press_buttons;
    public double equal1;
    public string zero;
    public string text;
    public string disp1;
    public string textdel;
    public int lenght;
    public double m1;
    public double m2;
    public string dispm0;
    public string dispm1;
    public string dispm2;
    public object TextDisplay { get; private set; }
    public object TextDisplayM1 { get; private set; }
    public object TextDisplayM2 { get; private set; }
    public object TextDisplay_Market { get; private set; }
    
    public void Start()
    {            
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        TextDisp.text =("0").ToString();
        TextDispM1.text ="0";
        TextDispM2.text ="0";
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
        Handheld.Vibrate();
    }
    
    

    public void On_Click_Point()
    {
        if ((TextDisp.text.IndexOf(".") == -1) && (TextDisp.text.IndexOf("∞") == -1))
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
        double equal1 = Convert.ToDouble(dt.Compute(TextDisp.text, ""));
        TextDisp.text = equal1.ToString();
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

    public void On_Click_Percent()
    {
        TextDisp.text += "%";
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
