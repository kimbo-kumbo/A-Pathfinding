using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PathFinding : MonoBehaviour
{
    private int _currentId = 1;
    private int _resolutionField;
    public TileExample _prefabTile;    
    public List<TileExample> tileExamples = new List<TileExample>();

    private void Start()
    {
        _resolutionField = (int)gameObject.transform.localScale.x * 10;
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();        
        float directionGeneration = _prefabTile.transform.localScale.x;
        float startPointScale = gameObject.transform.localScale.x;
        Vector3 startPoint = meshFilter.mesh.vertices[meshFilter.mesh.vertices.Length-1] * startPointScale + new Vector3((directionGeneration / 2), 0, (directionGeneration / 2));        
             
        for (int i = 0; i < _resolutionField; i++) //генерируем поле
        {
            for (int j = 0; j < _resolutionField; j++)
            {
                TileExample pref = Instantiate(_prefabTile,transform);
                pref.transform.position = startPoint;
                startPoint = pref.transform.position + new Vector3(directionGeneration, 0, 0);
                pref._iD = _currentId;
                pref._idText.text = pref._iD.ToString();
                _currentId++;
            }
            startPoint += new Vector3(-_resolutionField, 0, directionGeneration); //задаём новые координаты для стартовой точки генераци
            
        }

    }
}
