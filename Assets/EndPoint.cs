using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private APathFinding _aPathFinding;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Tile tile))
        {
            if (tile.mesh.material.color != Color.red)
                tile.mesh.material.color = Color.green;
            _aPathFinding._endPoint = tile; //передаём конечную клетку
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.TryGetComponent(out Tile tile))
        {
            if (tile.mesh.material.color != Color.red)
                tile.mesh.material.color = Color.white;
        }
    }
}