using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// si necesitamos argumentos en mi evento tengo que definir
// una clasecita

[Serializable]
public class EventoArgs1 : UnityEvent<float> {}

[Serializable]
public class EventoArgs2 : UnityEvent<int, string> {}

public class DemoEvents : MonoBehaviour
{

    // UnityEvents 
    // Mecanismo que se adhiere al patrón de diseño de 
    // observador, utilizado para informar a suscriptores
    // que un evento pasó
    [SerializeField]
    private UnityEvent _eventito;

    [SerializeField]
    private EventoArgs1 _eventitoArgs1;

    [SerializeField]
    private EventoArgs2 _eventitoArgs2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            _eventito.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            _eventitoArgs1.Invoke(15.42f);
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            _eventitoArgs2.Invoke(4, "hola!");
        }

    }
}
