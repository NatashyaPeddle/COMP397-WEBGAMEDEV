///Code / Internal Documentation - File Name: IDataService
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Save System

using System.Collections.Generic;
//public class XmlSerializer: ISerializer
//{
//    public T Deserialize<T>(string json)
//    {
//        return XmlSerializer.FromJson
//    }
//}

public interface IDataService
{
    void Save(GameData data, bool overwrite = true);
    GameData Load(string name);
    void Delete(string name);
    IEnumerable<string> ListSaves();

}
