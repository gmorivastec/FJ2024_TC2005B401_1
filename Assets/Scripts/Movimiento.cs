// esto es como los imports 
// se importan "namespaces"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class Movimiento : MonoBehaviour
{

    // variables de instancia 
    // se pueden utilizar para parametrizar comportamiento
    // para poder mostrar un parámetro en editor debe ser 
    // - primitivo
    // - objeto serializable 

    // yo quiero que mis atributos tngan el modificador de acceso más restrictivo
    // posible

    [SerializeField]
    private float _velocidadDelObjeto = 5;

    Transform _transformito;

    // ciclo de vida 
    // paradigma en donde la lógica que nosotros definimos
    // está siendo inyectada en momentos específicos de la ejecución
    // de un script

    void Awake()
    {
        // se invoca una sola vez después de la creación del objeto
        Debug.Log("AWAKE");
    }

    // Start is called before the first frame update
    void Start()
    {
        // una sola vez después de awake antes de empezar el loop de update
        print("START");

        // SÓLO TRANSFORM SE PUEDE ACCEDER "MÁGICAMENTE"
        // (ya está predefinido, ya está prepoblado)

        // cómo obtener referencia a un componente
        // generic - mecanismo para parametrizar tipos
        // utiliza el diamante <>
        _transformito = GetComponent<Transform>();

        // nota - siempre que tengas un componente que pueda ser nulo
        // normalmente un atríbuto serializado u obtenido de getcomponent
        // hay que checar que no sea nulo
        Assert.IsNotNull(_transformito, "TRANSFORMITO FUE NULL!");
    }

    // Update is called once per frame
    // qué es un frame?!

    // IMPORTANTE PARA EL PERFORMANCE:
    // entre más ligero el update más rápida la ejecución
    // entre más rápida la ejecución de update más FPS!!!

    // el update siempre tiene que ser lo más magro posible
    // y si es posible no usarlo

    // con qué usar update:
    // 1. entrada de jugador
    // 2. movimiento
    void Update()
    {
        // lógica que se repite por cuadro
        // print("UPDATE");

        // 2 maneras de usar input:
        // 1. polling directo al dispositivo
        // 2. utilizando ejes de entrada

        // true - frame anterior libre, frame actual presionado
        if(Input.GetKeyDown(KeyCode.A))
        {
            print("KEYDOWN A");
        }

        // true - frame anterior presionada, frame actual presionada
        if(Input.GetKey(KeyCode.A))
        {
            print("KEY A");
        }

        // true - frame anterior presionada, frame actual libre
        if(Input.GetKeyUp(KeyCode.A))
        {
            print("KEYUP A");
        }

        if(Input.GetMouseButtonDown(0))
        {
            print("CLICK!");
        }

        // 2do approach - ejes
        // capa de abstracción de hardware

        // en lugar de sondear directamente un dispositivo
        // lo hacemos a un eje
        // posibles valores de un eje - [-1, 1]
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // podemos sondear el valor de un eje como si fuera un botón
        if(Input.GetButtonDown("Jump"))
        {
            print("JUMP");
        }

        // si queremos entrada sin suavizado
        // float horizontal = Input.GetAxisRaw("Horizontal");
        // print(horizontal);

        // NOTA - siempre recuerda que un script es un componente 
        // componente ? 
        // cada componente se encarga de lógica particular
        // podemos utilizar otros componentes para lograr algo que queremos
        // por ejemplo: mover un objeto

        // para mover usamos transform
        // transform (con minúscula) - objeto que hace referencia al componente transform
        // Del mismo game object

        // el movimiento en update NO es regular 
        // depende del desempeño
        // Time.deltaTime - tiempo transcurrido entre el cuadro anterior y el actual
        /*
        transform.Translate(
            _velocidadDelObjeto * horizontal * Time.deltaTime, 
            _velocidadDelObjeto * vertical * Time.deltaTime, 
            0
        );
*/
        _transformito.Translate(
            _velocidadDelObjeto * horizontal * Time.deltaTime, 
            _velocidadDelObjeto * vertical * Time.deltaTime, 
            0
        );
    }

    // update que corre en intervalos regulares
    void FixedUpdate()
    {
        // print("FIXED UPDATE");
    }

    // sucede siempre al final de los updates
    void LateUpdate()
    {
        // print("LATE UPDATE");
    }

    // COLISIONES
    // tanto en movimiento como en colisiones tenemos alternativas
    // (CharacterController)

    // por lo pronto vamos a usar el motor de física para detección de colisiones
    // condiciones para que exista una colision:
    // - 2 o más objetos (obviamente.)
    // - todos los gameobjects involucrados tienen collider
    // - al menos el objeto que se mueve tiene rigidbody

    // rigidbody - componente que se encarga de suscribir a un objeto
    // al motor de la física
}
