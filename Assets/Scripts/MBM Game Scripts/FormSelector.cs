using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;
using System.Globalization;
using System;
public class FormSelector : MonoBehaviour
{
    public TMP_InputField UserName;
    public TMP_InputField DateOfBirth;
    public TextMeshProUGUI errorText;
    public void SubmitButton()
    {
        string userName = UserName.text.Trim();
        string dateOfBirth = DateOfBirth.text.Trim();

        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(dateOfBirth))
        {
            errorText.gameObject.SetActive(true);

            errorText.text = "UserName or Date of Birth cannot be empty.";
            return;
        }

        if (!DateTime.TryParseExact(
                dateOfBirth,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedDate))
        {
            errorText.gameObject.SetActive(true);
            errorText.text = "Date of Birth must be in the format DD/MM/YYYY.";
            return;
        }

        // If everything is valid
        errorText.text = "Inputs are valid!";
        GameAnalytics.SetCustomId(userName);
        GameAnalytics.NewDesignEvent(userName +" ANd Date Of Birth Is : "+ DateOfBirth );
        this.gameObject.SetActive(false);
    }
}
