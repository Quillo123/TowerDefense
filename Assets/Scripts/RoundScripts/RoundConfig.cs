using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Round Config")]
public class RoundConfig : ScriptableObject
{
    [SerializeField] List<WaveConfig> _waves = new List<WaveConfig>();

    public List<WaveConfig> GetRoundWaves() { return _waves; }

    public void AddWave(WaveConfig wave)
    {
        _waves.Add(wave);
    }
}
