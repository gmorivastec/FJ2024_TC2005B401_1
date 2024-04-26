using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoAutomata : MonoBehaviour
{
    // NOTA IMPORTANTE Y UTIL
    // behaviour trees:
    // https://www.gamedeveloper.com/programming/behavior-trees-for-ai-how-they-work

    // Estados
    private Estado _feliz, _triste, _enojado;

    // Simbolos
    private Simbolo _gritar, _pisar, _alimentar;

    // estado actual / inicial
    private Estado _estadoActual;

    // referencia al comportamiento actual
    private MonoBehaviour _comportamientoActual;


    // Start is called before the first frame update
    void Start()
    {
        // inicializar estados
        _feliz = new Estado("FELIZ", typeof(FelizBehaviour));
        _triste = new Estado("TRISTE", typeof(TristeBehaviour));
        _enojado = new Estado("ENOJADO", typeof(EnojadoBehaviour));

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
        _comportamientoActual = gameObject.AddComponent(_estadoActual.Behaviour) as MonoBehaviour;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
            IntercambioDeEstados(_gritar);

        if(Input.GetKeyDown(KeyCode.P))
            IntercambioDeEstados(_pisar);

        if(Input.GetKeyDown(KeyCode.A))
            IntercambioDeEstados(_alimentar);

    }
    
    private void IntercambioDeEstados(Simbolo simbolo)
    {
        // verificar si el estado realmente cambia
        Estado nuevoEstado = _estadoActual.AplicarSimbolo(simbolo);

        if(nuevoEstado == _estadoActual)
            return;

        // quitar componente viejo, agregar componente nuevo
        Destroy(_comportamientoActual);
        _comportamientoActual = gameObject.AddComponent(nuevoEstado.Behaviour) as MonoBehaviour;
    
        // actualizamos estado actual
        _estadoActual = nuevoEstado;
    }
}
