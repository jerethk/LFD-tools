using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFD_Tools.DFTypes;

public class Delt
{
    public Delt()
    {
    }

    public string? Name { get; set; }
    public UInt16 OffsetX { get; set; }
    public UInt16 OffsetY { get; set; }
    public UInt16 SizeX { get; set; }
    public UInt16 SizeY { get; set; }

    public int[,]? Pixels { get; set; }

    public void LoadFromFile(string filename)
    {
        this.Name = Path.GetFileName(filename).ToUpperInvariant();
        
        using (var fileStream = File.Open(filename, FileMode.Open, FileAccess.Read))
        {
            this.LoadFromStream(fileStream);
        }
    }

    public void LoadFromStream(Stream data)
    {
        using var reader = new BinaryReader(data);
        this.OffsetX = (UInt16)reader.ReadInt16();
        this.OffsetY = (UInt16)reader.ReadInt16();
        this.SizeX = (UInt16)(reader.ReadInt16() + 1);    // for some reason SizeX and SizeY are 1 less than actual...
        this.SizeY = (UInt16)(reader.ReadInt16() + 1);

        // Set all pixels to transparent initially
        this.Pixels = new int[this.SizeX, this.SizeY];
        for (var x = 0; x < this.SizeX; x++)
        {
            for (var y = 0; y < this.SizeY; y++)
            {
                this.Pixels[x, y] = -1;
            }
        }

        // Each DELT line is a horizontal line starting at startX, startY
        // Bit 0 of sizeAndType gives compression (1 = compressed)
        // Bits 1-15 of sizeAndType gives number of pixels in the line
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            UInt16 sizeAndType = (UInt16)reader.ReadInt16();
            if (sizeAndType == 0)
            {
                break;
            }

            var compressed = sizeAndType & 0b_0000_0000_0000_0001;
            var lineSize = sizeAndType >> 1;
            UInt16 startX = (UInt16)reader.ReadInt16();
            UInt16 startY = (UInt16)reader.ReadInt16();

            List<int> linePixels;
            if (compressed == 0)
            {
                linePixels = GetUncompressedLine(reader, lineSize).ToList();
            }
            else
            {
                linePixels = GetCompressedLine(reader, lineSize);
            }

            for (var x = 0; x < lineSize; x++)
            {
                this.Pixels[startX + x, startY] = linePixels[x];
            }
        }
    }

    public Bitmap? CreateBitmap(Pltt pltt, bool keepTransparent = true)
    {
        if (this.Pixels == null)
        {
            return null;
        }

        var bitmap = new Bitmap(this.SizeX, this.SizeY);
        var alpha = keepTransparent ? 0 : 255;

        for (var x = 0; x < this.SizeX; x++)
        {
            for (var y = 0; y < this.SizeY; y++)
            {
                var index = this.Pixels[x, y];
                var colour = index == -1
                    ? Color.FromArgb(alpha, 0, 0, 0)
                    : Color.FromArgb(255, pltt.Colours[index].R, pltt.Colours[index].G, pltt.Colours[index].B);

                bitmap.SetPixel(x, y, colour);
            }
        }

        return bitmap;
    }

    private static IEnumerable<int> GetUncompressedLine(BinaryReader reader, int lineSize)
    {
        var lineData = reader.ReadBytes(lineSize);
        foreach (byte b in lineData)
        {
            yield return b;
        }
    }

    private static List<int> GetCompressedLine(BinaryReader reader, int lineSize)
    {
        var result = new List<int>();

        while (result.Count < lineSize)
        {
            // For the first byte of each line segment,
            // if bit 0 == 1 it is an RLE segment, otherwise it is direct values to copy
            // bits 1-7 give the count of pixels in the segment
            byte next = reader.ReadByte();
            var isRLE = (next & 0b_00000001) == 1;
            var count = next >> 1;

            if (!isRLE)  // direct values
            {
                for (int p = 0; p < count; p++)
                {
                    result.Add(reader.ReadByte());
                }
            }
            else    // repeating value
            {
                var repeatingColour = reader.ReadByte();

                for (int p = 0; p < count; p++)
                {
                    result.Add(repeatingColour);
                }
            }
        }

        return result;
    }
}