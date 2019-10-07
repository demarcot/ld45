using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolnessBarrier : MonoBehaviour
{

    [SerializeField]
    private int requiredFollowers;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Text>().text = requiredFollowers.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(requiredFollowers <= collision.gameObject.GetComponent<PlayerState>().GetPlayerCount())
            {
                Destroy(this.gameObject);
            }
        }
    }
}
