using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer mapSprRnd;
    [SerializeField]
    private GameObject minimapFrame;
    [SerializeField]
    private Camera sideCamera;
    [SerializeField]
    private FollowPlayer followPlayerScript;
    [SerializeField]
    private Transform playerLocation;
    [SerializeField]
    private GameObject minimapCameraParent;

    // Toggles minimap to full map, vice versa
    protected void ToggleMap() {
        Global.mapToggled = !Global.mapToggled;

        // turn off the frame
        minimapFrame.SetActive(!Global.mapToggled);

        if (Global.mapToggled) {       // pull up full map
            // disable circle mask for minimap shape
            mapSprRnd.maskInteraction = SpriteMaskInteraction.None;

            // displace and enlarge second camera viewport
            sideCamera.rect = new Rect(0, 0.06f, 1, 1);

            // fov
            sideCamera.fieldOfView = 115;

            // set camera to middle of the map
            minimapCameraParent.transform.position = new Vector3(0, 0, minimapCameraParent.transform.position.z);

            // stop following player
            followPlayerScript.enabled = false;
        } else {                // shrink full map back to minimap
            // enable circle mask for minimap shape
            mapSprRnd.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

            // displace and unlargen second camera viewport
            sideCamera.rect = new Rect(0.77f, 0.645f, 0.23f, 0.34f);

            // fov
            sideCamera.fieldOfView = 60;

            // set camera back to player
            minimapCameraParent.transform.position = new Vector3(Math.Clamp(playerLocation.position.x, Global.minX, Global.maxX), Math.Clamp(playerLocation.position.y, Global.minY, Global.maxY), minimapCameraParent.transform.position.z);
            
            // continue to follow player
            followPlayerScript.enabled = true;
        }
    }
}
