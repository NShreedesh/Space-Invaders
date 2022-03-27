using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [Header("Spawn Object Info")]
    [SerializeField] private int capacity;
    [SerializeField] private GameObject objectToSpawn;

    [SerializeField] private Transform parentForSpawnningObject;

    private List<GameObject> _spawnningObjectList = new List<GameObject>();

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
