using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolGuySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject coolGuyPrefab = null;
    [SerializeField]
    private float spawnRadius;
    [SerializeField]
    private int numOfCoolGuys;

    private GameObject player;
    private List<MovementController> controllers = new List<MovementController>();
    private bool captured = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for(int i = 0; i < numOfCoolGuys; i++)
        {
            GameObject guy = Instantiate(coolGuyPrefab, this.transform);
            MovementController controller = guy.GetComponent<MovementController>();
            controller.SetTarget(this.gameObject);
            controller.SetAllowedDistance(spawnRadius);
            controllers.Add(controller);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawnerEntered()
    {
        if(!captured)
        {
            captured = true;
            PlayerState pState = player.gameObject.GetComponent<PlayerState>();
            pState.AddFollowers(controllers.Count);
            foreach (MovementController controller in controllers)
            {
                controller.SetTarget(player);
            }
        }
    }
}
