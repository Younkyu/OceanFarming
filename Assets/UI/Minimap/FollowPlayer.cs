using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private PolygonCollider2D worldCollider;
    private Bounds worldBoundary;
    [SerializeField]
    private SpriteRenderer minimapFrame;

    // Start is called before the first frame update
    // NOTE:    When pulling up the full map, it goes beyond the map boundary.
    //          BUT probably wont have to worry about it since the full map should display the whole map without following the player
    void Start()
    {
        worldBoundary = worldCollider.bounds;

        var height = minimapFrame.bounds.max.y + 0.01f;
        var width = minimapFrame.bounds.max.x + 0.01f;

        Global.minX = worldBoundary.min.x + width;
        Global.maxX = worldBoundary.extents.x - width;

        Global.minY = worldBoundary.min.y + height;
        Global.maxY = worldBoundary.extents.y - height;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Math.Clamp(target.transform.position.x, Global.minX, Global.maxX), Math.Clamp(target.transform.position.y, Global.minY, Global.maxY), transform.position.z);
    }
}



