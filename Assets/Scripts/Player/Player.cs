using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _HP = 100;

    public void TakeDamage(float damage)
    {
        _HP -= damage;
        if(_HP<0)_HP = 0;
    }
    public void GetHealth(float health)
    {
        _HP += health;
        if(_HP>100)_HP = 100;
    }
    public float CurHP()=>_HP;
}