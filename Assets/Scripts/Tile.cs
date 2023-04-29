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
    /// ID �����
    /// </summary>
    public int _iD;    
    /// <summary>
    /// ������ �������� �����
    /// </summary>
    public List<Tile> _tileNear;    
    /// <summary>
    /// T���� �� ������� ������ � �������
    /// </summary>
    public Tile _previosPoint;   

}