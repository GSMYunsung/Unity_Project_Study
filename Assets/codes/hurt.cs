using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurt : MonoBehaviour
{
    bool isHurt;
    void Update()
    {
        
    }
    public void Hurt(int damage, Vector2 pos)
    {
        if (!isHurt)
        {
            isHurt = true;

        }
    }
}
