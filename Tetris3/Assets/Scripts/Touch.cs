using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    DeleteBlock db;

    void Start()
    {
        db = GetComponent<DeleteBlock>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {            
            if(db!=null) db.touching[0]++;        // 왜 null인지;
    }
}
