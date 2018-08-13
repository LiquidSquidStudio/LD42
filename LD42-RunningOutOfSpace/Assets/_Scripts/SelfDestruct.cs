using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    SpriteRenderer rocketSprite;

    int childCount;

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
        if (!rocketSprite.enabled && childCount < 2)
            Destroy(this.gameObject);
    }
}
