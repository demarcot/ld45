using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    private int followers = 0;

    [SerializeField]
    private Text followersText = null;
    private const string followersMessage = "Cool Cat Followers: "; 



    // Start is called before the first frame update
    void Start()
    {
        followersText.text = followersMessage + followers.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFollowers(int followers)
    {
        this.followers += followers;
        followersText.text = followersMessage + GetPlayerCount().ToString();
    }

    public int GetPlayerCount()
    {
        return followers;
    }
}
