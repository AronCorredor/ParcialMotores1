using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        else if (gameObject.transform.position.y <= -16)
        {
            SceneManager.LoadScene(0);
        }

    }

}
