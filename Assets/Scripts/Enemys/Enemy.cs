using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
