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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for(int i = 0; i < numOfCoolGuys; i++)
        {
            GameObject guy = Instantiate(coolGuyPrefab, this.transform);
            Vector3 v = guy.transform.position + new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), 0.0f);
            guy.transform.position = v;
            MovementController controller = guy.GetComponent<MovementController>();
            controller.SetTarget(this.gameObject);
            controllers.Add(controller);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawnerEntered()
    {
        PlayerState pState = player.gameObject.GetComponent<PlayerState>();
        pState.AddFollowers(controllers.Count);
        foreach (MovementController controller in controllers)
        {
            controller.SetTarget(player);
        }
    }
}
