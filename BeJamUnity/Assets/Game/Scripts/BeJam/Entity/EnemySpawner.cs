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
        private uint EnemiesToSpawn { get; set; }

        [field: SerializeField]
        private float FirstSpawnInterval { get; set; }

        [field: SerializeField]
        private float MinSpawnInterval { get; set; }

        [field: SerializeField]
        private float MaxSpawnInterval { get; set; }

        [field: SerializeField]
        private Vector4 SpawnBounds { get; set; }
        
        private uint EnemiesSpawned { get; set; }
        private float CurrentSpawnInterval { get; set; }
        private float TimeSinceLastSpawn { get; set; }

        private void Start()
        {
            EnemiesSpawned = 0;
            EndGameManager.TotalEnemies += EnemiesToSpawn;
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
            var x = Random.Range(SpawnBounds.x, SpawnBounds.y);
            var y = Random.Range(SpawnBounds.z, SpawnBounds.w);
            var enemyPosition = new Vector2(x, y);
            Debug.Log("Spawn: " + enemyPosition);
            Debug.Log("player: " + Player.transform.position);
            
            var enemyCollider = EnemyPrefab.GetComponent<Collider2D>();
            if (enemyCollider == null)
                return;

            if (!Utils.GetBoxSizeFromCollider2D(enemyCollider, out var enemyColliderSize))
            {
                return;
            }
            
            var playerCollider = Player.GetComponent<Collider2D>();
            if (playerCollider == null)
                return;

            if (!Utils.GetBoxSizeFromCollider2D(enemyCollider, out var playerColliderSize))
            {
                return;
            }

            if (Utils.AreCollidersIntersecting(enemyPosition, enemyColliderSize + Vector2.one * 5, Player.transform.position,
                    playerColliderSize))
            {
                SpawnEnemy();
                return;
            }

            EnemiesSpawned++;
            var enemy = Instantiate(EnemyPrefab, transform);
            enemy.Init(enemyPosition);
        }

        private void ResetSpawnTimer()
        {
            TimeSinceLastSpawn = 0;
            CurrentSpawnInterval = Random.Range(MinSpawnInterval, MaxSpawnInterval);
        }
    }
}