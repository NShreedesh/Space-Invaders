using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance { get; private set; }

    [SerializeField] private int capacity;
    [SerializeField] private GameObject objectToSpawn;

    [SerializeField] private Transform parentForSpawnningObject;
    public Transform ParentForSpawnningObject => parentForSpawnningObject;

    [SerializeField] private List<GameObject> spawnningObjectList;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < capacity; i++)
        {
            var obj = Instantiate(objectToSpawn);
            obj.transform.SetParent(parentForSpawnningObject);
            obj.transform.localPosition = Vector3.zero;
            obj.SetActive(false);
            spawnningObjectList.Add(obj);
        }
    }

    public GameObject EnableObjects()
    {
        for(int i = 0; i < spawnningObjectList.Count; i++)
        {
            if (spawnningObjectList[i].activeSelf)
            {
                continue;
            }
            else
            {
                spawnningObjectList[i].SetActive(true);
                return spawnningObjectList[i].gameObject;
            }
        }

        SpawnObjects();

        return null;
    }
}
