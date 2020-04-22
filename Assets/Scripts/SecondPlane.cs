using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlane : MonoBehaviour
{
    DateTime currentData;
    DateTime oldData;

    private string savelocation;
    public static SecondPlane instance;

    /// <summary>
    /// Instancias
    /// </summary>
    void Awake()
    {
        //crea instancias para nuestro SecondPlane
        instance = this;
        //define prefab 
        savelocation = "lastSaveData1";
    }
    /// <summary>
    /// Check de Datos
    /// </summary>
    /// <returns>the diference seconds</returns>
    public float CheckDate()
    {
        //ALMACENA  dato actual en currentdata
        currentData = System.DateTime.Now;
        string tempString = PlayerPrefs.GetString(savelocation, "1");
        
        //ALMACENA el dato anterior del prefab como long
        long templong = Convert.ToInt64(tempString);
        
        //CONVIERTE el dato en binario para variables del sencondPlane
        DateTime oldData = DateTime.FromBinary(templong);
        print("Dato Anterior: "+oldData);
        
        //RESTA: uso el metodo de resta y guardo el resultado como timespan
        TimeSpan difference = currentData.Subtract(oldData);
        print("Resta: " + difference);
        return (float)difference.TotalSeconds;

    }

    /// <summary>
    /// Guardar el tiempo actual
    /// </summary>
    public void SaveData()
    {
        //Guarda el tiempo actual del sistema para el prefab de unity
        PlayerPrefs.SetString(savelocation,System.DateTime.Now.ToBinary().ToString());
        print("El dato guardado Prefab es: " + System.DateTime.Now);
    }

}
