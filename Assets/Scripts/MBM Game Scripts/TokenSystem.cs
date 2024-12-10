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

    public SpawnManager _SpawnManager;


    private void Awake()
    {
        Instance = this;
    }

    public void UpdateToken(float Tokens, TokenTypes _TokenType)
    {
        switch (_TokenType)
        {
            case TokenTypes.Competitor:
                CompetitorTokens += Tokens;
                CompetitorTokensText.text = CompetitorTokens.ToString();
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
        _SpawnManager.CheckPlayerData()._TokenUpdateParticle.SetActive(true);
        _SpawnManager._UIManager._CurrentArt = null;
        _SpawnManager._UIManager.CompletePanel.SetActive(true);
        _SpawnManager._UIManager.GamePlayBttns(false);
        _SpawnManager._UIManager._TokenGainedText.text = (_TokenType).ToString() + " " + Tokens.ToString();
        Invoke(nameof(disableParticle), 2f);

    }

    void disableParticle()
    {
        _SpawnManager.CheckPlayerData()._TokenUpdateParticle.SetActive(false);
    }
}
