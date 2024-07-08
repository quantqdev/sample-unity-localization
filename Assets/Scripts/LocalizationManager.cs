using UnityEngine;
using UnityEngine.Localization.Settings;
using System.Collections.Generic;
using TMPro;

public class LocalizationManager : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;

    void Start()
    {
        SetupLanguageDropdown();
    }

    private void SetupLanguageDropdown()
    {
        List<string> options = new List<string>();

        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            options.Add(locale.LocaleName);
        }

        languageDropdown.ClearOptions();
        languageDropdown.AddOptions(options);
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
        languageDropdown.value = LocalizationSettings.AvailableLocales.Locales.IndexOf(LocalizationSettings.SelectedLocale);
    }

    private void OnLanguageChanged(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
