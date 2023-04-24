using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PathNode
{
    public int x;
    public int y;

    public int index;

    public int gCost; //��������� ����� ���������� ���� �� ���� ����
    public int hCost; //��������� ��������� �� ���� ���� �� �����
    public int fCost; //��������� ���� (g + h)

    public sbyte walkCost;//��������� ������������ �� ���� ������ (-1 - ������������ �� ��������)

    public int cameFromNodeIndex;

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
    public void SetWalkCost(sbyte cost)
    {
        walkCost = cost;
    }
}
