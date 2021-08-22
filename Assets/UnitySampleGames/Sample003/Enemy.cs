using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp = 20;
    
    private void Update()
    {
        if (Hp <= 0)
            Destroy(this.gameObject);
    }
}