using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    // [SerializeField, Range(1, 8)]
    // int depth = 4;
    public Mesh mesh;
    public Material material;

    public int maxDepth = 4;

    public float childScale = 0.5f;

    bool isAnimating = true;
    bool isTrigger = true;
    int depth = 0;
    // Start is called before the first frame update
    async void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth < maxDepth) StartCoroutine(createChildren());

        // GameObject parent  = new GameObject("Some Name Here");
        // parent.transform.position = new Vector3(0, 10, 0);

        // GameObject child  = new GameObject("child");
        // child.transform.parent = parent.transform; // worldPosStays = true
        // //child.transform.SetParent(parent.transform, false);
        // //child.transform.localScale = 0.5f * Vector3.up;
        // Debug.Log("position is " + child.transform.position);
        // Debug.Log("local pos is " + child.transform.localPosition);
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
    }

    private IEnumerator createChildren(){
        yield return new WaitForSeconds(0.5f);
        new GameObject("child").AddComponent<Fractal>().Initialize(this, Vector3.up);
        yield return new WaitForSeconds(0.5f);
        new GameObject("child").AddComponent<Fractal>().Initialize(this, Vector3.left);

    }

    private async void Initialize(Fractal parent, Vector3 direction) {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        childScale = parent.childScale;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = direction * (0.5f + 0.5f * childScale);

        // if (direction.Equals(Vector3.left)) {
        //     transform.localScale = new Vector3(1f, 0.8f, 1f);
        //     transform.localPosition = new Vector3(-1f, -0.1f, 0f);
        // } else {
        //     transform.localScale = new Vector3(0.8f, 0.2f, 1f);
        //     transform.localPosition = new Vector3(0.1f, 0.6f, 0f);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimating) transform.Rotate(0f, 30f * Time.deltaTime, 0f);
        this.GetComponent<BoxCollider>().isTrigger = isTrigger;
    }

    public void toggleIsAnimating() {
        isAnimating = !isAnimating;
    }

    public void SetTrigger(bool b) {
        //Debug.Log("fractal isTrigger " + isTrigger);
        isTrigger = b;
    }
}
