using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{

    // MANAGERS - 
    // objetos que centralizan lógica / recursos comunes 

    // Singleton - patrón de diseño
    // https://en.wikipedia.org/wiki/Singleton_pattern

    // el singleton en unity no es "preventivo" sino "correctivo"

    // PROPERTIES EN C#
    // mecanismo para ocultar una variable 
    // y separar quién la lee y quién la escribe
    // la variable puede ser declarada o anónima

    [SerializeField]
    private float _ejemplito;
    
    [SerializeField]
    private TMP_Text _textito;

    public float Ejemplito
    {
        private set 
        {
            _ejemplito = value;
        }
        get
        {
            return _ejemplito;
        }
    }

    public static GUIManager Instance 
    {
        private set;
        get;
    }

    void Awake()
    {
        if(Instance != null)
        {
            // alguien ya se asignó
            // destruyo este gameobject
            Destroy(gameObject);
        } 
        else
        {
            Instance = this;
        }
    }

    public void ActualizarTextito(string texto)
    {
        _textito.text = texto;
        //print(texto);
    }
}
