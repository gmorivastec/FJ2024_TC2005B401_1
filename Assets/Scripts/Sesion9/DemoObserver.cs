using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoObserver : MonoBehaviour
{
    
    // para poder escuchar un eventito hay que definir
    // un método que reciba los argumentos del evento
    public void Observar()
    {
        print("UNITY EVENT SIN ARGUMENTOS");
    }

    public void ObservarArgs1(float arg1)
    {
        print("EVENT CON 1 ARGUMENTO: " + arg1);
    }

    public void ObservarArgs2(int entero, string cadena)
    {
        print("EVENTO CON 2 ARGUMENTOS: " + entero + " " + cadena);
    }
}
