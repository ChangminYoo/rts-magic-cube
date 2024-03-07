using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoadManager : MonoBehaviour
{
	CanvasGroup canvasGroup;
	[SerializeField] Slider prograssBar;
	[SerializeField] TextMeshProUGUI prograssText;

	private readonly string currentScene = "0.Title";
	public static SceneLoadManager Instance { get; private set; }
	
	private void Awake()
	{
		canvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();

		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}

		DontDestroyOnLoad(gameObject);
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.sceneLoaded += LoadSceneEnd;
		StartCoroutine(Load(sceneName));
	}

	private IEnumerator Load(string sceneName)
	{
		prograssBar.value = 0f;
		prograssText.text = "0%";
		canvasGroup.alpha = 1f;

		AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
		op.allowSceneActivation = false;

		float timer = 0f;
		while (!op.isDone)
		{
			yield return null;
			timer += Time.unscaledDeltaTime;

			if (op.progress >= 0.9f)
			{
				prograssBar.value = 1;
				prograssText.text = "100%";

				op.allowSceneActivation = true;
				yield break;
			}
			else
			{
				prograssBar.value = Mathf.Lerp(prograssBar.value, op.progress, timer);
				if (prograssBar.value >= op.progress)
				{
					timer = 0f;
				}

				prograssText.text = string.Format("{0}%", (int)(op.progress * 100));
			}
		}
	}

	private void LoadSceneEnd(Scene scene, LoadSceneMode loadSceneMode)
	{
		canvasGroup.alpha = 0f;
		SceneManager.sceneLoaded -= LoadSceneEnd;
	}
}
