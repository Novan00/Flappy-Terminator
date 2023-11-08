using UnityEngine;

public class BirdShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BirdBullet _bullet;
    [SerializeField] private Bird _bird;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(_shootPoint);
        }
    }

    public void Shoot(Transform shootPoint)
    {
        var bullet = Instantiate(_bullet, shootPoint.position, Quaternion.identity);
        bullet.Init(_bird);
        bullet.transform.rotation = _shootPoint.rotation;
    }
}
