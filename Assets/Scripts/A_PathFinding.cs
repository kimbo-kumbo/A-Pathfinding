using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class A_PathFinding : MonoBehaviour
{
    [SerializeField] private TileExample _prefabTile;
    private int _currentId = 1;
    private int _resolutionField;        
    private List<TileExample> _tileExamples = new List<TileExample>();

    private void Start()
    {
        GenerateField();
        FindNearTile();

        foreach(TileExample example in _tileExamples)
        {
            if(example._iD == 91)
            {
                foreach(int example2 in example._idTileNear)
                {
                    Debug.Log(example2);
                }
            }
        }
    }

    private void GenerateField() //генерируем поле
    {
        _resolutionField = (int)gameObject.transform.localScale.x * 10;
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        float directionGeneration = _prefabTile.transform.localScale.x;
        float startPointScale = gameObject.transform.localScale.x;
        Vector3 startPoint = meshFilter.mesh.vertices[meshFilter.mesh.vertices.Length - 1] * startPointScale + new Vector3((directionGeneration / 2), 0, (directionGeneration / 2));

        for (int i = 0; i < _resolutionField; i++)
        {
            for (int j = 0; j < _resolutionField; j++)
            {
                TileExample pref = Instantiate(_prefabTile, transform);
                _tileExamples.Add(pref);
                pref.transform.position = startPoint;
                startPoint = pref.transform.position + new Vector3(directionGeneration, 0, 0);
                pref._iD = _currentId;
                pref._idText.text = pref._iD.ToString();
                _currentId++;
            }
            startPoint += new Vector3(-_resolutionField, 0, directionGeneration); //задаём новые координаты для стартовой точки генераци
        }

    }

    private void FindNearTile()
    {
        foreach(TileExample tile in _tileExamples)
        {
            if(tile == _tileExamples[0])
            {
                tile._idTileNear.Add(_tileExamples[1]._iD);
                tile._idTileNear.Add(_tileExamples[_resolutionField]._iD);
                tile._idTileNear.Add(_tileExamples[_resolutionField+1]._iD);
            }
            else if(tile == _tileExamples[_resolutionField-1])
            {
                tile._idTileNear.Add(_tileExamples[_resolutionField - 2]._iD);
                tile._idTileNear.Add(_tileExamples[_resolutionField + _resolutionField-1]._iD);
                tile._idTileNear.Add(_tileExamples[_resolutionField + _resolutionField-2]._iD);                
            }
            else if(tile == _tileExamples[_tileExamples.Count - 1])
            {
                tile._idTileNear.Add(_tileExamples[_tileExamples.Count - 2]._iD);
                tile._idTileNear.Add(_tileExamples[_tileExamples.Count - _resolutionField -1]._iD);
                tile._idTileNear.Add(_tileExamples[_tileExamples.Count - _resolutionField -2]._iD);
            }
            else if(tile == _tileExamples[_tileExamples.Count - _resolutionField ])
            {
                tile._idTileNear.Add(_tileExamples[_tileExamples.Count - _resolutionField + 1]._iD);
                tile._idTileNear.Add(_tileExamples[_tileExamples.Count - _resolutionField - _resolutionField]._iD);
                tile._idTileNear.Add(_tileExamples[_tileExamples.Count - _resolutionField - _resolutionField +1]._iD);
            }
            /*else
            {
                tile._idTileNear.Add(_tileExamples[tile._iD +1]._iD);
                tile._idTileNear.Add(_tileExamples[tile._iD -1]._iD);
                tile._idTileNear.Add(_tileExamples[tile._iD + _resolutionField]._iD);
                tile._idTileNear.Add(_tileExamples[tile._iD - _resolutionField]._iD);
                tile._idTileNear.Add(_tileExamples[tile._iD + _resolutionField+1]._iD);
                tile._idTileNear.Add(_tileExamples[tile._iD - _resolutionField+1]._iD);
                tile._idTileNear.Add(_tileExamples[tile._iD + _resolutionField-1]._iD);
                tile._idTileNear.Add(_tileExamples[tile._iD - _resolutionField-1]._iD);
            }-*/

        }

    }
}
