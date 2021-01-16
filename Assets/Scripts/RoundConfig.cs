using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Round Config")]
public class RoundConfig : ScriptableObject
{
    [SerializeField] List<WaveConfig> _waves;

    public List<WaveConfig> GetRoundWaves() { return _waves; }
}
