using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public MeshRenderer mesh;
    public Text _id;
    public Text _distanceToNear;
    public Text _distanceToEndTile;
    public Text _weightTile;
    /// <summary>
    /// ID точки
    /// </summary>
    public int _iD;    
    /// <summary>
    /// список соседних точек
    /// </summary>
    public List<Tile> _tileNear;
    /// <summary>
    /// Tочка из которой пришли в текущую
    /// </summary>
    public Tile _previosPoint;

    public void RestorePath(List<Tile> path)
    {        
        path.Add(this);
        if(_previosPoint != null)
        {
            _previosPoint.RestorePath(path);
            _previosPoint.mesh.material.color = Color.green;
        }        
    }
}