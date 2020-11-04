using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public string levelToLoad;


    // Update is called once per frame
    void Update()
    {
       
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
