using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Defective.JSON;
using UnityEngine;
using UnityEngine.Networking;

namespace Winz
{
    public class APIManager : MonoBehaviour
    {
        public static APIManager Instance;
        public string updatecharacterApi;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(transform);
            }
            else
                Destroy(gameObject);
        }
        public void UpdateCharacter()
        {
            JSONObject form = new JSONObject();
            form.AddField("email","shaheernazim9@gmail.com");
            form.AddField("password", "manham12");
            form.AddField("shirt", DataGp.Instance.User.values.currentShirt);
            form.AddField("pant", DataGp.Instance.User.values.currentPant);
            form.AddField("shoes", DataGp.Instance.User.values.currentShoe);
            form.AddField("hair", DataGp.Instance.User.values.currentHair);
            form.AddField("cap", DataGp.Instance.User.values.currentCap);
            form.AddField("glass", DataGp.Instance.User.values.currentGlass);
            form.AddField("skin", DataGp.Instance.User.values.skinToneValue);
            if (DataGp.Instance.User.genders == Genders.Male)
            {
                form.AddField("gender", 'M');
            }
            else
            {
                form.AddField("gender", 'F');
            }
            StartCoroutine(UpdateCharacter(updatecharacterApi, OnCharacterUpdateSucceed, OnCharacterUpdateFailed, form));
        }
        public void OnCharacterUpdateSucceed(string succed)
        {
            AvatarCustomizer.instance.ChangeScene();
        }
        public void OnCharacterUpdateFailed(string succed)
        {
            Debug.Log("Failed");
        }
        //public void RegisterWithEmail(string email, string password, string username, string platformType, Action<User> OnSuccess, Action<string> OnError)
        //{
        //    JSONObject form = new JSONObject();
        //    form.AddField("email", email);
        //    form.AddField("password", password);
        //    form.AddField("username", username);
        //    form.AddField("platformType", platformType);

        //    StartCoroutine(RegisterWithEmailRoutine(APIs.RegisterWithEmail, OnSuccess, OnError, form));

        //}

        //public void VerifyEmail(string verificationCode, Action<User> OnSuccess, Action<string> OnError, string sessionToken)
        //{
        //    JSONObject form = new JSONObject();
        //    form.AddField("verificationCode", verificationCode);

        //    StartCoroutine(VerifyEmailRoutine(APIs.VerifyEmail, OnSuccess, OnError, form, sessionToken));
        //}

        //public void GetUser(string sessionToken, Action<User> OnSuccess, Action<string> OnError)
        //{
        //    StartCoroutine(GetOtherUserProfileRoutine(APIs.GetUser, OnSuccess, OnError, null, sessionToken));
        //}

        //public void LoginWithEmail(string email, string password, Action<User> OnSuccess, Action<string> OnError)
        //{
        //    JSONObject form = new JSONObject();
        //    form.AddField("email", email);
        //    form.AddField("password", password);

        //    StartCoroutine(LoginWithEmailRoutine(APIs.LoginWithEmail, OnSuccess, OnError, form));
        //}

        //public void ForgotPassword(string email, Action<string> OnSuccess, Action<string> OnError)
        //{
        //    JSONObject form = new JSONObject();
        //    form.AddField("email", email);

        //    StartCoroutine(ForgotPasswordRoutine(APIs.ForgotPassword, OnSuccess, OnError, form));
        //}

        //public void RecoverPassword(string email, string password, string otp, Action<User> OnSuccess, Action<string> OnError)
        //{
        //    JSONObject form = new JSONObject();
        //    form.AddField("email", email);
        //    form.AddField("password", password);
        //    form.AddField("otp", otp);

        //    StartCoroutine(RecoverPasswordRoutine(APIs.RecoverPassword, OnSuccess, OnError, form));

        //}

        //public void GetOtherUserProfile(string otherUserId, string sessionToken, Action<User> OnSuccess, Action<string> OnError)
        //{
        //    JSONObject form = new JSONObject();
        //    form.AddField("profileId", otherUserId);

        //    StartCoroutine(GetOtherUserProfileRoutine(APIs.GetOtherUserProfile, OnSuccess, OnError, form, sessionToken));
        //}
        IEnumerator RegisterWithEmailRoutine(string address, Action<User> OnSuccess, Action<string> OnError, JSONObject formData = null, string token = null)
        {
            UnityWebRequest webRequest = new UnityWebRequest(address, "POST");

            if (formData != null)
            {
                byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(formData.ToString());
                webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            }

            if (token != null)
            {
                webRequest.SetRequestHeader("Authorization", "Bearer " + token);
            }

            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
                OnError(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);
                OnSuccess(user);
            }
        }

        IEnumerator VerifyEmailRoutine(string address, Action<User> OnSuccess, Action<string> OnError, JSONObject formData = null, string token = null)
        {
            UnityWebRequest webRequest = new UnityWebRequest(address, "POST");

            if (formData != null)
            {
                byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(formData.ToString());
                webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            }

            if (token != null)
            {
                webRequest.SetRequestHeader("Authorization", "Bearer " + token);
            }

            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
                OnError(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);
                OnSuccess(user);
            }
        }

        IEnumerator LoginWithEmailRoutine(string address, Action<User> OnSuccess, Action<string> OnError, JSONObject formData = null, string token = null)
        {
            UnityWebRequest webRequest = new UnityWebRequest(address, "POST");

            if (formData != null)
            {
                byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(formData.ToString());
                webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            }

            if (token != null)
            {
                webRequest.SetRequestHeader("Authorization", "Bearer " + token);
            }

            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
                OnError(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);
                OnSuccess(user);
            }
        }
        IEnumerator ForgotPasswordRoutine(string address, Action<string> OnSuccess, Action<string> OnError, JSONObject formData = null, string token = null)
        {
            UnityWebRequest webRequest = new UnityWebRequest(address, "POST");

            if (formData != null)
            {
                byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(formData.ToString());
                webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            }

            if (token != null)
            {
                webRequest.SetRequestHeader("Authorization", "Bearer " + token);
            }

            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
                OnError(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                OnSuccess(webRequest.downloadHandler.text);
            }
        }
        IEnumerator RecoverPasswordRoutine(string address, Action<User> OnSuccess, Action<string> OnError, JSONObject formData = null, string token = null)
        {
            UnityWebRequest webRequest = new UnityWebRequest(address, "POST");

            if (formData != null)
            {
                byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(formData.ToString());
                webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            }

            if (token != null)
            {
                webRequest.SetRequestHeader("Authorization", "Bearer " + token);
            }

            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
                OnError(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);
                OnSuccess(user);
            }
        }
        IEnumerator UpdateCharacter(string address, Action<string> OnSuccess, Action<string> OnError, JSONObject formData = null, string token = null)
        {
            UnityWebRequest webRequest = new UnityWebRequest(address, "POST");

            if (formData != null)
            {
                byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(formData.ToString());
                webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            }

            if (token != null)
            {
                webRequest.SetRequestHeader("Authorization", "Bearer " + token);
            }

            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
                OnError(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
               
                OnSuccess("Success");
            }
        }
        IEnumerator GetOtherUserProfileRoutine(string address, Action<User> OnSuccess, Action<string> OnError, JSONObject formData = null, string token = null)
        {
            UnityWebRequest webRequest = new UnityWebRequest(address, "POST");

            if (formData != null)
            {
                byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(formData.ToString());
                webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            }

            if (token != null)
            {
                webRequest.SetRequestHeader("Authorization", "Bearer " + token);
            }

            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
                Debug.LogError(webRequest.downloadHandler.text);
                OnError(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                OnSuccess(JsonUtility.FromJson<User>(webRequest.downloadHandler.text));
            }
        }
    }

}