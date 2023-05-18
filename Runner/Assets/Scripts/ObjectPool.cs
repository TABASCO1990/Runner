using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container; //тут лежат объекты которые только надо создать.
    [SerializeField] private int _capacity; //то сколько объектов заспаунено заранее.

    private List<GameObject> _pool = new List<GameObject>(); //тут лежат уже созданные объекты.

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }    
    }

    protected void Initialize(GameObject[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

        //ѕытаемс€ получить объект (нам нужно найти неактивный - свободный объект)
        protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false); // мы получим первый объект из списка который выключен

        return result != null;
    }
}
