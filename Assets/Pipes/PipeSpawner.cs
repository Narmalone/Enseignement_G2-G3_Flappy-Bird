using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxSpawnTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private MovePipe _movePipePrefab;
    [SerializeField] private float _timerSpeed = 1f;

    private float _spawnTimer = 0f;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if(_spawnTimer > _maxSpawnTime)
        {
            SpawnPipe();
            _spawnTimer = 0f;
        }

        _spawnTimer += _timerSpeed * Time.deltaTime;
    }

    public void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        MovePipe newMovePipe = Instantiate(_movePipePrefab, spawnPos, Quaternion.identity);
    }
}
