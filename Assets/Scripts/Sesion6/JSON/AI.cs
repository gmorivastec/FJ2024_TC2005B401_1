using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// para el parser que usamos en unity es necesario tener una clase
// a la que pueda traducir los datos del json que pretendo traducir

[Serializable]
public class AI
{
    // necesito un atributo por cada dato que se contenga en el objeto 
    // JSON que se pretender traducir
    // IMPORTANTE:
    // - variable pública
    // - tipo de dato que permita guardar info del JSON
    // - es OBLIGATORIO que tenga el mismo nombre que la variable en el JSON
    public string name;
    public int more_info;
}
