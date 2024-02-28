using UnityEngine;

public class VectorManager : MonoBehaviour
{
    [SerializeField] private GameObject vectorPrefab;
    [SerializeField] private GameObject componentVectorPrefab;

    [SerializeField]
    private Vector3[] componentAxes
        = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(0, 90, 0),
            new Vector3(0, 0, -90)
        };

    public GameObject mainVector;
    public Vector mainVectorScript;
    public GameObject[] componentVectors;
    public Vector[] componentVectorScripts;

    public float mainScale;
    public float componentScale = 5f;

    public bool componentsShown { get; private set; }
    public bool mainVectorShown { get; private set; }

    private void Awake()
    {
        mainVector = Instantiate(vectorPrefab);
        mainVector.transform.SetParent(transform, false);
        mainVectorScript = mainVector.GetComponent<Vector>();

        mainVectorScript.origin = this.transform;

        componentVectors = new GameObject[componentAxes.Length];
        componentVectorScripts = new Vector[componentAxes.Length];
        for (int i = 0; i<componentAxes.Length; i++)
        {
            componentVectors[i] = Instantiate(componentVectorPrefab);
            //componentVectors[i].transform.SetParent(transform, false);
            ComponentVector componentScript = componentVectors[i].GetComponent<ComponentVector>();
            componentScript.mainVector = mainVectorScript;
            componentScript.setAxis(componentAxes[i]);
            componentScript.scale = componentScale;

            Vector vectorScript = componentVectors[i].GetComponent<Vector>();
            componentVectorScripts[i] = vectorScript;
            vectorScript.origin = this.transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        showMainVector(true);
        showComponents(false);
    }

    void showMainVector(bool visible)
    {
        this.mainVectorShown = visible;
        mainVectorScript.setRender(visible);
    }
    void showComponents(bool visible)
    {
        this.componentsShown = visible;
        foreach (Vector component in componentVectorScripts)
        {
            Debug.Log(visible);
            component.setRender(visible);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
