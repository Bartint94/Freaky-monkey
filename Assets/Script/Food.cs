using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] TextMeshProUGUI score;
    public static int scoreP = 0;
    private void Update()
    {
        transform.Rotate(new Vector3(0,1, 0)*rotationSpeed*Time.deltaTime);
        score.text = $"Score:{scoreP}";
    }


    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(other != null)
        scoreP += 8;
    }
    
}
