using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RealTimeCounter : MonoBehaviour
{
    public float inicio;
    public float timer;
    public Text contador;


    void Start()
    {
        
        timer = inicio;
        //actualiza el tiempo real con el tiempo pasado
        timer -= SecondPlane.instance.CheckDate();

    }

    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        //actualiza el tiempo cada frame
        timer -= Time.deltaTime;
        contador.text = timer.ToString();
        if (timer <= 0)
        {
            contador.text = "0";
        }
    }

    /// <summary>
    /// GUI
    /// </summary>
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 50), "Inicio"))
        {
            ResetClock();
        }

        if (GUI.Button(new Rect(10, 150, 100, 50), "Cuenta Actual"))
        {
            print(60-SecondPlane.instance.CheckDate()+"Tiempo Real transcurrido");
        }
        GUI.Label(new Rect(10, 150, 100, 50), timer.ToString());
    }

    /// <summary>
    /// Reset Clock
    /// </summary>
    void ResetClock()
    {
        SecondPlane.instance.SaveData();
        timer = inicio;
        timer -= SecondPlane.instance.CheckDate();

    }
}
