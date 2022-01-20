using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotString : MonoBehaviour
{
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] Transform back;
    [SerializeField] Transform player;
    LineRenderer lr;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();

    }

    
    void Update()
    {
        if (player.position.z < 25f)
        {
            back.position = player.position+new Vector3(0,1f,-.5f);
        }
        else
            back.position =new Vector3(1.29999995f, 72f, 22f);

        lr.SetPositions(new Vector3[3] {left.position,back.position,right.position });
    }
}
