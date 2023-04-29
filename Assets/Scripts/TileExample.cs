using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileExample : MonoBehaviour
{
    public int _iD;
    public Text _idText;
    public List<int> _idTileNear;
    public MeshRenderer mesh;   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Position_Marker>() != null && mesh.material.color != Color.red)
           mesh.material.color = Color.yellow;
        if(other.gameObject.GetComponent<Obstacle_Marker>() != null)
            mesh.material.color = Color.red;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Position_Marker>() && mesh.material.color != Color.red || other.gameObject.GetComponent<Obstacle_Marker>())                
            mesh.material.color = Color.white;
    }
}