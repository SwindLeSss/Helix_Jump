using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;
    public GameObject[] childRings;

    
    public float radius = 100f;
    public float force = 500f;

    private void Start() 
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() 
    {
        
        if (transform.position.y > player.position.y) 
        {
            GameManager.noOfPassingRings++;
            FindObjectOfType<AudioManager> ().Play ("Whoosh");
            for (int i = 0; i < childRings.Length; i++) 
            {
                
                Rigidbody rb = childRings[i].GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;

                    
                    rb.AddExplosionForce(force, transform.position, radius);
                }

                childRings[i].GetComponent<MeshCollider>().enabled = false;
                childRings[i].transform.parent = null;
                Destroy(childRings[i], 5f);
            }

            
            Destroy(this.gameObject, 6f);
            this.enabled = false;
        }
    }
}