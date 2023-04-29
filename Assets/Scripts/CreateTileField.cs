using System.Collections.Generic;
using UnityEngine;

public class CreateTileField : MonoBehaviour
{
    [SerializeField] private Tile _prefabTile;
    private int _currentId = 1;
    private int _resolutionField;
    public List<Tile> _tileExamples = new List<Tile>();

    private void Start()
    {
        GenerateField();
        FindNearTile();
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
                Tile pref = Instantiate(_prefabTile, transform);
                pref.name = $"Tile{_currentId}";
                _tileExamples.Add(pref);
                pref.transform.position = startPoint;
                startPoint = pref.transform.position + new Vector3(directionGeneration, 0, 0);
                pref._iD = _currentId;
                pref._id.text = pref._iD.ToString();
                _currentId++;
            }
            startPoint += new Vector3(-_resolutionField, 0, directionGeneration);
        }

    }

    private void FindNearTile() //находим соседние клетки для каждой клетки
    {
        foreach (Tile curentTile in _tileExamples)
        {
            foreach (Tile tile in _tileExamples)
            {
                if (curentTile.transform == tile.transform) continue;
                float absX = Mathf.Abs(curentTile.transform.position.x - tile.transform.position.x);
                float absZ = Mathf.Abs(curentTile.transform.position.z - tile.transform.position.z);
                float absTargetValue = _prefabTile.transform.localScale.x;

                if ((absX == absTargetValue && absZ == absTargetValue) || (absX == absTargetValue && absZ == 0) || (absX == 0 && absZ == absTargetValue))
                {
                    curentTile._tileNear.Add(tile);
                }
            }
        }
    }
}