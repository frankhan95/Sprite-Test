using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    Transform player;

    // Use this for initialization
    void Start () {
        GameObject WalterGO = GameObject.FindWithTag("Player");
        if(WalterGO != null)
        {
            player = WalterGO.GetComponent<Transform>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        {
            this.transform.position = player.position + new Vector3(0, 0, -10);
            print("found");
        }
	
	}
}
