using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private CityEnumerator _cityEnumerator;
    [SerializeField] private GameObject _nextButton;

    private void OnEnable()
    {
		_nextButton.SetActive(_cityEnumerator.CurrentCityNumber != _cityEnumerator.CityCount);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void QuitGame()
	{
		Application.Quit();

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}
