using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public MeshRenderer mesh;
    public Text _idText;
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

}