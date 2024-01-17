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

    public bool componentsShown { get; private set; }
    public bool mainVectorShown { get; private set; }

    private void Awake()
    {
        mainVector = Instantiate(vectorPrefab);
        mainVector.transform.SetParent(transform, false);
        mainVectorScript = mainVector.GetComponent<Vector>();

        componentVectors = new GameObject[componentAxes.Length];
        for (int i = 0; i<componentAxes.Length; i++)
        {
            componentVectors[i] = Instantiate(componentVectorPrefab);
            componentVectors[i].transform.SetParent(transform, false);
            ComponentVector componentScript = componentVectors[i].GetComponent<ComponentVector>();
            componentScript.mainVector = mainVectorScript;
            componentScript.axis = componentAxes[i];
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void toggleMainVector(bool visible)
    {
        this.mainVectorShown = visible;
        mainVector.SetActive(visible);
    }
    void toggleComponents(bool visible)
    {
        this.componentsShown = visible;
        foreach (GameObject component in componentVectors)
        {
            component.SetActive(visible);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
