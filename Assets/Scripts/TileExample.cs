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
        mesh.material.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        mesh.material.color = Color.white;
    }
}