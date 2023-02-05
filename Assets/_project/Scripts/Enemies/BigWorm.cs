using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class BigWorm : EnemyController
{
    // Worm spawn at start

    // Wait for time 

    // Move to visible edge

    // Fire worm at player

    public BoxCollider2D levelBounds;

    public Transform playerPos;

    public bool leftToRight;

    public float timeBetweenActivations;

    private void Start()
    {
        StartCoroutine(wormActivation(timeBetweenActivations));
        speed = Config.enemyConfig.enemies[GameConstants.Worm].speed;
    }

    private void OnEnable()
    {
        _ = SubscribePlayerEvents();
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private IEnumerator wormActivation(float timeBetweenActivations)
    {
        yield return new WaitForSeconds(timeBetweenActivations);
        yield return new WaitUntil(AtEnd);
        transform.position = GetSpawnPoint();
        Vector3 aimPoint = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z) + playerPos.up * -10f;
        transform.LookAt(aimPoint);
        StartCoroutine(wormActivation(timeBetweenActivations));
    }

    private bool AtEnd()
    {
         
        return leftToRight ? transform.position.x > levelBounds.bounds.max.x + 10 : transform.position.x < levelBounds.bounds.min.x - 10;
    }

    private Vector3 GetSpawnPoint()
    {
        leftToRight = Random.Range(0, 1) == 0;
        float x = leftToRight ? levelBounds.bounds.min.x - 10 : levelBounds.bounds.max.x + 10;
        float y = playerPos.position.y + Random.Range(-20f, 20f);
        return new Vector3(x, y, -0.1f);
    }

    async UniTask SubscribePlayerEvents()
    {
        await UniTask.WaitUntil(() => RootUI.instance != null);
        RootUI.instance.playerWin += OnWin;
    }

    private void OnWin()
    {
        Destroy(gameObject);
    }
}
