using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class APathFinding : MonoBehaviour
{
    /// <summary>
    /// ���� �� ��������� ����� �� ��������
    /// </summary>
    public List<Tile> _pathPoint = new List<Tile>();
    public Tile _startPoint;
    public Tile _currentPoint;
    public Tile _endPoint;
    public CreateTileField _createTileField;

    public Dictionary<Tile, float> _open_ListTile = new Dictionary<Tile, float>(); //�������� ������ ������
    public List<Tile> _closed_ListTile = new List<Tile>(); //�������� ������ ������    

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PathFinding();
    }

    public void PathFinding()
    {
        //������� ��� ������
        _open_ListTile.Clear();
        _closed_ListTile.Clear();        
        //��������� ������� ������ ���������
        _currentPoint = _startPoint;        
        //��������� � �������� ������ ��� ������ ���������� �������������
        foreach(Tile tile in _createTileField._tileExamples)
        {
            if (tile.mesh.material.color == Color.red)
            {
                _closed_ListTile.Add(tile);
                continue;
            }
            if (tile.mesh.material.color == Color.yellow) continue;           

                tile.mesh.material.color = Color.white;
            

        }

       /* foreach(Tile tile in _currentPoint._tileNear)
        {
            if (tile.mesh.material.color == Color.red)
            {
                _open_ListTile.Add(tile, CalculationWeightTile(_currentPoint, tile, _endPoint));
            }
        }*/

        //��������� � �������� ������ ��������� �����         
        _closed_ListTile.Add(_currentPoint);

        StartCoroutine(TestCoroutine());
        
        //while (_currentPoint != _endPoint)
        //{
        //    FindPath();
        //}
    }

    IEnumerator TestCoroutine()
    {
        while (_currentPoint != _endPoint)
        {
           
            foreach (Tile tile in _currentPoint._tileNear)
            {
                //if (tile.mesh.material.color == Color.red) continue; //�������� �������� �� ID////////////////////////////////////
                if (_closed_ListTile.Contains(tile)) continue;
                if (_open_ListTile.ContainsKey(tile))
                {
                    float newF = CalculationWeightTile(_currentPoint, tile, _endPoint);
                    float oldF = _open_ListTile[tile];
                    if (newF < oldF) tile._previosPoint = _currentPoint;
                    yield return new WaitForSeconds(0.3f);
                    continue;
                }
                _open_ListTile.Add(tile, CalculationWeightTile(_currentPoint, tile, _endPoint));
                tile._previosPoint = _currentPoint; //���������� ��� ������ ������ ������ ������ �� ������� ������
                yield return new WaitForSeconds(0.3f);
            }


            //Debug.Log(sortedList.First().Key);
            _open_ListTile.Remove(_currentPoint);
            _closed_ListTile.Add(_currentPoint); //��������� ����������(������������) ������ � �������� ������
            _currentPoint.mesh.material.color = Color.grey;
            var sortedList = _open_ListTile.OrderBy(p => p.Value); //��������� ��������� �������� �������� ������ �� �����������
            _currentPoint = sortedList.First().Key; //�������� ����� ������ �� ������� ������ � ��������� ���������� ����
            if (_currentPoint == _endPoint)
            {
                _pathPoint.Clear();
                _endPoint.RestorePath(_pathPoint);
                foreach (Tile tile in _pathPoint)
                {
                    Debug.Log(tile._iD);
                }
            }
            //FindPath();
        }
    }

    public void FindPath()
    {
        //��������� �������� ����� � �������� ������
        //foreach (Tile tile in _currentPoint._tileNear)
        //{
        //    //if (tile.mesh.material.color == Color.red) continue; //�������� �������� �� ID////////////////////////////////////
        //    if (_closed_ListTile.Contains(tile)) continue;
        //    if (_open_ListTile.ContainsKey(tile))
        //    {
        //        float newF = CalculationWeightTile(_currentPoint, tile, _endPoint);
        //        float oldF = _open_ListTile[tile];
        //        if(newF < oldF) tile._previosPoint = _currentPoint;
        //        continue;
        //    }
        //    _open_ListTile.Add(tile, CalculationWeightTile(_currentPoint, tile, _endPoint));
        //    tile._previosPoint = _currentPoint; //���������� ��� ������ ������ ������ ������ �� ������� ������
        //}

        
        ////Debug.Log(sortedList.First().Key);
        //_open_ListTile.Remove(_currentPoint);
        //_closed_ListTile.Add(_currentPoint); //��������� ����������(������������) ������ � �������� ������
        //_currentPoint.mesh.material.color = Color.grey;
        //var sortedList = _open_ListTile.OrderBy(p => p.Value); //��������� ��������� �������� �������� ������ �� �����������
        //_currentPoint = sortedList.First().Key; //�������� ����� ������ �� ������� ������ � ��������� ���������� ����
        //if(_currentPoint == _endPoint)
        //{
        //    _pathPoint.Clear();
        //    _endPoint.RestorePath(_pathPoint);
        //    foreach(Tile tile in _pathPoint)
        //    {
        //        Debug.Log(tile._iD);    
        //    }
        //}
    }

    private float CalculationWeightTile(Tile curentTile,Tile nearTile , Tile endTile)
    {
        //���������� ��������� �� ������ ��������� (�������� ���������� ������)
        float distanceToNearTile = Mathf.Round(Mathf.Abs(curentTile.transform.position.x - nearTile.transform.position.x) + Mathf.Abs(curentTile.transform.position.z - nearTile.transform.position.z));
        float distanceToEndTile = Mathf.Round(Mathf.Abs(nearTile.transform.position.x - endTile.transform.position.x) + Mathf.Abs(nearTile.transform.position.z - endTile.transform.position.z));
        float weightTile = distanceToNearTile + distanceToEndTile;

        nearTile._distanceToNear.text = distanceToNearTile.ToString();
        nearTile._distanceToNear.color = Color.blue;
        nearTile._distanceToEndTile.text = distanceToEndTile.ToString();
        nearTile._distanceToEndTile.color = Color.green;
        nearTile._weightTile.text = weightTile.ToString();        
        nearTile._weightTile.color = Color.red;        

        return weightTile;
    }
}