using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Estado
{
    // properties
    // compuerta que regula acceso de lectura / escritura
    // a variable
    // la variable puede ser declarada explícitamente o de manera
    // implicita
    public string Nombre
    {
        get;
        private set;
    }

    public Type Behaviour
    {
        get;
        private set;
    }

    // función de transferencia
    private Dictionary<Simbolo, Estado> _transicion;

    public Estado(string nombre, Type behaviour)
    {
        Nombre = nombre;
        Behaviour = behaviour;
        _transicion = new Dictionary<Simbolo, Estado>();
    }

    public void AgregarTransicion(Simbolo simbolo, Estado estado)
    {
        _transicion.Add(simbolo, estado);
    }

    public Estado AplicarSimbolo(Simbolo simbolo)
    {
        if(_transicion.ContainsKey(simbolo))
            return _transicion[simbolo];
        
        return this;
    }
}
