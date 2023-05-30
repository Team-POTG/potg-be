using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nito.AsyncEx;
using potg.RiotGames.Data;

namespace potg.RiotGames;

public class DataDragon
{
    #region Singleton

    private static readonly Lazy<DataDragon> Lazy = new();
    public static DataDragon Instance => Lazy.Value;

    #endregion

    private readonly AsyncReaderWriterLock _rwLock = new();

    private readonly Dictionary<string, Spell> _spells = new();
    private readonly Dictionary<int, ChampionDescription> _championDescriptions = new();

    #region Spell

    public Spell GetSpellByKey(string key)
    {
        var lockToken = _rwLock.ReaderLock();

        try
        {
            return _spells[key];
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"요청한 {key}는 존재하지 않는 스펠입니다.");
        }
        catch (Exception ex)
        {
            //TODO: 로그
            throw ex;
        }
        finally
        {
            lockToken.Dispose();
        }
    }

    public Spell GetSpellById(string id)
    {
        var lockToken = _rwLock.ReaderLock();

        try
        {
            return _spells.First(x => x.Value.Id == id).Value;
        }
        catch (Exception ex)
        {
            //TODO: 로그
            throw ex;
        }
        finally
        {
            lockToken.Dispose();
        }
    }

    private async Task LoadSpell(string version, HttpClient client)
    {
        var spellsText = await client.GetStringAsync($"http://ddragon.leagueoflegends.com/cdn/{version}/data/ko_KR/summoner.json");
        var spellsJson = JObject.Parse(spellsText);

        foreach (JProperty token in spellsJson["data"])
        {
            var spell = JsonConvert.DeserializeObject<Spell>(token.Value.ToString());
            if (spell != null)
            {
                _spells.Add(spell.Key, spell);
            }
        }
    }

    #endregion

    #region Champion

    public string GetChampionIdByKey(int key)
    {
        if (key == -1) return "";
        var lockToken = _rwLock.ReaderLock();

        try
        {
            return _championDescriptions[key].Id;
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"요청한 {key}는 존재하지 않는 챔피언입니다.");
        }
        catch (Exception ex)
        {
            //TODO: 로그
            throw ex;
        }
        finally
        {
            lockToken.Dispose();
        }
    }

    private async Task LoadChampion(string version, HttpClient client)
    {
        try
        {
            var text = await client.GetStringAsync($"http://ddragon.leagueoflegends.com/cdn/{version}/data/ko_KR/champion.json");
            var json = JObject.Parse(text);
            var data = JsonConvert.DeserializeObject<IDictionary<string, ChampionDescription>>(json["data"].ToString())
                                  .ToDictionary(x => x.Value.Key, x => x.Value);

            foreach (var (key, value) in data)
            {
                _championDescriptions.Add(key, value);
            }
        }
        catch (Exception ex)
        {
            //TODO: 로그
        }
    }

    #endregion

    public async Task Load(string version)
    {
        var lockToken = await _rwLock.WriterLockAsync();

        try
        {
            Reset();

            using var client = new HttpClient();

            await LoadSpell(version, client);
            await LoadChampion(version, client);
        }
        catch (Exception ex)
        {
            //TODO: 로그
        }
        finally
        {
            _spells.Add("0", new Spell {Id = ""});
            lockToken.Dispose();
        }
    }


    private void Reset()
    {
        _spells.Clear();
    }
}