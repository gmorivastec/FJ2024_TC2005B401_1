using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canion : MonoBehaviour
{

    // como crear instancias en Unity
    // 2 maneras - 
    // 1. crear game object vacío y agregar componentes dinámicamente
    // 2. clonar un game object existente

    [SerializeField]
    private GameObject _balaOriginal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Instantiate(_balaOriginal);
        }
    }
}
