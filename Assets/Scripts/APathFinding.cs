using System.Collections.Generic;
using UnityEngine;

public class APathFinding : MonoBehaviour
{
    public Tile _startPoint;
    public Tile _currentPoint;
    public Tile _endPoint;
    public CreateTileField _createTileField;

    public Dictionary<Tile, float> _open_ListTile = new Dictionary<Tile, float>(); //�������� ������ ������
    public List<Tile> _closed_ListTile = new List<Tile>(); //�������� ������ ������    


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        PathFinding();
    }

    public void PathFinding()
    {
        //������� ��� ������
        _open_ListTile.Clear();
        _closed_ListTile.Clear();        
        //��������� ������� ������ ���������
        _currentPoint = _startPoint;
        //��������� � �������� ������ ��������� ����� 
        _closed_ListTile.Add(_startPoint);
        //��������� � �������� ������ ��� ������ ���������� �������������
        foreach(Tile tile in _createTileField._tileExamples)
        {
            if(tile.mesh.material.color == Color.red)
            {
                _closed_ListTile.Add(tile);
            }
        }        
        
        //��������� �������� ����� � �������� ������        
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