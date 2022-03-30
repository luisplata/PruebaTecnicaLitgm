using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

class ObjectPool
{
    private readonly RecyclableObject _prefab;
    private readonly int _count;
    private readonly HashSet<RecyclableObject> _instantiateObjects;
    private Queue<RecyclableObject> _recycledObjects;


    public ObjectPool(RecyclableObject prefab, int count)
    {
        _prefab = prefab;
        _count = count;
        _instantiateObjects = new HashSet<RecyclableObject>();
        _recycledObjects = new Queue<RecyclableObject>(_count);
            
        for (var i = 0; i < _count; i++)
        {
            var instance = InstantiateNewInstance();
            instance.gameObject.SetActive(false);
            _recycledObjects.Enqueue(instance);
        }
    }


        public void Init()
        {
            
        }

        private RecyclableObject InstantiateNewInstance()
        {
            var instance = Object.Instantiate(_prefab);
            instance.Configure(this);
            return instance;
        }

        public T Spawn<T>()
        {
            var recyclableObject = GetInstance();
            _instantiateObjects.Add(recyclableObject);
            recyclableObject.gameObject.SetActive(true);
            recyclableObject.Init();
            return recyclableObject.GetComponent<T>();
        }

        private RecyclableObject GetInstance()
        {
            if (_recycledObjects.Count > 0)
            {
                return _recycledObjects.Dequeue();
            }
            
            Debug.LogWarning($"Not enough recycled objets for {_prefab.name} consider increase the initial number of objets");
            var instance = InstantiateNewInstance();
            return instance;
        }

        public void RecycleGameObject(RecyclableObject gameObjectToRecycle)
        {
            var wasInstantiated = _instantiateObjects.Remove(gameObjectToRecycle);
            Assert.IsTrue(wasInstantiated, $"{gameObjectToRecycle.name} was not instantiate on {_prefab.name} pool");
            
            gameObjectToRecycle.gameObject.SetActive(false);
            gameObjectToRecycle.Release();
            _recycledObjects.Enqueue(gameObjectToRecycle);
        }
}