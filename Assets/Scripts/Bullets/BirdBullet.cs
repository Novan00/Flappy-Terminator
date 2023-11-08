using UnityEngine;

public class BirdBullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Bird _bird;

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime, Space.Self);
    }

    public void Init(Bird bird)
    {
        _bird = bird;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            _bird.IncreaseScore();
            Destroy(gameObject);
        }
    }
}
