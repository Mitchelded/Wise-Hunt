using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHero : MonoBehaviour
{

    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void ReturnHeroToSpawn()
    {
        player.position = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
