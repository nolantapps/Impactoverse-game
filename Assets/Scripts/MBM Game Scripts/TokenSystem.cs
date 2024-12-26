using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenSystem : MonoBehaviour
{
    public static TokenSystem Instance;

    public float CompetitorTokens, _CreatorTokens, NatureLoverTokens, PhilanthropistTokens;

    public GameObject _TokenPanel;

    public Text CompetitorTokensText, _CreatorTokensText, NatureLoverTokensText, PhilanthropistTokensText;



    private void Awake()
    {
        Instance = this;
    }

    public void UpdateToken(float Tokens, TokenTypes _TokenType)
    {
        Debug.Log("Instance Is Available");
        switch (_TokenType)
        {

            case TokenTypes.Competitor:
                Debug.Log("CompetitorToken");
                CompetitorTokens += Tokens;
                CompetitorTokensText.text = CompetitorTokens.ToString();
                Debug.Log("CompetitorToken Complete");
                break;
            case TokenTypes.Creator:
                _CreatorTokens += Tokens;
                _CreatorTokensText.text = _CreatorTokens.ToString();
                break;
            case TokenTypes.Nature_Lover:
                NatureLoverTokens += Tokens;
                NatureLoverTokensText.text = NatureLoverTokens.ToString();
                break;
            case TokenTypes.Philanthropist:
                PhilanthropistTokens += Tokens;
                PhilanthropistTokensText.text = PhilanthropistTokens.ToString();
                break;
        }
        Debug.Log("Outside Switch Statement");
        if (SpawnManager.instance == null)
        {
            Debug.Log("SpawnManagerIsNUll");
        }
        if (UIManagerMBM.Instance== null)
        {
            Debug.Log("UIManagerIsNull");
        }

        SpawnManager.instance.CheckPlayerData()._TokenUpdateParticle.SetActive(true);
       
       UIManagerMBM.Instance._CurrentArt = null;
        UIManagerMBM.Instance.CompletePanel.SetActive(true);
        UIManagerMBM.Instance.GamePlayBttns(false);
        UIManagerMBM.Instance._TokenGainedText.text = (_TokenType).ToString() + " " + Tokens.ToString();
        Debug.Log("SpawnManagerIsAvalaible");
        Invoke(nameof(disableParticle), 2f);
        SoundSystemMBM.Instance.PlayTokenGained();
    }

    void disableParticle()
    {
        SpawnManager.instance.CheckPlayerData()._TokenUpdateParticle.SetActive(false);
    }
}
