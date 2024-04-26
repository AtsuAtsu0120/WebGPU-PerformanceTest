using System;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    private void Start()
    {
        Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(0.01f)).Subscribe(_ =>
        {
            SpawnCube();
        }).AddTo(this);
    }

    private async void SpawnCube()
    {
        var positionX = Random.Range(-10f, 10f);
        var positionY = Random.Range(-6f, 6f);
        var positionZ = Random.Range(0f, 40f);

        var obj = Instantiate(_cube);
        obj.transform.position = new(positionX, positionY, positionZ);

        await UniTask.Delay(TimeSpan.FromSeconds(10f));
        
        Destroy(obj.gameObject);
    }
}
