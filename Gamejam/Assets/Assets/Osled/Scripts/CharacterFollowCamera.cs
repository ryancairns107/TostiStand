using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollowCamera : MonoBehaviour
{
    public GameObject character = null;
    public float followDistance = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((character.transform.position.x - transform.position.x) > followDistance) {
            transform.position = new Vector3(character.transform.position.x - followDistance, transform.position.y, transform.position.z);
        }
        if ((character.transform.position.x - transform.position.x) < -followDistance) {
            transform.position = new Vector3(character.transform.position.x + followDistance, transform.position.y, transform.position.z);
        }
    }
}
