using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFD_Tools.DFTypes;

public class Pltt
{
    public Pltt()
    {
        this.Colours = new PlttColour[256];
        this.Pad = 0;
    }
    
    public byte FirstColour { get; set; }
    public byte LastColour { get; set; }
    public PlttColour[] Colours { get; set; }
    public byte Pad { get; set; }

    public void LoadFromFile(string filename)
    {
        using (var fileStream = File.Open(filename, FileMode.Open, FileAccess.Read))
        {
            this.LoadFromStream(fileStream);
        }
    }

    public bool LoadFromStream(Stream data)
    {
        var dataSize = data.Length;
        if (dataSize < 3)
        {
            return false;
        }

        using var reader = new BinaryReader(data);
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        this.FirstColour = reader.ReadByte();
        this.LastColour = reader.ReadByte();

        // Validate size of data
        if (dataSize != 3 + 3 * (this.LastColour - this.FirstColour + 1))
        {
            return false;
        }

        for (int c = 0; c < 256; c++)
        {
            if (c >= this.FirstColour && c <= this.LastColour)
            {
                this.Colours[c] = new PlttColour()
                {
                    R = reader.ReadByte(),
                    G = reader.ReadByte(),
                    B = reader.ReadByte(),
                };
            }
            else
            {
                this.Colours[c] = new PlttColour();
            }
        }

        return true;
    }
}

public struct PlttColour
{
    public PlttColour(byte red, byte green, byte blue)
    {
        this.R = red;
        this.G = green;
        this.B = blue;
    }

    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
}
