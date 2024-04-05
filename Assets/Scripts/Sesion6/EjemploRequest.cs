using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EjemploRequest : MonoBehaviour
{

    // vamos a hacer request a server y parsear respuesta en JSON
    // JSON?
    // Javascript Object Notation
    // formato de intercambio de datos
    // todos los datos están guardados en estructuras llave:valor
    // los datos son contenidos dentro de un objeto delimitado por {}
    // además de objetos tenemos arreglos delimitados por []
    // se pueden anidar / mezclar arbitrariamente


    // Start is called before the first frame update
    void Start()
    {
        // un json como raiz debe tener un objeto o un arreglo
        // con el parser que usa unity debe ser objeto

        // escapar caracteres en string 
        // caracteres que pueden ser interpretados como parte de un lenguaje 
        // se necesitan escapar (poner llave inversa antes del caracter)
        // para indicar que queremos utilizarlo dentro de un string
        string json = "{\"name\": \"ai1\", \"more_info\": 8}";
        string json2 = "{\"all_ai\": [" + 
        "{\"name\": \"ai1\", \"more_info\": 8}," +
        "{\"name\": \"ai2\", \"more_info\": 9}," +
        "{\"name\": \"ai3\", \"more_info\": 10}" +
        "]}";

        // para poder utilizarlo hay que interpretar el texto de manera 
        // que se traduzca a datos usables en nuestro lenguaje
        // esto se logra por medio de un parser
        AI ai = JsonUtility.FromJson<AI>(json);

        print(ai.name);
        print(ai.more_info);

        string aiStr = JsonUtility.ToJson(ai);
        print(aiStr);

        AllAI arreglito = JsonUtility.FromJson<AllAI>(json2);

        foreach(AI actual in arreglito.all_ai)
        {
            print(actual.name + " " + actual.more_info);
        }

        // hacer request 
        // request es código asíncrono 
        // para lidiar con asincronía en unity usamos corrutinas
        StartCoroutine(HacerRequest("https://raw.githubusercontent.com/gmorivastec/jsons/main/ai.json"));
    }

    IEnumerator HacerRequest(string url)
    {
        // using se asegura de destruir un objeto que sea 
        // "disposable" al finalizar las llaves 
        using(UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            // vamos a llegar aquí hasta que esté resuelto el request
            switch(request.result)
            {

                case UnityWebRequest.Result.Success:
                    string result = request.downloadHandler.text;
                    AllAI ais = JsonUtility.FromJson<AllAI>(result);
                    foreach(AI current in ais.all_ai)
                    {
                        print("REQUEST: " + current.name + " " + current.more_info);
                    }
                    break;
                default:
                    print("ERROR AL HACER REQUEST");
                    break;
            }
        }
    }

    
}
