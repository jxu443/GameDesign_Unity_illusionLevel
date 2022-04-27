using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material;
    public Renderer PlayerRend;
    Vector3 scale;
    float explosionForce = 100f;
    float explosionRadius = 2f;
    float explosionUpward = 0.4f;
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
		{
			explode();
            PlayerRend.material = material;
		}

        Vector3 explosionPos = other.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                // explosionUpward: Adjust the apparent position of the explosion to make it seem to lift objects.
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    async void explode() {
        gameObject.SetActive(false);
        for (int x = 0; x < scale.x; x++) {
            for (int y = 0; y < scale.y-1; y++) {
                for (int z = 0; z < scale.z; z++) {
                    createPiece(x, y, z);
                }
            }
        } 
        
        
    }

    void createPiece(int x, int y, int z) {
        GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position + new Vector3(x-scale.x/2, y, z);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = 0.2f;
        Renderer rend = piece.GetComponent<Renderer>();
        rend.material = material;

    }
}
