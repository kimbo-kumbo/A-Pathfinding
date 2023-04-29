using System.Collections.Generic;
using UnityEngine;

public class APathFinding : MonoBehaviour
{
    public Tile _startPoint;
    public Tile _currentPoint;
    public Tile _endPoint;
    public CreateTileField _createTileField;

    public Dictionary<Tile, float> _open_ListTile = new Dictionary<Tile, float>(); //открытый список клеток
    public List<Tile> _closed_ListTile = new List<Tile>(); //закрытый список клеток    


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        PathFinding();
    }

    public void PathFinding()
    {
        //очищаем оба списка
        _open_ListTile.Clear();
        _closed_ListTile.Clear();        
        //назначаем текущую клетку стартовой
        _currentPoint = _startPoint;
        //добавляем в закрытый список стартовую точку 
        _closed_ListTile.Add(_startPoint);
        //добавляем в закрытый список все клетки помеченные препятствиями
        foreach(Tile tile in _createTileField._tileExamples)
        {
            if(tile.mesh.material.color == Color.red)
            {
                _closed_ListTile.Add(tile);
            }
        }        
        
        //добавляем соседние точки в открытые список        
        foreach (Tile tile in _startPoint._tileNear)
        {
            if (tile.mesh.material.color == Color.red) continue;
            _open_ListTile.Add(tile, CalculationWeightTile(tile.transform, _endPoint.transform));
            tile._previosPoint = _currentPoint;
        }       
    }

    private float CalculationWeightTile(Transform nearTile , Transform endTile)
    {
       float distanceToNearTile =  Mathf.Abs(transform.position.x - nearTile.position.x) + Mathf.Abs(transform.position.z - nearTile.position.z);
       float distanceToEndTile =  Mathf.Abs(endTile.position.x - nearTile.position.x) + Mathf.Abs(endTile.position.z - nearTile.position.z);
       return distanceToNearTile + distanceToEndTile;
    }
}