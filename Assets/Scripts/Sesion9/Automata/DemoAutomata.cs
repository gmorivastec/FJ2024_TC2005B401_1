using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoAutomata : MonoBehaviour
{

    // Estados
    private Estado _feliz, _triste, _enojado;

    // Simbolos
    private Simbolo _gritar, _pisar, _alimentar;

    // estado actual / inicial
    private Estado _estadoActual;

    // Start is called before the first frame update
    void Start()
    {
        // inicializar estados
        _feliz = new Estado("FELIZ");
        _triste = new Estado("TRISTE");
        _enojado = new Estado("ENOJADO");

        // inicializar simbolos
        _gritar = new Simbolo("GRITAR");
        _pisar = new Simbolo("PISAR");
        _alimentar = new Simbolo("ALIMENTAR");

        // función de transferencia
        _feliz.AgregarTransicion(_gritar, _triste);
        _feliz.AgregarTransicion(_pisar, _enojado);

        _triste.AgregarTransicion(_gritar, _enojado);

        _enojado.AgregarTransicion(_alimentar, _feliz);

        // estado inicial
        _estadoActual = _feliz;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            _estadoActual = _estadoActual.AplicarSimbolo(_gritar);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            _estadoActual = _estadoActual.AplicarSimbolo(_pisar);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            _estadoActual = _estadoActual.AplicarSimbolo(_alimentar);
        }

        print(_estadoActual.Nombre);

    }
}
