using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Canion : MonoBehaviour
{

    // como crear instancias en Unity
    // 2 maneras - 
    // 1. crear game object vacío y agregar componentes dinámicamente
    // 2. clonar un game object existente

    [SerializeField]
    private GameObject _balaOriginal;
    
    [SerializeField]
    private Transform _referencia;

    [SerializeField]
    private float _velocidad = 5;

    IEnumerator _corrutinaDisparo;

    // Start is called before the first frame update
    void Start()
    {
        // esto te puede ahorrar dolores de cabeza
        Assert.IsNotNull(_balaOriginal, "BALA ES NULA, VERIFICAR");
        Assert.IsNotNull(_referencia, "REFERENCIA ES NULA, VERIFICAR");
        StartCoroutine(CorrutinaTemporizador());
        StartCoroutine("CorrutinaRecurrente");

        _corrutinaDisparo = CorrutinaDisparo();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(
            horizontal * Time.deltaTime * _velocidad,
            0,
            0,
            Space.Self
        );

        if(Input.GetButtonDown("Jump"))
        {
            StartCoroutine(_corrutinaDisparo);
            //GUIManager.Instance.Ejemplito = 12;
            GUIManager.Instance.ActualizarTextito("disparando " + GUIManager.Instance.Ejemplito);
            // alternativa:
            // GameObject guiManager = GameObject.Find("GUIManager");
            // SÍ funciona
            // es muy lento
        }

        if(Input.GetButtonUp("Jump"))
        {
            StopCoroutine(_corrutinaDisparo);
            GUIManager.Instance.ActualizarTextito("FIN");
            //StopAllCoroutines();
        }
        
    }

    // corutinas 
    // mecanismo para pseudo concurrencia en Unity
    // las corrutinas NO bloquean la ejecución
    // las corrutinas pertenecen a el componente
    // casos de uso:
    // - lógica que necesite un temporizador
    // - lógica que corra de manera recurrente (sin usar update)
    // - lógica asíncrona

    // lógica con temporizador
    IEnumerator CorrutinaTemporizador()
    {

        // esperar 2.5 segundos
        yield return new WaitForSeconds(2.5f);

        // imprimir mensaje
        print("HOLA DESDE LA CORRUTINA");
    }

    // lógica recurrente
    IEnumerator CorrutinaRecurrente()
    {

        // de manera recurrente ...
        while(true)
        {
            // imprimir mensaje
            print("CORRUTINA RECURRENTE");

            // esperar 3.4 segundos
            yield return new WaitForSeconds(3.4f);
        }
    } 

    IEnumerator CorrutinaDisparo()
    {
        while(true)
        {
            // al instanciar podemos guardar referencia al recién creado
            // para lo que se ofrezca
            // GameObject elNuevo = Instantiate(_balaOriginal);
            // elNuevo.transform.position = Vector3.zero;

            Instantiate(
                _balaOriginal,
                _referencia.position,
                _referencia.rotation
            );

            yield return new WaitForSeconds(0.7f);
        }
    }
}
