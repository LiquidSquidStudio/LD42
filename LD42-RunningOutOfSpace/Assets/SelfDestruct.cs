using UnityEngine;
using UnityEngine.Events;

public class SelfDestruct : MonoBehaviour {

    SpriteRenderer rocketSprite;

    public UnityEvent rocketDestroyed;

    public int childCount;

    private void Awake()
    {
        rocketSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        childCount = transform.childCount;
        CheckIfDestroyed();
    }

    void CheckIfDestroyed()
    {
        if (!rocketSprite.enabled && childCount < 3)
        {
            rocketDestroyed.Invoke();
            Destroy(this.gameObject);
        }
    }
}
