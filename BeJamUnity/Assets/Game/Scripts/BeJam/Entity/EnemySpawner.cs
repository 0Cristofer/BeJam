using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BeJam
{
    public class EnemySpawner : MonoBehaviour
    {
        [field: SerializeField]
        private EnemyComponent EnemyPrefab { get; set; }
        
        [field: SerializeField]
        private PlayerComponent Player { get; set; }

        [field: SerializeField]
        private BoxCollider2D SpawnAreCollider { get; set; }
        
        [field: SerializeField]
        private TextMeshProUGUI EnemiesText { get; set; }
        
        [field: SerializeField]
        private uint EnemiesToSpawn { get; set; }

        [field: SerializeField]
        private float FirstSpawnInterval { get; set; }

        [field: SerializeField]
        private float MinSpawnInterval { get; set; }

        [field: SerializeField]
        private float MaxSpawnInterval { get; set; }
        
        private uint EnemiesSpawned { get; set; }
        private float CurrentSpawnInterval { get; set; }
        private float TimeSinceLastSpawn { get; set; }

        private void Start()
        {
            EnemiesSpawned = 0;
            EndGameManager.TotalEnemies += EnemiesToSpawn;
            EnemiesText.text = "Enemies left: " + EndGameManager.TotalEnemies;
            CurrentSpawnInterval = FirstSpawnInterval;
            TimeSinceLastSpawn = 0;
        }

        private void FixedUpdate()
        {
            if (EnemiesSpawned >= EnemiesToSpawn)
                return;
            
            if (TimeSinceLastSpawn >= CurrentSpawnInterval)
            {
                SpawnEnemy();
                ResetSpawnTimer();
            }
            
            TimeSinceLastSpawn += Time.fixedDeltaTime;
        }

        private void SpawnEnemy()
        {
            var minX = gameObject.transform.position.x - (SpawnAreCollider.size * 0.5f).x;
            var maxX = gameObject.transform.position.x + (SpawnAreCollider.size * 0.5f).x;
            var minY = gameObject.transform.position.y - (SpawnAreCollider.size * 0.5f).y;
            var maxY = gameObject.transform.position.y + (SpawnAreCollider.size * 0.5f).y;
            
            var x = Random.Range(minX, maxX);
            var y = Random.Range(minY, maxY);
            var enemyPosition = new Vector2(x, y);

            var playerCollider = Player.GetComponent<Collider2D>();
            if (playerCollider == null)
                return;

            if (SpawnAreCollider.bounds.Intersects(playerCollider.bounds))
            {
                return; 
            }

            EnemiesSpawned++;
            var enemy = Instantiate(EnemyPrefab, transform);
            enemy.Init(enemyPosition, EnemiesText);
        }

        private void ResetSpawnTimer()
        {
            TimeSinceLastSpawn = 0;
            CurrentSpawnInterval = Random.Range(MinSpawnInterval, MaxSpawnInterval);
        }
    }
}