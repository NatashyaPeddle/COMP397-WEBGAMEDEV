///Code / Internal Documentation - File Name: ISerializer
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Save System


using System.Collections;
using Unity.VisualScripting;

public interface ISerializer
{
    
    string Serialize<T>(T obj); ///this will recieve the obj and serialize it

    T Deserialize<T>(string json);

}
