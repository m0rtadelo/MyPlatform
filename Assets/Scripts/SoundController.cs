using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private GameObject CoinSoundPrefab;
    [SerializeField]
    private GameObject PlayerDeathSoundPrefab;

    public void DeleteFinished() {
        AudioSource[] sources = GameObject.FindObjectsOfType<AudioSource>();
        foreach(AudioSource aus in sources) {
            if(!aus.isPlaying) {
                Destroy(aus.gameObject);
            }
        }
    }

    public void PlayCoin(Vector3 position) {
        Instantiate(CoinSoundPrefab, position, Quaternion.identity);
        DeleteFinished();
    }

    public void PlayPlayerDeath(Vector3 position) {
        Instantiate(PlayerDeathSoundPrefab, position, Quaternion.identity);
        DeleteFinished();
    }
}
