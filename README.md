# Stable Diffusion in Augmented Reality

[GIF here]

This is a demo that uses Stable Diffusion to paint surfaces as you walk around in AR. Built with Unity [ARFoundation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@5.0/manual/index.html) and [Function](https://github.com/fxnai/fxn3d).

## How it Works
1. We use ARFoundation to detect planes in the world.
2. When the user [touches a plane](Assets/Scripts/StableDiffusionPlane.cs), we ask the user to type a prompt.
3. When the user enters the prompt, we use the [@yusuf/stable-diffusion](https://fxn.ai/@yusuf/stable-diffusion) predictor to generate an image from the prompt.

## Setup Instructions
1. Clone the repo and open in Unity.
2. Head over to [fxn.ai](https://fxn.ai) to create an account or log in. Once you do, generate an access key:
    ![generate access key](https://raw.githubusercontent.com/fxnai/.github/main/access_key.gif)
3. In Unity, open `Project Settings > Function` and paste in your access key:
    ![add access key to Unity](https://raw.githubusercontent.com/fxnai/fxn3d/main/settings.gif)
4. Set your build target to iOS or Android, the Build & Run!

> You will be asked to specify a payment method on Function after making a handful of predictions. So you probably want to do it right after you create an account.

## Requirements
- Unity 2022.3+

## Supported Platforms
- Android API Level 24+
- iOS 14+

## Useful Links
- [Join Function's Discord community](https://fxn.ai/community).

Thank you very much!

> Disclaimer: I'm the founder of Function.