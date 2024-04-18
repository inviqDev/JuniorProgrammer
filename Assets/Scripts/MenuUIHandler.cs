#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        ColorPicker.SelectColor(MainManager.instance.SelectedColor);
    }



    public void SaveColorClicked()
    {
        MainManager.instance.SaveColor();
    }


    public void LoadColorClicked()
    {
        MainManager.instance.LoadColor();
        ColorPicker.SelectColor(MainManager.instance.SelectedColor);
    }


    public void NewColorSelected(Color color)
    {
        MainManager.instance.StoreSelectedColor(color);
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    
    public void ExitGame()
    {
        MainManager.instance.SaveColor();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}