using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSky : MonoBehaviour {

    //int screenHeight;
    //int screenWidth;

    //[Range(1, 10)]
    //public int skyDensity;
    [Range(1, 10)]
    public int starScaling;

    public List<Sprite> starSprites;
    SpriteRenderer[] starRenderers;
    Transform[] starSizeAndRot;

    //private void Awake()
    //{
    //    screenHeight = Screen.height;
    //    screenWidth = Screen.width;
    //}

    private void Start()
    {
        PopulateNightSky();
    }

    Sprite randomStarSprite()
    {
        int index = Random.Range(0, starSprites.Count);

        return starSprites[index];
    }

    void PopulateNightSky()
    {
        starRenderers = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sprite in starRenderers)
            sprite.sprite = randomStarSprite();

        starSizeAndRot = GetComponentsInChildren<Transform>();

        foreach(Transform child in starSizeAndRot)
        {
            child.transform.localScale += new Vector3(0f, Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            child.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360f)));
        }
    }
}
