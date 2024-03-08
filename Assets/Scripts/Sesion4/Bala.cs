using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bala : MonoBehaviour
{

    // necesito referencia al rigid body
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _fuerza = 10;

    // Start is called before the first frame update
    void Start()
    {
        // a tener en cuenta! 
        // esto puede ser nulo 
        _rigidbody = GetComponent<Rigidbody>();

        // rigidbody es el encargado de suscribir un objeto
        // al motor de la física
        
        // cualquier operación de física pasa por medio de rigidbody
        // SIEMPRE TENER EN CUENTA CON MOVIMIENTO / FÍSICA
        // el espacio donde estamos aplicando el movimiento
        // referencia local o global

        // transform. right, forward, up
        // referencias en espacio global de vectores que apuntan en 
        // las 3 direcciones en mi objeto
        // los 3 son vectores unitarios
        _rigidbody.AddForce(transform.up * _fuerza, ForceMode.Impulse);
    }

    // Update is called once per frame  
    void Update()
    {
        
    }
}
