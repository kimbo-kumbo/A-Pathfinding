using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class APathFinding : MonoBehaviour
{
    [SerializeField] private TileExample _prefabTile;
    private int _currentId = 1;
    private int _resolutionField;        
    private List<TileExample> _tileExamples = new List<TileExample>();

    public int _testID;
    private void Start()
    {
        GenerateField();
        FindNearTile();

        foreach(TileExample example in _tileExamples)
        {
            if(example._iD == _testID)
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
        foreach(TileExample curentTile in _tileExamples)
        {
            foreach(TileExample tile in _tileExamples)
            {
                if (curentTile.transform == tile.transform) continue;
                float absX = Mathf.Abs(curentTile.transform.position.x - tile.transform.position.x);
                float absZ = Mathf.Abs(curentTile.transform.position.z - tile.transform.position.z);
                float absTargetValue = _prefabTile.transform.localScale.x;

                if ((absX == absTargetValue && absZ == absTargetValue) || (absX == absTargetValue && absZ == 0) || (absX == 0 && absZ == absTargetValue)) 
                {
                    curentTile._idTileNear.Add(tile._iD);
                }
            }
        }

    }
}
