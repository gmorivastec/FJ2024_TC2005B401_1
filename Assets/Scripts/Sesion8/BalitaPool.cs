using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BalitaPool : MonoBehaviour
{
    public static BalitaPool Instance
    {
        get;
        private set;
    }

    // pool - biblioteca centralizada de game objects
    // de donde vamos a solicitar y vamos a regresar objetos prestados
    // - evitarmos construir y destruir 

    // el objeto original!
    [SerializeField] 
    private GameObject _original;

    [SerializeField]
    private int _poolSize = 10;

    private Queue<GameObject> _pool;

    void Awake()
    {
        // pseudo singleton
        if(Instance == null)
            Instance = this;
        else 
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_original, "ORIGINAL ES NULO EN POOL");
        _pool = new Queue<GameObject>();

        // creación original de objetos
        for(int i = 0; i < _poolSize; i++)
        {
            GameObject actual = Instantiate(_original);
            actual.SetActive(false);
            _pool.Enqueue(actual);
        }
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        // obtener objeto de pool
        GameObject actual = _pool.Dequeue();

        // modificar posición
        actual.transform.position = position;

        // modificar rotación
        actual.transform.rotation = rotation;

        // habilitar objeto de vuelta
        actual.SetActive(true);

        // agregar una corrutina de "destrucción"
        StartCoroutine(ReturnObjectCorrutine(actual, 3));

        // regresar objeto
        return actual;
    }

    public void ReturnObject(GameObject gameObject)
    {
        // deshabilitar objeto
        gameObject.SetActive(false);

        // guardar en queue
        _pool.Enqueue(gameObject); 
    }

    IEnumerator ReturnObjectCorrutine(GameObject gameObject, float time)
    {
        // esperamos los segundos para regresar
        yield return new WaitForSeconds(time);

        ReturnObject(gameObject);
    }
}
