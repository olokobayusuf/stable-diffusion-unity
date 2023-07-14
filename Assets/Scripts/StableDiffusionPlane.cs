/* 
*   Stable Diffusion Sample
*   Copyright © 2023 Yusuf Olokoba.
*/

namespace NatML.Examples {

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.XR.ARFoundation;
    using UnityEngine.XR.ARSubsystems;
    using Unity.XR.CoreUtils;
    using Function;
    using Function.Types;

    public sealed class StableDiffusionPlane : MonoBehaviour {

        
        private Function fxn;
        private XROrigin origin;
        private ARRaycastManager raycastManager;
        private MeshRenderer renderer;
        private bool loading; // don't respond to touches when loading
        private Texture2D texture;
        
        private void Awake () {
            // Create a Function client
            fxn = FunctionUnity.Create();
            // Find XR origin and raycast manager
            origin = FindObjectOfType<XROrigin>();
            raycastManager = FindObjectOfType<ARRaycastManager>();
            // Get renderer
            renderer = GetComponent<MeshRenderer>();
        }

        private void Update () {
            // Check loading
            if (loading)
                return;
            // Check for touch
            if (Input.touchCount == 0)
                return;
            // Check touch phase
            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Ended)
                return;
            // Raycast against the scene
            var ray = origin.Camera.ScreenPointToRay(touch.position);
            var hits = new List<ARRaycastHit>();
            if (!raycastManager.Raycast(ray, hits, TrackableType.PlaneWithinPolygon))
                return;
            // Check that this plane was hit
            if (hits.All(hit => hit.trackable.gameObject != this.gameObject))
                return;
            // Log
            CreateTexture("an astronaut on the moon"); // INCOMPLETE // Show keyboard
        }

        private async Task CreateTexture (string prompt) {
            // Create prediction
            var prediction = await fxn.Predictions.Create(
                tag: "@samplefxn/stable-diffusion",
                inputs: new () { ["prompt"] = prompt }
            ) as CloudPrediction;
            // Load output image as a texture
            var image = prediction.results[0] as Value;
            texture = await image.ToTexture(texture);
            // Display
            renderer.material.mainTexture = texture;
            renderer.material.color = Color.white;
        }
    }
}