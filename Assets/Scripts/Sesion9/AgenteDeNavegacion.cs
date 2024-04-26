using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgenteDeNavegacion : MonoBehaviour
{
    private NavMeshAgent _agentito;
    // Start is called before the first frame update
    void Start()
    {
        _agentito = GetComponent<NavMeshAgent>();
        _agentito.destination = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // hacer click para mover
        // usando raycast! 
        if(Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // out parameter c#
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out
            if(Physics.Raycast(rayo, out hit))
            {
                // quiero obtener el punto donde colisionó
                _agentito.destination = hit.point;
            }
        }   
    }
}
