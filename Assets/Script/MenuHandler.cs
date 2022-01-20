using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject winText;
    
    private void Start()
    {
        
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {

        
    }
    private void OnCollisionStay(Collision collision)
    {
        
          if( collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude<.1f && collision.gameObject.CompareTag("cube"))
        {
            winText.SetActive(true);
            Food.scoreP += 75;
        }
        
       

    }
    
}
