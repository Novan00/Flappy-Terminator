using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private float _secondsBetweenSpawn;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Shoot()
    {
        var delay = new WaitForSeconds(_secondsBetweenSpawn);

        while (enabled)
        {
            Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity);

            yield return delay;
        }
    }
}
