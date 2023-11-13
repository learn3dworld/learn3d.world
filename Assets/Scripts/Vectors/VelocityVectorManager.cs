using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityVectorManager : MonoBehaviour
{
    [SerializeField]
    private GameObject velocityPrefab;

    [SerializeField]
    private IVelocityReference velocityReference;

    [SerializeField]
    private float[] offsets = new float[] { 0, 0, 0 };
    [SerializeField]
    private Vector3[] directions
        = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(0, 90, 0),
            new Vector3(0, 0, -90)
        };
    [SerializeField]
    private Color[] colors = new Color[3];
    private GameObject[] vectors = new GameObject[3];
    private VelocityVector[] vectorScripts = new VelocityVector[3];
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i< vectors.Length; i++)
        {
            vectors[i] = Instantiate(velocityPrefab, Vector3.zero, Quaternion.identity);
            vectorScripts[i] = vectors[i].GetComponentInChildren<VelocityVector>();

            vectorScripts[i].setOffset(offsets[i]);
            vectors[i].transform.eulerAngles = directions[i];
            vectorScripts[i].referenceObject = this.velocityReference;
        }
    }

    private void Start()
    {
        for (int i =0; i< vectors.Length;i++)
        {
            vectorScripts[i].setColor(colors[i]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
