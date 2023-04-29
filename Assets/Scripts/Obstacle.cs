using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Tile tile))
        {
            tile.mesh.material.color = Color.red;                
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.TryGetComponent(out Tile tile))
        {
            tile.mesh.material.color = Color.white;                
        }
    }
}
