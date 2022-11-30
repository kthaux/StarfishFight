using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;

    public string attackColor;
    public string timeColor;
    public string moveColor;
    public Vector2Int position;

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Debug.Log("Unit has died");
        }
    }

    public void SetPosition(Vector2Int pos)
    {
        position = pos;
    }

    public void SetAttackColor(string color)
    {
        attackColor = color;
    }

    public void SetTimeColor(string color)
    {
        timeColor = color;
    }

    public void SetMoveColor(string color)
    {
        moveColor = color;
    }
}
