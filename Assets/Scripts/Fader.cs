using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader: MonoBehaviour {

bool fadeIn;
bool fadeOut;
float alphaColor;

public Image fadeImage;
public int loadScene = 1;
public Color fadeInColor;
public Color fadeOutColor;

    private void Start() { 
        fadeImage.gameObject.SetActive(true); 
        fadeImage.color = new Color(fadeOutColor.r, fadeOutColor.g, fadeOutColor.b, 1f); 
        fadeOut = true; 
    }

    public void ButtonStartGame() { 
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(fadeInColor.r, fadeInColor.g, fadeInColor.b, 0);
        fadeIn = true;
    }

    private void StartScene() { 
        SceneManager.LoadScene(loadScene);
    }

    private void Update() {
        if(fadeIn) {
            alphaColor = Mathf.Lerp(fadeImage.color.a, 1, Time.deltaTime * 2f);
            fadeImage.color = new Color(fadeInColor.r, fadeInColor.g, fadeInColor.b, alphaColor);
        }

        if(fadeOut) {
            alphaColor = Mathf.Lerp(fadeImage.color.a, 0, Time.deltaTime * 2f);
            fadeImage.color = new Color(fadeOutColor.r, fadeOutColor.g, fadeOutColor.b, alphaColor);
        }
   
        if(alphaColor > 0.95 && fadeIn) {
            fadeIn = false;
            StartScene();
        }

        if(alphaColor < 0.05 && fadeOut) {
            fadeOut = false;
            fadeImage.gameObject.SetActive(false);
        }
    }
}