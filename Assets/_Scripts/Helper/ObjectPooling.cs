using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance { get; private set; }

    [Header("Spawn Object Info")]
    [SerializeField] private int capacity;
    [SerializeField] private GameObject objectToSpawn;

    [SerializeField] private Transform parentForSpawnningObject;
    public Transform ParentForSpawnningObject => parentForSpawnningObject;

    private List<GameObject> _spawnningObjectList = new List<GameObject>();


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
            _spawnningObjectList.Add(obj);
        }
    }

    public GameObject EnableObjects()
    {
        for(int i = 0; i < _spawnningObjectList.Count; i++)
        {
            if (_spawnningObjectList[i].activeSelf)
            {
                continue;
            }
            else
            {
                _spawnningObjectList[i].SetActive(true);
                return _spawnningObjectList[i].gameObject;
            }
        }

        SpawnObjects();

        return null;
    }
}
