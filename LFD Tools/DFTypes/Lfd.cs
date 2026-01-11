using System;
using System.Collections.Generic;

namespace LFD_Tools.DFTypes;

public class Lfd
{
    public Lfd()
    {
        Resources = new();
    }

    public List<LfdResource> Resources { get; set; }

    public void LoadFromFile(string filename)
    {
        using var fileStream = File.Open(filename, FileMode.Open, FileAccess.Read);
        using var reader = new BinaryReader(fileStream);

        // Read RMAP and validate
        var rmap = new LfdIndexEntry();
        rmap.Type = reader.ReadBytes(4);

        if (ConvertBytesToString(rmap.Type, 4) != "RMAP")
        {
            throw new Exception("Invalid LFD file.");
        }

        rmap.Name = reader.ReadBytes(8);
        var s = ConvertBytesToString(rmap.Name, 8);
        rmap.Size = reader.ReadInt32();

        var resourceCount = rmap.Size / 16;

        // Skip over the rest of the RMAP
        reader.ReadBytes(rmap.Size);

        for (int i = 0; i < resourceCount; i++)
        {
            var resource = new LfdResource();

            var header = new LfdIndexEntry();
            header.Type = reader.ReadBytes(4);
            header.Name = reader.ReadBytes(8);  
            header.Size = reader.ReadInt32();

            var type = ConvertBytesToString(header.Type, 4);
            resource.ResourceType = type switch
            {
                "ANIM" => ResourceType.ANIM,
                "DELT" => ResourceType.DELT,
                "FILM" => ResourceType.FILM,
                "FONT" => ResourceType.FONT,
                "GMID" => ResourceType.GMID,
                "PLTT" => ResourceType.PLTT,
                "VOIC" => ResourceType.VOIC,
                _ => ResourceType.Other,
            };

            resource.Name = ConvertBytesToString(header.Name, 8);
            resource.Size = header.Size;
            resource.Data = reader.ReadBytes(header.Size);

            this.Resources.Add(resource);
        }
    }

    private static string ConvertBytesToString(byte[] bytes, int length)
    {
        var result = string.Empty;
        for (int i = 0; i < length; i++)
        {
            if (bytes[i] == 0)
            {
                break;
            }

            result += (char)bytes[i];
        }

        return result;
    }
}

public enum ResourceType
{
    Other,
    ANIM,
    DELT,
    FILM,
    FONT,
    GMID,
    PLTT,
    VOIC,
}

public record LfdResource
{
    public ResourceType ResourceType { get; set; }
    public string? Name { get; set; }
    public Int32 Size { get; set; }
    public byte[]? Data { get; set; }

    public string? Label => $"{this.TypeString} {this.Name}";
        
    private string TypeString
    {
        get
        {
            return this.ResourceType switch
            {
                ResourceType.ANIM => "ANIM",
                ResourceType.DELT => "DELT",
                ResourceType.FILM => "FILM",
                ResourceType.FONT => "FONT",
                ResourceType.GMID => "GMID",
                ResourceType.PLTT => "PLTT",
                ResourceType.VOIC => "VOIC",
                _ => "UNKN",
            };
        }
    }
}

public struct LfdIndexEntry
{
    public byte[] Type { get; set; }
    public byte[] Name { get; set; }
    public Int32 Size { get; set; }
}
